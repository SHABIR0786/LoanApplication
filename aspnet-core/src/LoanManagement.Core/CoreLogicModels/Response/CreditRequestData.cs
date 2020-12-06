
using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.Response
{

    [XmlRoot(ElementName = "CREDIT_REQUEST_DATA")]
    public class CreditRequestData
    {
        [XmlElement(ElementName = "CREDIT_REPOSITORY_INCLUDED")]
        public CreditRepositoryIncluded CREDIT_REPOSITORY_INCLUDED { get; set; }
        [XmlAttribute(AttributeName = "BorrowerID")]
        public string BorrowerID { get; set; }
        [XmlAttribute(AttributeName = "CreditReportIdentifier")]
        public string CreditReportIdentifier { get; set; }
        [XmlAttribute(AttributeName = "CreditRequestType")]
        public string CreditRequestType { get; set; }
    }
}