using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.JointResponse
{

    [XmlRoot(ElementName = "_RESIDENCE")]
    public class Residence
    {
        [XmlElement(ElementName = "PARSED_STREET_ADDRESS")]
        public ParsedStreetAddress PARSED_STREET_ADDRESS { get; set; }
        [XmlAttribute(AttributeName = "_StreetAddress")]
        public string _StreetAddress { get; set; }
        [XmlAttribute(AttributeName = "_City")]
        public string _City { get; set; }
        [XmlAttribute(AttributeName = "_State")]
        public string _State { get; set; }
        [XmlAttribute(AttributeName = "_PostalCode")]
        public string _PostalCode { get; set; }
        [XmlAttribute(AttributeName = "BorrowerResidencyType")]
        public string BorrowerResidencyType { get; set; }
        [XmlElement(ElementName = "CONTACT_DETAIL")]
        public ContactDetails CONTACT_DETAIL { get; set; }
    }
}