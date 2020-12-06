using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest
{
    [XmlRoot(ElementName = "_RESIDENCE")]
    public class Residence
    {
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
    }
}