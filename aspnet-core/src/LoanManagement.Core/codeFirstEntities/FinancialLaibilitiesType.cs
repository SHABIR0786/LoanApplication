using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class FinancialLaibilitiesType: FullAuditedEntity<int>
    {
        public FinancialLaibilitiesType()
        {
            ApplicationFinancialLaibilities = new HashSet<ApplicationFinancialLaibility>();
        }

        
        public string FinancialLaibilitiesType1 { get; set; }

        public virtual ICollection<ApplicationFinancialLaibility> ApplicationFinancialLaibilities { get; set; }
    }
}
