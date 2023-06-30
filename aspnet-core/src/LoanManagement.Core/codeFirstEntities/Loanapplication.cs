using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Loanapplication: FullAuditedEntity<long>
    {
        public Loanapplication()
        {
            Additionalincomes = new HashSet<Additionalincome>();
            Borroweremploymentinformations = new HashSet<Borroweremploymentinformation>();
            Borrowermonthlyincomes = new HashSet<Borrowermonthlyincome>();
            Declarationborroweredemographicsinformations = new HashSet<Declarationborroweredemographicsinformation>();
            Declarations = new HashSet<Declaration>();
            Manualassetentries = new HashSet<Manualassetentry>();
        }

        public long Id { get; set; }
        public long? LoanDetailId { get; set; }
        public long? AdditionalDetailId { get; set; }
        public long? PersonalDetailId { get; set; }
        public long? CreditAuthAgreementId { get; set; }
        public long? ConsentDetailId { get; set; }
        public long? ExpenseId { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual Additionaldetail AdditionalDetail { get; set; }
        public virtual Consentdetail ConsentDetail { get; set; }
        public virtual Creditauthagreement CreditAuthAgreement { get; set; }
        public virtual Expense Expense { get; set; }
        public virtual Loandetail LoanDetail { get; set; }
        public virtual Personaldetail PersonalDetail { get; set; }
        public virtual ICollection<Additionalincome> Additionalincomes { get; set; }
        public virtual ICollection<Borroweremploymentinformation> Borroweremploymentinformations { get; set; }
        public virtual ICollection<Borrowermonthlyincome> Borrowermonthlyincomes { get; set; }
        public virtual ICollection<Declarationborroweredemographicsinformation> Declarationborroweredemographicsinformations { get; set; }
        public virtual ICollection<Declaration> Declarations { get; set; }
        public virtual ICollection<Manualassetentry> Manualassetentries { get; set; }
    }
}
