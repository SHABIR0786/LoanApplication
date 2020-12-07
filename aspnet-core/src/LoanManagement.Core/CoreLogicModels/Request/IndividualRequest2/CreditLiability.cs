using System.Collections.Generic;
using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest2
{

    [XmlRoot(ElementName = "CREDIT_LIABILITY")]
    public class CREDIT_LIABILITY
    {
        [XmlElement(ElementName = "_CREDITOR")]
        public Creditor _CREDITOR { get; set; }
        [XmlElement(ElementName = "_CURRENT_RATING")]
        public CurrentRating _CURRENT_RATING { get; set; }
        [XmlElement(ElementName = "_HIGHEST_ADVERSE_RATING")]
        public HighestAdverseRating _HIGHEST_ADVERSE_RATING { get; set; }
        [XmlElement(ElementName = "_MOST_RECENT_ADVERSE_RATING")]
        public MostRecentAdverseRating _MOST_RECENT_ADVERSE_RATING { get; set; }
        [XmlElement(ElementName = "_PAYMENT_PATTERN")]
        public PaymentPattern _PAYMENT_PATTERN { get; set; }
        [XmlElement(ElementName = "_PRIOR_ADVERSE_RATING")]
        public List<PriorAdverseRating> _PRIOR_ADVERSE_RATING { get; set; }
        [XmlElement(ElementName = "CREDIT_COMMENT")]
        public List<CreditComment> CREDIT_COMMENT { get; set; }
        [XmlElement(ElementName = "CREDIT_REPOSITORY")]
        public List<CreditRepository> CREDIT_REPOSITORY { get; set; }
        [XmlAttribute(AttributeName = "CreditLiabilityID")]
        public string CreditLiabilityID { get; set; }
        [XmlAttribute(AttributeName = "BorrowerID")]
        public string BorrowerID { get; set; }
        [XmlAttribute(AttributeName = "CreditFileID")]
        public string CreditFileID { get; set; }
        [XmlAttribute(AttributeName = "_AccountIdentifier")]
        public string _AccountIdentifier { get; set; }
        [XmlAttribute(AttributeName = "_AccountOpenedDate")]
        public string _AccountOpenedDate { get; set; }
        [XmlAttribute(AttributeName = "_AccountOwnershipType")]
        public string _AccountOwnershipType { get; set; }
        [XmlAttribute(AttributeName = "_AccountReportedDate")]
        public string _AccountReportedDate { get; set; }
        [XmlAttribute(AttributeName = "_AccountBalanceDate")]
        public string _AccountBalanceDate { get; set; }
        [XmlAttribute(AttributeName = "_AccountStatusDate")]
        public string _AccountStatusDate { get; set; }
        [XmlAttribute(AttributeName = "_AccountStatusType")]
        public string _AccountStatusType { get; set; }
        [XmlAttribute(AttributeName = "_AccountType")]
        public string _AccountType { get; set; }
        [XmlAttribute(AttributeName = "_ConsumerDisputeIndicator")]
        public string _ConsumerDisputeIndicator { get; set; }
        [XmlAttribute(AttributeName = "_DerogatoryDataIndicator")]
        public string _DerogatoryDataIndicator { get; set; }
        [XmlAttribute(AttributeName = "_HighCreditAmount")]
        public string _HighCreditAmount { get; set; }
        [XmlAttribute(AttributeName = "_MonthsReviewedCount")]
        public string _MonthsReviewedCount { get; set; }
        [XmlAttribute(AttributeName = "_OriginalCreditorName")]
        public string _OriginalCreditorName { get; set; }
        [XmlAttribute(AttributeName = "_TermsDescription")]
        public string _TermsDescription { get; set; }
        [XmlAttribute(AttributeName = "_TermsMonthsCount")]
        public string _TermsMonthsCount { get; set; }
        [XmlAttribute(AttributeName = "_UnpaidBalanceAmount")]
        public string _UnpaidBalanceAmount { get; set; }
        [XmlAttribute(AttributeName = "CreditBusinessType")]
        public string CreditBusinessType { get; set; }
        [XmlAttribute(AttributeName = "CreditCounselingIndicator")]
        public string CreditCounselingIndicator { get; set; }
        [XmlAttribute(AttributeName = "CreditLoanType")]
        public string CreditLoanType { get; set; }
        [XmlElement(ElementName = "_LATE_COUNT")]
        public LateCount _LATE_COUNT { get; set; }
        [XmlAttribute(AttributeName = "_HighBalanceAmount")]
        public string _HighBalanceAmount { get; set; }
        [XmlAttribute(AttributeName = "_LastActivityDate")]
        public string _LastActivityDate { get; set; }
        [XmlAttribute(AttributeName = "_MonthlyPaymentAmount")]
        public string _MonthlyPaymentAmount { get; set; }
        [XmlAttribute(AttributeName = "_MonthsRemainingCount")]
        public string _MonthsRemainingCount { get; set; }
        [XmlAttribute(AttributeName = "_PastDueAmount")]
        public string _PastDueAmount { get; set; }
        [XmlAttribute(AttributeName = "_TermsSourceType")]
        public string _TermsSourceType { get; set; }
        [XmlAttribute(AttributeName = "_CreditLimitAmount")]
        public string _CreditLimitAmount { get; set; }
        [XmlAttribute(AttributeName = "_AccountClosedDate")]
        public string _AccountClosedDate { get; set; }
        [XmlAttribute(AttributeName = "_AccountPaidDate")]
        public string _AccountPaidDate { get; set; }
        [XmlAttribute(AttributeName = "_ChargeOffAmount")]
        public string _ChargeOffAmount { get; set; }
        [XmlAttribute(AttributeName = "_ChargeOffDate")]
        public string _ChargeOffDate { get; set; }
        [XmlAttribute(AttributeName = "CreditLoanTypeOtherDescription")]
        public string CreditLoanTypeOtherDescription { get; set; }
    }
}