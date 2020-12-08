using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.Models
{
    public class LoanApplication : Entity<long>
    {
        public long? LoanDetailId { get; set; }
        public virtual LoanDetail LoanDetail { get; set; }

        public long? AdditionalDetailsId { get; set; }
        public virtual AdditionalDetail AdditionalDetail { get; set; }

        public long? PersonalDetailId { get; set; }
        public virtual PersonalDetail PersonalDetail { get; set; }

        public long? CreditAuthAgreementId { get; set; }
        public virtual CreditAuthAgreement CreditAuthAgreement { get; set; }

        public long? ConsentDetailId { get; set; }
        public virtual ConsentDetail ConsentDetail { get; set; }

        public long? ExpenseId { get; set; }
        public Expense Expense { get; set; }

        public List<ManualAssetEntry> ManualAssetEntries { get; set; }

        public List<BorrowerEmploymentInformation> BorrowerEmploymentInformations { get; set; }
        public List<BorrowerMonthlyIncome> BorrowerMonthlyIncomes { get; set; }
        public List<DeclarationBorrowereDemographicsInformation> DemographicsInformations { get; set; }
        public List<Declaration> Declarations { get; set; }
        public List<AdditionalIncome> AdditionalIncomes { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}