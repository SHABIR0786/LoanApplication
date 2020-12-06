using System.Xml.Serialization;
namespace LoanManagement.CoreLogicModels.JointRequest
{
    [XmlRoot(ElementName = "BORROWER")]
    public class Borrower
    {
        [XmlElement(ElementName = "_RESIDENCE")]
        public Residence _RESIDENCE { get; set; }
        [XmlAttribute(AttributeName = "BorrowerID")]
        public string BorrowerID { get; set; }
        [XmlAttribute(AttributeName = "_FirstName")]
        public string _FirstName { get; set; }
        [XmlAttribute(AttributeName = "_MiddleName")]
        public string _MiddleName { get; set; }
        [XmlAttribute(AttributeName = "_LastName")]
        public string _LastName { get; set; }
        [XmlAttribute(AttributeName = "_NameSuffix")]
        public string _NameSuffix { get; set; }
        [XmlAttribute(AttributeName = "_PrintPositionType")]
        public string _PrintPositionType { get; set; }
        [XmlAttribute(AttributeName = "_SSN")]
        public string _SSN { get; set; }
    }
}


