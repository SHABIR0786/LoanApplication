using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest2
{

    [XmlRoot(ElementName = "EMPLOYER")]
    public class Employer
    {
        [XmlAttribute(AttributeName = "_Name")]
        public string _Name { get; set; }
        [XmlAttribute(AttributeName = "_City")]
        public string _City { get; set; }
        [XmlAttribute(AttributeName = "_State")]
        public string _State { get; set; }
        [XmlAttribute(AttributeName = "EmploymentCurrentIndicator")]
        public string EmploymentCurrentIndicator { get; set; }
        [XmlAttribute(AttributeName = "EmploymentPositionDescription")]
        public string EmploymentPositionDescription { get; set; }
        [XmlAttribute(AttributeName = "EmploymentReportedDate")]
        public string EmploymentReportedDate { get; set; }
    }
}
