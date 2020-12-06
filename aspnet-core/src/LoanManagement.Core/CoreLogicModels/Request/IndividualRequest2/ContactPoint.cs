using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest2
{
    [XmlRoot(ElementName = "CONTACT_POINT")]
    public class ContactPoint
    {
        [XmlAttribute(AttributeName = "_Type")]
        public string _Type { get; set; }
        [XmlAttribute(AttributeName = "_Value")]
        public string _Value { get; set; }
        [XmlAttribute(AttributeName = "_PreferenceIndicator")]
        public string _PreferenceIndicator { get; set; }
        [XmlAttribute(AttributeName = "_RoleType")]
        public string _RoleType { get; set; }
    }
}
