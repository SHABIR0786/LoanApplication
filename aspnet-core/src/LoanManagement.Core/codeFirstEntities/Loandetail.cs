using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Loandetail : FullAuditedEntity<long>
    {
        public Loandetail()
        {
            Loanapplications = new HashSet<Loanapplication>();
        }

        public long Id { get; set; }
        public bool? IsWorkingWithOfficer { get; set; }
        public int? LoanOfficerId { get; set; }
        public string ReferredBy { get; set; }
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
        public string City { get; set; }
        public int? StateId { get; set; }
        public int? PropertyTypeId { get; set; }
        public int? PropertyUseId { get; set; }
        public bool? StartedLookingForNewHome { get; set; }

        public virtual ICollection<Loanapplication> Loanapplications { get; set; }
    }
}
