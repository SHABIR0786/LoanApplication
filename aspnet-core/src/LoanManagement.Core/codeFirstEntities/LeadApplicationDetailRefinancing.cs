using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LeadApplicationDetailRefinancing: FullAuditedEntity<int>
    {
        public ulong? IsWorkingWithEzalready { get; set; }
        public string WorkingOfficerName { get; set; }
        public string ObjectiveReason { get; set; }
        public string PropertyAddress { get; set; }
        public string PropertyUnit { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyZip { get; set; }
        public int PropertyStateId { get; set; }
        public int PropertyCountryId { get; set; }
        public float? PropertyEstimatedValue { get; set; }
        public float? PropertyLoanBalance { get; set; }
        public float? PropertCashOutAmount { get; set; }
        public float? NewLoanEstimateAmount { get; set; }
        public string CreditScore { get; set; }
        public string TypeOfHome { get; set; }
        public float? MonthlyHoadues { get; set; }
        public float? YearHomePurchased { get; set; }
        public float? OrignalPurchasedPrice { get; set; }
        public float? EstimatedAnnualTax { get; set; }
        public float? EstimatedAnnualHomeInsurance { get; set; }
        public string CurrentlyUsingHomeAs { get; set; }
        public ulong? IsMilitaryMember { get; set; }
        public string CurrentMilitaryStatus { get; set; }
        public string MilitaryBranch { get; set; }
        public ulong? IsEtsdateinYear { get; set; }
        public DateTime? Etsdate { get; set; }
        public ulong? IsValoanPreviously { get; set; }
        public string WhoLivingInHome { get; set; }
        public string PropertyLegalFirstName { get; set; }
        public string PropertyMiddleInitial { get; set; }
        public string PropertyLegalLastName { get; set; }
        public string PropertyPhoneNumber { get; set; }
        public string PropertyEmailAddress { get; set; }
        public string PropertyPassword { get; set; }
        public ulong? IsSomeoneRefer { get; set; }
        public string RefferedBy { get; set; }
        public ulong? IsApplyOwn { get; set; }
        public ulong? IsLegalSpouse { get; set; }
        public string MaritialStatus { get; set; }
        public int? NumberOfDependents { get; set; }
        public int? FirstDependantAge { get; set; }
        public ulong? IsCurrentlyLivingOnRefinancingProperty { get; set; }
        public string CurrentAddress { get; set; }
        public string CurrentUnit { get; set; }
        public string CurrentCity { get; set; }
        public int CurrentStateId { get; set; }
        public string CurrentZipCode { get; set; }
        public DateTime? CurrentStartLivingDate { get; set; }
        public string CurrentReantingType { get; set; }
        public float? EstimatedMonthlyExpenses { get; set; }
        public string PersonalLegalFirstName { get; set; }
        public string PersonalMiddleInitial { get; set; }
        public string PersonalLegalLastName { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public string PersonalEmailAddress { get; set; }
        public string PersonalPassword { get; set; }
        public ulong? IsAddressSameAsPrimaryBorrower { get; set; }
        public string PersonalAddress { get; set; }
        public string PersonalUnit { get; set; }
        public string PersonalCity { get; set; }
        public int PersonalStateId { get; set; }
        public string PersonalZipCode { get; set; }
        public DateTime? PersonalStartLivingDate { get; set; }
        public string PersonalReantingType { get; set; }
        public ulong? IsEmployementHistory { get; set; }
        public ulong? IsCoBorrowerHaveShareIncome { get; set; }
        public string Sex { get; set; }
        public string Ethnicity { get; set; }
        public string Race { get; set; }
        public int CitizenshipId { get; set; }
        public ulong? IsCertify { get; set; }
        public ulong? IsReadEconsent { get; set; }
        public ulong? IsReadThirdPartyConsent { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string ConformSsn { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
