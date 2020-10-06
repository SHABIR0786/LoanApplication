using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace LoanManagement.Models
{
    public class LoanApplication : FullAuditedEntity<long>, IMayHaveTenant
    {
        public long? LoanDetailId { get; set; }
        public virtual LoanDetail LoanDetail { get; set; }

        public long? AdditionalDetailsId { get; set; }
        public virtual AdditionalDetail AdditionalDetail { get; set; }

        public long? PersonalDetailId { get; set; }
        public virtual PersonalDetail PersonalDetail { get; set; }

        public long? AdditionalIncomeId { get; set; }
        public virtual AdditionalIncome AdditionalIncome { get; set; }

        public long? CreditAuthAgreementId { get; set; }
        public virtual CreditAuthAgreement CreditAuthAgreement { get; set; }

        public long? ConsentDetailId { get; set; }
        public virtual ConsentDetail ConsentDetail { get; set; }

        public long? ExpenseId { get; set; }
        public Expense Expense { get; set; }

        public List<DeclarationBorrowereDemographicsInformation> DemographicsInformations { get; set; }
        public List<Declaration> Declarations { get; set; }

        public int? TenantId { get; set; }
    }
}