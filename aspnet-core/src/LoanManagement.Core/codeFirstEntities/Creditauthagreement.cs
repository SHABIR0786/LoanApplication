using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Creditauthagreement:Entity<long>
    {
        public Creditauthagreement()
        {
            Loanapplications = new HashSet<Loanapplication>();
        }

        public long Id { get; set; }
        public bool? AgreeCreditAuthAgreement { get; set; }

        public virtual ICollection<Loanapplication> Loanapplications { get; set; }
    }
}
