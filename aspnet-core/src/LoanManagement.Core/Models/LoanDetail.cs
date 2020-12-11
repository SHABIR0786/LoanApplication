using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.Models
{
    public class LoanDetail : Entity<long>
    {
        public bool? IsWorkingWithOfficer { get; set; }

        public int? LoanOfficerId { get; set; }

        public string ReferredBy { get; set; }

        public int? PurposeOfLoan { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? EstimatedValue { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CurrentLoanAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? RequestedLoanAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? EstimatedPurchasePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DownPaymentAmount { get; set; }
        public double? DownPaymentPercentage { get; set; }

        public int? SourceOfDownPayment { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? GiftAmount { get; set; }

        public string GiftExplanation { get; set; }


        public bool? HaveSecondMortgage { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? SecondMortgageAmount { get; set; }

        public bool? PayLoanWithNewLoan { get; set; }

        public bool? RefinancingCurrentHome { get; set; }

        public string YearAcquired { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? OriginalPrice { get; set; }


        public string City { get; set; }

        public int? StateId { get; set; }

        public int? PropertyTypeId { get; set; }

        public int? PropertyUseId { get; set; }

        public bool? StartedLookingForNewHome { get; set; }
    }
}