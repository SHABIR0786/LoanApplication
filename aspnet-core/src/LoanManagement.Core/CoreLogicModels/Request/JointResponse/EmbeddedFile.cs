using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.JointResponse
{

    [XmlRoot(ElementName = "EMBEDDED_FILE")]
    public class EmbeddedFile
    {
        [XmlElement(ElementName = "DOCUMENT")]
        public string DOCUMENT { get; set; }
        [XmlAttribute(AttributeName = "_Type")]
        public string _Type { get; set; }
        [XmlAttribute(AttributeName = "_Name")]
        public string _Name { get; set; }
        [XmlAttribute(AttributeName = "_EncodingType")]
        public string _EncodingType { get; set; }
    }
}