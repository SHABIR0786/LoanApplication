using System.Collections.Generic;
using System.Xml.Serialization;
namespace LoanManagement.CoreLogicModels.JointResponse
{

    [XmlRoot(ElementName = "CREDIT_SCORE")]
    public class CreditScore
    {
        [XmlElement(ElementName = "_FACTOR")]
        public List<Factor> _FACTOR { get; set; }
        [XmlAttribute(AttributeName = "CreditScoreID")]
        public string CreditScoreID { get; set; }
        [XmlAttribute(AttributeName = "CreditReportIdentifier")]
        public string CreditReportIdentifier { get; set; }
        [XmlAttribute(AttributeName = "BorrowerID")]
        public string BorrowerID { get; set; }
        [XmlAttribute(AttributeName = "CreditFileID")]
        public string CreditFileID { get; set; }
        [XmlAttribute(AttributeName = "_Date")]
        public string _Date { get; set; }
        [XmlAttribute(AttributeName = "_ModelNameType")]
        public string _ModelNameType { get; set; }
        [XmlAttribute(AttributeName = "_ModelNameTypeOtherDescription")]
        public string _ModelNameTypeOtherDescription { get; set; }
        [XmlAttribute(AttributeName = "_Value")]
        public string _Value { get; set; }
        [XmlAttribute(AttributeName = "CreditRepositorySourceType")]
        public string CreditRepositorySourceType { get; set; }
        [XmlAttribute(AttributeName = "_FACTAInquiriesIndicator")]
        public string _FACTAInquiriesIndicator { get; set; }
    }
}