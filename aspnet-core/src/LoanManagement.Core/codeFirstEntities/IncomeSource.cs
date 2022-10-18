using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class IncomeSource: FullAuditedEntity<int>
    {
        public IncomeSource()
        {
            ApplicationIncomeSources = new HashSet<ApplicationIncomeSource>();
        }

        
        public string IncomeSource1 { get; set; }

        public virtual ICollection<ApplicationIncomeSource> ApplicationIncomeSources { get; set; }
    }
}
