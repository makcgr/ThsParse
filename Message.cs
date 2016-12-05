using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParseTHSMsg
{
    [Serializable]
    public class Message
    {
        public string Caption {get;set;}

        public SourceType SourceType { get; set; }

        public bool isIncoming { get; set; }

        public DateTime Timestamp { get; set; }

        public string TimestampStr { get; set; }

        public string Text { get; set; }

        public string DirectionText { get; set; }

        public string PreviewText { get; set; }

        public string FullText { get; set; }

    }

    [Serializable]
    public class MessageList
    {
        [XmlArray("Messages")]
        [XmlArrayItem("Message")]
        public List<Message> Messages { get; set; }

        public MessageList() { }

        public MessageList(IEnumerable<Message> messages)
        {
            this.Messages = new List<Message>(messages);
        }
    }
}
