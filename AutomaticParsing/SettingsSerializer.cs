using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace ParseTHSMsg.AutomaticParsing
{
    [Serializable]
    public class SettingsList
    {
        [XmlArray("SettingsList")]
        [XmlArrayItem("SettingsEntry")]
        public List<SettingsEntry> SettingsEntries { get; set; }
    }

    public class SettingsEntry
    {
        public SourceType Key;
        public MessageMatcherSettings Value;
        public SettingsEntry()
        {
        }

        public SettingsEntry(SourceType key, MessageMatcherSettings value)
        {
            Key = key;
            Value = value;
        }

        public static string SerializeSampleSettingsToFile()
        {

            var tpdvr_settings = new MessageMatcherSettings(@"tp240dvr\.log", @"(Sending\s|Received\s)", @"Received\s", @"Sending\s");
            var ths_settings = new MessageMatcherSettings(@"ths\.log", @"(Sent\smessage\sto|Received\smessage\sfrom|Forking\sinter_ths_sip)", @"Received\smessage\sfrom", @"Sent\smessage\sto|Forking\sinter_ths_sip");
            var tns_settings = new MessageMatcherSettings(@"tns\.log", @"(process:\s=====|send_message:)", @"process:\s=====", @"send_message:");
            var buddy_settings = new MessageMatcherSettings(@"buddy\.log", @"(SENDING\sMESSAGE\sTO\s|RECEIVED\sMESSAGE\sFROM\s)", @"RECEIVED\sMESSAGE\sFROM\s", @"SENDING\sMESSAGE\sTO\s");
            var rtsm_ths_settings = new MessageMatcherSettings(@"ths\.log", @"process_fox_message:", @"process_fox_message:", @"_NotSupportedYet_");

            var settingsList = new SettingsList();



            var settings = new[] {

                new SettingsEntry(SourceType.Tpdrv, (tpdvr_settings)   ),
                new SettingsEntry(SourceType.Ths, (ths_settings)       ),
                new SettingsEntry(SourceType.Tns, (tns_settings)       ),
                new SettingsEntry(SourceType.Buddy, (buddy_settings)   ),
                new SettingsEntry(SourceType.RTSM, (rtsm_ths_settings) )
                };

            settingsList.SettingsEntries = settings.ToList();

            var fileName = (Guid.NewGuid()).ToString();
            using (StreamWriter streamWriter = System.IO.File.CreateText(fileName))
            {
                var xmlSerializer = new XmlSerializer(settingsList.GetType());
                xmlSerializer.Serialize(streamWriter, settingsList);
            }

            return fileName;
        }

        public static Dictionary<SourceType, MessageMatcherSettings> ReadFromFile(string fileName)
        {
            var textReader = new StreamReader(fileName);

            var xmlSerializer = new XmlSerializer(typeof(SettingsList));

            SettingsList settingsList = (SettingsList)xmlSerializer.Deserialize(textReader);

            var dict = new Dictionary<SourceType, MessageMatcherSettings>();
            foreach (var s in settingsList.SettingsEntries)
            {
                dict.Add(s.Key, s.Value);
            }
            return dict;
        }

    }
}
