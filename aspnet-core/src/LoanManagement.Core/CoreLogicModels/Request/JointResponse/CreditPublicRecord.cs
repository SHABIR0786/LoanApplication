using System.Collections.Generic;
using System.Xml.Serialization;
namespace LoanManagement.CoreLogicModels.JointResponse
{

    [XmlRoot(ElementName = "CREDIT_PUBLIC_RECORD")]
    public class CreditPublicRecord
    {
        [XmlElement(ElementName = "CREDIT_REPOSITORY")]
        public List<CreditRepository> CREDIT_REPOSITORY { get; set; }
        [XmlAttribute(AttributeName = "CreditPublicRecordID")]
        public string CreditPublicRecordID { get; set; }
        [XmlAttribute(AttributeName = "BorrowerID")]
        public string BorrowerID { get; set; }
        [XmlAttribute(AttributeName = "CreditFileID")]
        public string CreditFileID { get; set; }
        [XmlAttribute(AttributeName = "_AccountOwnershipType")]
        public string _AccountOwnershipType { get; set; }
        [XmlAttribute(AttributeName = "_ConsumerDisputeIndicator")]
        public string _ConsumerDisputeIndicator { get; set; }
        [XmlAttribute(AttributeName = "_CourtName")]
        public string _CourtName { get; set; }
        [XmlAttribute(AttributeName = "_DerogatoryDataIndicator")]
        public string _DerogatoryDataIndicator { get; set; }
        [XmlAttribute(AttributeName = "_DispositionDate")]
        public string _DispositionDate { get; set; }
        [XmlAttribute(AttributeName = "_DispositionType")]
        public string _DispositionType { get; set; }
        [XmlAttribute(AttributeName = "_DocketIdentifier")]
        public string _DocketIdentifier { get; set; }
        [XmlAttribute(AttributeName = "_FiledDate")]
        public string _FiledDate { get; set; }
        [XmlAttribute(AttributeName = "_Type")]
        public string _Type { get; set; }
        [XmlAttribute(AttributeName = "_BankruptcyAssetsAmount")]
        public string _BankruptcyAssetsAmount { get; set; }
        [XmlAttribute(AttributeName = "_BankruptcyLiabilitiesAmount")]
        public string _BankruptcyLiabilitiesAmount { get; set; }
        [XmlAttribute(AttributeName = "_PlaintiffName")]
        public string _PlaintiffName { get; set; }
        [XmlAttribute(AttributeName = "_DefendantName")]
        public string _DefendantName { get; set; }
        [XmlAttribute(AttributeName = "_LegalObligationAmount")]
        public string _LegalObligationAmount { get; set; }
    }
}