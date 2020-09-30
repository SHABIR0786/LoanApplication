using Abp.Application.Services.Dto;

namespace LoanManagement.ViewModels
{
    public class LoanDetailDto : EntityDto<long>
    {
        public bool IsWorkingWithOfficer { get; set; }

        public int LoanOfficerId { get; set; }

        public string ReferredBy { get; set; }

        public int PurposeOfLoan { get; set; }

        public int EstimatedValue { get; set; }

        public int CurrentLoanAmount { get; set; }

        public int RequestedLoanAmount { get; set; }

        public int EstimatedPurchasePrice { get; set; }

        public int DownPaymentAmount { get; set; }

        public int DownPaymentPercentage { get; set; }

        public int SourceOfDownPayment { get; set; }

        public int GiftAmount { get; set; }

        public string GiftExplanation { get; set; }


        public bool HaveSecondMortgage { get; set; }

        public int SecondMortgageAmount { get; set; }

        public bool PayLoanWithNewLoan { get; set; }

        public bool RefinancingCurrentHome { get; set; }

        public string YearAcquired { get; set; }

        public int OriginalPrice { get; set; }


        public string City { get; set; }

        public int StateId { get; set; }

        public int PropertyTypeId { get; set; }

        public int PropertyUseId { get; set; }




    }
}
