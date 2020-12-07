
using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest2
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
        [XmlAttribute(AttributeName = "_Version")]
        public string _Version { get; set; }
    }
}