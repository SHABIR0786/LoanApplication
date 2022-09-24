using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class FinancialLaibilitiesType
    {
        public FinancialLaibilitiesType()
        {
            ApplicationFinancialLaibilities = new HashSet<ApplicationFinancialLaibility>();
        }

        public int Id { get; set; }
        public string FinancialLaibilitiesType1 { get; set; }

        public virtual ICollection<ApplicationFinancialLaibility> ApplicationFinancialLaibilities { get; set; }
    }
}
