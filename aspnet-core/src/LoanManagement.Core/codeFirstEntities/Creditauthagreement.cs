using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Creditauthagreement: FullAuditedEntity<long>
    {
        public Creditauthagreement()
        {
            Loanapplications = new HashSet<Loanapplication>();
        }

        public bool? AgreeCreditAuthAgreement { get; set; }

        public virtual ICollection<Loanapplication> Loanapplications { get; set; }
    }
}
