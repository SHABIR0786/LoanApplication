using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.JointResponse
{

    [XmlRoot(ElementName = "PARSED_STREET_ADDRESS")]
    public class ParsedStreetAddress
    {
        [XmlAttribute(AttributeName = "_StreetName")]
        public string _StreetName { get; set; }
        [XmlAttribute(AttributeName = "_DirectionSuffix")]
        public string _DirectionSuffix { get; set; }
        [XmlAttribute(AttributeName = "_HouseNumber")]
        public string _HouseNumber { get; set; }
        [XmlAttribute(AttributeName = "_StreetSuffix")]
        public string _StreetSuffix { get; set; }
        [XmlAttribute(AttributeName = "_ApartmentOrUnit")]
        public string _ApartmentOrUnit { get; set; }
    }
}
