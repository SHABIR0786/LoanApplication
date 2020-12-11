using System.Collections.Generic;
using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest2
{

    [XmlRoot(ElementName = "RESPONSE")]
    public class RESPONSE
    {
        [XmlElement(ElementName = "KEY")]
        public List<Key> KEY { get; set; }
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