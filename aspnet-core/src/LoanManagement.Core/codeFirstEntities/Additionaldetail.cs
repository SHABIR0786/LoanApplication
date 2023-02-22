using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Additionaldetail : FullAuditedEntity<long>
    {
        public Additionaldetail()
        {
            Loanapplications = new HashSet<Loanapplication>();
        }

        public string NameOfIndividualsOnTitle { get; set; }
        public string NameOfIndividualsCoBorrowerOnTitle { get; set; }

        public virtual ICollection<Loanapplication> Loanapplications { get; set; }
    }
}
