using ParseTHSMsg.AutomaticParsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace ParseTHSMsg.ReportCreation
{
    public class ReportCreator
    {
        public static bool TryCreateDirectory(string sDirectorySelected, out string directory)
        {
            //create dir            
            var timeNow = DateTime.Now;
            var sDateTime = timeNow.ToString("dd-MM-yyyy_HH-mm-ss");
            directory = null;

            bool created = false;
            int n = 0;
            do
            {
                try
                {
                    directory = Path.Combine(sDirectorySelected,
                                        string.Format("MESSAGES_{0}{1}", sDateTime, (n == 0 ? "" : "_" + n)));
                    Directory.CreateDirectory(directory);
                    return true;
                }
                catch (IOException ioEx)
                {
                    Console.WriteLine("ERROR: Can't create such directory: {0}{1}{2}", directory, Environment.NewLine, ioEx);
                }
                n++;
            } while (!created || n > 10);
            
            try
            {
                directory = Path.Combine(sDirectorySelected,
                    string.Format("MESSAGES_{0}{1}", sDateTime, Guid.NewGuid()));
                Directory.CreateDirectory(directory);
                return true;
            }
            catch (IOException ioEx)
            {
                Console.WriteLine("ERROR: Can't create such directory: {0}{1}{2}", directory, Environment.NewLine, ioEx);
            }            
            return false;
        }

        public static void ExtractMessagesFromFiles(IEnumerable<ACSLogFile> mLogsToProcess,
            string directory, List<Message> messages, UIFilterSettings settUIFilters, 
            bool doCreateSeparateMessageLists, Action<string> uiSyncAction)
        {
            foreach (var logFile in mLogsToProcess)
            {
                settUIFilters.FilterRTSMMessages = (logFile.SourceType == SourceType.RTSM_in_thslog);

                var processorSettings = new LogProcessorSettings() { LogFile = logFile, UIFS = settUIFilters, CreateSeparateMessageLists = doCreateSeparateMessageLists };

                var lp = new LogProcessor();
                string resultPath = string.Empty;
                int prevMessagesCount = messages.Count;
                try
                {
                    resultPath = lp.ProcessLogFile(directory, processorSettings, m => messages.Add(m));
                    var messagesProcessedCount = messages.Count - prevMessagesCount;
                    var updateStatusText =
                        string.Format("Processed file {0}.{2}{1}{2}",
                        logFile.LogFileName, 
                        messagesProcessedCount == 0
                            ? string.Format("No {0} messages found.",logFile.SourceType) 
                            : string.Format("Parsed {0} {1} message(s).", messagesProcessedCount, logFile.SourceType), 
                        Environment.NewLine);

                    if (processorSettings.CreateSeparateMessageLists)
                        updateStatusText += string.Format("Generated file:{0}{1}{0}", Environment.NewLine, resultPath);

                    updateStatusText += Environment.NewLine;
                    uiSyncAction(updateStatusText);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(
                        string.Format("An error occured when processing file{0}{1}{2}{3}", logFile.LogFileName, Environment.NewLine, "Error:", ex)
                        , ex);
                }

                System.GC.Collect();
                GC.WaitForPendingFinalizers();
            }            
        }

        public static string SerializeMessagesToXmlReport(MessageList inputMsgList, string caption, string directory)
        {
            var tempXmlPath = Path.Combine(directory, String.Concat(Guid.NewGuid(), ".xml"));            

            if (!string.IsNullOrEmpty(caption))
                inputMsgList.TraceSetDescription = caption;

            inputMsgList.DateTimeStr = DateTime.Now.ToString("HH:mm:ss dd.MM.yyyy");

            using (StreamWriter streamWriter = System.IO.File.CreateText(tempXmlPath))
            {
                var xmlSerializer = new XmlSerializer(inputMsgList.GetType());
                xmlSerializer.Serialize(streamWriter, inputMsgList);
            }

            return tempXmlPath;
        }
        public static string CreateHtmlMessagesReport(IEnumerable<SourceType> inputSourceTypes, string directory, string xslPath, string messagesXmlPath, int messagesCount)
        {
            var htmlOutputPath = Path.Combine(directory, "output.html");

            //TODO: Prepare XSL transformation template            
            //Load XmlDocument from xslPath
            //Find <tbody> node
            //Compose the table contents template using 
            // - GetTableContentsTemplateXSL()
            // - GetRowTemplateXSL()
            // and input SourceTypes data.
            XmlDocument doc = new XmlDocument();
            doc.Load(xslPath);

            var tableNode = doc.SelectSingleNode("//table[@id='acs-messages']");
            if (tableNode == null)
                throw new ApplicationException("Can't find the required table node in the input XSL");

            var thead = tableNode.SelectSingleNode("./thead");            

            if (messagesCount > 0)
            {
                thead.InnerXml = GetTableHeaderTemplateXSL(inputSourceTypes);

                var tbody = tableNode.SelectSingleNode("./tbody");
                var tbodyTemplate = GetTableContentsTemplateXSL();
                var sb = new StringBuilder();
                var totalCount = inputSourceTypes.Count();
                int ix = 1;
                foreach (var st in inputSourceTypes)
                {
                    sb.Append(GetRowTemplateXSL(st, totalCount, ix));
                    ix++;
                }

                tbody.InnerXml = string.Format(tbodyTemplate, sb.ToString());
            }
            else
            {
                thead.InnerXml = "<th>No messages found.</th>";
            }
            // Process the intermediate xml by giving it to XSL transform and produce final html output                    

            // Create a reader to read temp xml
            using (XmlReader reader = XmlReader.Create(messagesXmlPath))
            // Create a writer for writing the transformed file.
            using (XmlWriter writer = XmlWriter.Create(htmlOutputPath,
                new XmlWriterSettings() { ConformanceLevel = ConformanceLevel.Fragment }))
            {
                // Create and load the transform with script execution enabled.
                XslCompiledTransform transform = new XslCompiledTransform();
                XsltSettings settings = new XsltSettings();
                settings.EnableScript = true;
                transform.Load(doc, settings, null);

                // Execute the transformation.
                transform.Transform(reader, writer);
            }            

            return htmlOutputPath;
        }

        public static string GetTableHeaderTemplateXSL(IEnumerable<SourceType> inputSourceTypes)
        {
            var sb = new StringBuilder();
            foreach (var st in inputSourceTypes)
            {
                sb.AppendFormat("<th scope=\"col\">{0}</th>", st);
            }
            return sb.ToString();
        }

        public static string GetTableContentsTemplateXSL()
        {
            var tableContentsXsl = 
                "<xsl:for-each select =\"/MessageList/Messages/Message\">" +
                "<xsl:variable name =\"sourceType\" select =\"SourceType\"/>" +
                "<xsl:choose>" +
                "{0}" +
                "</xsl:choose>" +
                "</xsl:for-each>";
            return tableContentsXsl;
        }

        static string GetRowTemplateXSL(SourceType sourceType, int columnsTotal, int columnNumber)
        {
            var rowTemplate = string.Format(    
                "<xsl:when test=\"$sourceType = '{1}'\">" +
                "{0}" +                                             // here goes the [table row] template
                "</xsl:when>"                                       // for particular SourceType
                , "{0}", sourceType.ToString());

            StringBuilder sbTRsTDs = new StringBuilder("<tr>");            
            for(int i=1; i<=columnsTotal; i++)
            {
                if (i != columnNumber)
                    sbTRsTDs.Append("<td/>");
                else
                {
                    sbTRsTDs.Append(
                        "<td>" +
                        "<xsl:call-template name =\"TMessage\">" +
                            "<xsl:with-param name =\"message\" select =\".\"/>" +
                        "</xsl:call-template >" +
                        "</td>");                        
                }
            }
            sbTRsTDs.Append("</tr>");            

            return string.Format(rowTemplate, sbTRsTDs);
        }
    }
}
