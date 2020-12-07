using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.Response
{

    [XmlRoot(ElementName = "RESPONSE")]
    public class Response
    {
        [XmlElement(ElementName = "KEY")]
        public Key KEY { get; set; }
        [XmlElement(ElementName = "RESPONSE_DATA")]
        public ResponseData RESPONSE_DATA { get; set; }
        [XmlAttribute(AttributeName = "_ID")]
        public string _ID { get; set; }
        [XmlAttribute(AttributeName = "ResponseDateTime")]
        public string ResponseDateTime { get; set; }
        [XmlAttribute(AttributeName = "InternalAccountIdentifier")]
        public string InternalAccountIdentifier { get; set; }
    }
}