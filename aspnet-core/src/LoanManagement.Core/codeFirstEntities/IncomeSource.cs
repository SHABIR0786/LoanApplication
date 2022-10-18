using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class IncomeSource:Entity<int>
    {
        public IncomeSource()
        {
            ApplicationIncomeSources = new HashSet<ApplicationIncomeSource>();
        }

        
        public string IncomeSource1 { get; set; }

        public virtual ICollection<ApplicationIncomeSource> ApplicationIncomeSources { get; set; }
    }
}
