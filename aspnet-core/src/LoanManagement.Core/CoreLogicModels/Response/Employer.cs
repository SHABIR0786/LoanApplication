
using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.Response
{

    [XmlRoot(ElementName = "EMPLOYER")]
    public class Employer
    {
        [XmlAttribute(AttributeName = "_Name")]
        public string _Name { get; set; }
        [XmlAttribute(AttributeName = "EmploymentCurrentIndicator")]
        public string EmploymentCurrentIndicator { get; set; }
        [XmlAttribute(AttributeName = "EmploymentPositionDescription")]
        public string EmploymentPositionDescription { get; set; }
        [XmlAttribute(AttributeName = "EmploymentReportedDate")]
        public string EmploymentReportedDate { get; set; }
    }
}