using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest2
{

    [XmlRoot(ElementName = "PARSED_STREET_ADDRESS")]
    public class ParsedStreetAddress
    {
        [XmlAttribute(AttributeName = "_StreetName")]
        public string _StreetName { get; set; }
        [XmlAttribute(AttributeName = "_HouseNumber")]
        public string _HouseNumber { get; set; }
        [XmlAttribute(AttributeName = "_StreetSuffix")]
        public string _StreetSuffix { get; set; }
    }
}