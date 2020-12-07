using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.JointRequest
{
    [XmlRoot(ElementName = "PREFERRED_RESPONSE")]
    public class PreferredResponse
    {
        [XmlAttribute(AttributeName = "_Format")]
        public string Format { get; set; } = "xml";
        [XmlAttribute(AttributeName = "_VersionIdentifier")]
        public string VersionIdentifier { get; set; }
    }
}
