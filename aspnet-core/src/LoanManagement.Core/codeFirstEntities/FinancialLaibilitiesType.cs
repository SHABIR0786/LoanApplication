using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class FinancialLaibilitiesType:Entity<int>
    {
        public FinancialLaibilitiesType()
        {
            ApplicationFinancialLaibilities = new HashSet<ApplicationFinancialLaibility>();
        }

        
        public string FinancialLaibilitiesType1 { get; set; }

        public virtual ICollection<ApplicationFinancialLaibility> ApplicationFinancialLaibilities { get; set; }
    }
}
