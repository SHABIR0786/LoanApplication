using Abp.Application.Services.Dto;

namespace LoanManagement.ViewModels
{
    public class DeclarationDetailDto : EntityDto<long?>
    {
        public bool? IsOutstandingJudgmentsAgainstYou { get; set; }
        public bool? IsDeclaredBankrupt { get; set; }
        public bool? IsPropertyForeClosedUponOrGivenTitle { get; set; }
        public bool? IsPartyToLawsuit { get; set; }
        public bool? IsObligatedOnAnyLoanWhichResultedForeclosure { get; set; }
        public bool? IsPresentlyDelinquent { get; set; }
        public bool? IsObligatedToPayAlimonyChildSupport { get; set; }
        public bool? IsAnyPartOfTheDownPayment { get; set; }
        public bool? IsCoMakerOrEndorser { get; set; }
        public bool? IsUSCitizen { get; set; }
        public bool? IsPermanentResidentSlien { get; set; }
        public bool? IsIntendToOccupyThePropertyAsYourPrimary { get; set; }
        public bool? IsOwnershipInterestInPropertyInTheLastThreeYears { get; set; }
        public string DeclarationsSection { get; set; }

    }
}