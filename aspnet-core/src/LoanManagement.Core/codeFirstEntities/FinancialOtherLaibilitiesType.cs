using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class FinancialOtherLaibilitiesType:Entity<int>
    {
        public FinancialOtherLaibilitiesType()
        {
            ApplicationFinancialOtherLaibilities = new HashSet<ApplicationFinancialOtherLaibility>();
        }

        
        public string FinancialOtherLaibilitiesType1 { get; set; }

        public virtual ICollection<ApplicationFinancialOtherLaibility> ApplicationFinancialOtherLaibilities { get; set; }
    }
}
