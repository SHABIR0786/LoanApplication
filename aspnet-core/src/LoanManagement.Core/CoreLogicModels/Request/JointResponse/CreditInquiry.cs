using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.JointResponse
{

    [XmlRoot(ElementName = "CREDIT_INQUIRY")]
    public class CreditInquiry
    {
        [XmlElement(ElementName = "CREDIT_REPOSITORY")]
        public CreditRepository CREDIT_REPOSITORY { get; set; }
        [XmlAttribute(AttributeName = "CreditInquiryID")]
        public string CreditInquiryID { get; set; }
        [XmlAttribute(AttributeName = "BorrowerID")]
        public string BorrowerID { get; set; }
        [XmlAttribute(AttributeName = "CreditFileID")]
        public string CreditFileID { get; set; }
        [XmlAttribute(AttributeName = "_Name")]
        public string _Name { get; set; }
        [XmlAttribute(AttributeName = "_Date")]
        public string _Date { get; set; }
        [XmlAttribute(AttributeName = "CreditBusinessType")]
        public string CreditBusinessType { get; set; }
        [XmlAttribute(AttributeName = "CreditLoanType")]
        public string CreditLoanType { get; set; }
    }
}