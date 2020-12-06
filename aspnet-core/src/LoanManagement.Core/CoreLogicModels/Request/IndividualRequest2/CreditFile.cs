
using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest2
{

    [XmlRoot(ElementName = "CREDIT_FILE")]
    public class CREDIT_FILE
    {
        [XmlElement(ElementName = "_BORROWER")]
        public Borrower _BORROWER { get; set; }
        [XmlElement(ElementName = "CREDIT_COMMENT")]
        public CreditComment CREDIT_COMMENT { get; set; }
        [XmlAttribute(AttributeName = "CreditFileID")]
        public string CreditFileID { get; set; }
        [XmlAttribute(AttributeName = "BorrowerID")]
        public string BorrowerID { get; set; }
        [XmlAttribute(AttributeName = "CreditScoreID")]
        public string CreditScoreID { get; set; }
        [XmlAttribute(AttributeName = "CreditRepositorySourceType")]
        public string CreditRepositorySourceType { get; set; }
        [XmlAttribute(AttributeName = "_InfileDate")]
        public string _InfileDate { get; set; }
        [XmlAttribute(AttributeName = "_ResultStatusType")]
        public string _ResultStatusType { get; set; }
        [XmlElement(ElementName = "_ALERT_MESSAGE")]
        public AlertMessage _ALERT_MESSAGE { get; set; }
    }
}