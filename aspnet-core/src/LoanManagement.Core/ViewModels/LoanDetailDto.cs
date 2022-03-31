using Abp.Application.Services.Dto;

namespace LoanManagement.ViewModels
{
    public class LoanDetailDto : EntityDto<long?>
    {
        public bool? IsWorkingWithOfficer { get; set; }

        public string? LoanOfficerId { get; set; }
        public int? whatStageAreyouIn { get; set; }
        public string ReferredBy { get; set; }
        public decimal? EstimatedAnnualTaxes { get; set; }
        public decimal? EstimatedAnnualHomeInsurance { get; set; }

        public int? PurposeOfLoan { get; set; }

        public decimal? EstimatedValue { get; set; }

        public decimal? CurrentLoanAmount { get; set; }

        public decimal? RequestedLoanAmount { get; set; }

        public decimal? EstimatedPurchasePrice { get; set; }

        public decimal? DownPaymentAmount { get; set; }

        public double? DownPaymentPercentage { get; set; }

        public int? SourceOfDownPayment { get; set; }

        public decimal? GiftAmount { get; set; }

        public string GiftExplanation { get; set; }

        public bool? HaveSecondMortgage { get; set; }

        public decimal? SecondMortgageAmount { get; set; }

        public bool? PayLoanWithNewLoan { get; set; }

        public bool? RefinancingCurrentHome { get; set; }

        public string YearAcquired { get; set; }

        public decimal? OriginalPrice { get; set; }

        public string? Address { get; set; }
        public string? Unit { get; set; }
        public string? ZipCode { get; set; }
        public string City { get; set; }

        public int? StateId { get; set; }

        public int? PropertyTypeId { get; set; }

        public int? PropertyUseId { get; set; }
        public bool? StartedLookingForNewHome { get; set; }
        public bool? NewConstruction { get; set; }
        public bool? BankOwned { get; set; }
        public string? ContractDate { get; set; }
        public string? CreditScore { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public int? TypeOfHome { get; set; }
        public decimal? HoaDues { get; set; }

    }
}