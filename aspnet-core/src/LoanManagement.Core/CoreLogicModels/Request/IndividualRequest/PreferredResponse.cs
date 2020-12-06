using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest
{

    [XmlRoot(ElementName = "PREFERRED_RESPONSE")]
    public class PreferredResponse
    {
        [XmlAttribute(AttributeName = "_Format")]
        public string _Format { get; set; }
        [XmlAttribute(AttributeName = "_VersionIdentifier")]
        public string _VersionIdentifier { get; set; }
    }
}