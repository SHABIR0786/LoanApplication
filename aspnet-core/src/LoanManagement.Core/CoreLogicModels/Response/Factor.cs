
using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.Response
{

    [XmlRoot(ElementName = "_FACTOR")]
    public class Factor
    {
        [XmlAttribute(AttributeName = "_Code")]
        public string _Code { get; set; }
        [XmlAttribute(AttributeName = "_Text")]
        public string _Text { get; set; }
    }
}