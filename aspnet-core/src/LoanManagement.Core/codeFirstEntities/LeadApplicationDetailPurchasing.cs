using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LeadApplicationDetailPurchasing: FullAuditedEntity<int>
    {
        
        public string Stage { get; set; }
        public ulong? IsWorkingWithEzalready { get; set; }
        public string WorkingOfficerName { get; set; }
        public string NewHomeAddress { get; set; }
        public string NewHomeUnit { get; set; }
        public string NewHomeCity { get; set; }
        public int NewHomeStateId { get; set; }
        public string NewHomeZipCode { get; set; }
        public DateTime? ContractClosingDate { get; set; }
        public string ContractType { get; set; }
        public float? EstimatedHomePrice { get; set; }
        public float? DownPaymentAmount { get; set; }
        public float? DownPaymentPercentage { get; set; }
        public float? EstimatedAnnualTax { get; set; }
        public float? EstimatedAnnualHomeInsurance { get; set; }
        public string CreditScore { get; set; }
        public string PropertyLegalFirstName { get; set; }
        public string PropertyMiddleInitial { get; set; }
        public string PropertyLegalLastName { get; set; }
        public string PropertyPhoneNumber { get; set; }
        public string PropertyEmailAddress { get; set; }
        public string TypeOfHome { get; set; }
        public float? MonthlyHoadues { get; set; }
        public string TypeOfNewHome { get; set; }
        public ulong? IsMilitaryMember { get; set; }
        public string CurrentMilitaryStatus { get; set; }
        public string MilitaryBranch { get; set; }
        public ulong? IsEtsdateinYear { get; set; }
        public DateTime? Etsdate { get; set; }
        public ulong? IsValoanPreviously { get; set; }
        public string WhoLivingInHome { get; set; }
        public string PersonalLegalFirstName { get; set; }
        public string PersonalMiddleInitial { get; set; }
        public string PersonalLegalLastName { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public string PersonalEmailAddress { get; set; }
        public string PersonalPassword { get; set; }
        public ulong? IsSomeOneRefer { get; set; }
        public ulong? IsApplyOwn { get; set; }
        public string MaritialStatus { get; set; }
        public int? NumberOfDependents { get; set; }
        public string CurrentAddress { get; set; }
        public string CurrentUnit { get; set; }
        public string CurrentCity { get; set; }
        public int CurrentStateId { get; set; }
        public string CurrentZipCode { get; set; }
        public DateTime? CurrentStartLivingDate { get; set; }
        public string CurrentReantingType { get; set; }
        public float? EstimatedMonthlyExpenses { get; set; }
        public ulong? IsEmployementHistory { get; set; }
        public ulong? IsOtherSourceOfIncome { get; set; }
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
