
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.Response
{
    [XmlRoot(ElementName = "_BORROWER")]
    public class Borrower2
    {
        [XmlElement(ElementName = "_RESIDENCE")]
        public List<Residence> _RESIDENCE { get; set; }
        [XmlElement(ElementName = "EMPLOYER")]
        public List<Employer> EMPLOYER { get; set; }
        [XmlAttribute(AttributeName = "_BirthDate")]
        public string _BirthDate { get; set; }
        [XmlAttribute(AttributeName = "_FirstName")]
        public string _FirstName { get; set; }
        [XmlAttribute(AttributeName = "_LastName")]
        public string _LastName { get; set; }
        [XmlAttribute(AttributeName = "_MiddleName")]
        public string _MiddleName { get; set; }
        [XmlAttribute(AttributeName = "_SSN")]
        public string _SSN { get; set; }
        [XmlElement(ElementName = "_ALIAS")]
        public Alias _ALIAS { get; set; }
    }
}