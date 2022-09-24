using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Additionaldetail : Entity<long>
    {
        public Additionaldetail()
        {
            Loanapplications = new HashSet<Loanapplication>();
        }

        public long Id { get; set; }
        public string NameOfIndividualsOnTitle { get; set; }
        public string NameOfIndividualsCoBorrowerOnTitle { get; set; }

        public virtual ICollection<Loanapplication> Loanapplications { get; set; }
    }
}
