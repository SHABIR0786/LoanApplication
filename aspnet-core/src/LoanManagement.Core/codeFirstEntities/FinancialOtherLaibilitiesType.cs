using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class FinancialOtherLaibilitiesType
    {
        public FinancialOtherLaibilitiesType()
        {
            ApplicationFinancialOtherLaibilities = new HashSet<ApplicationFinancialOtherLaibility>();
        }

        public int Id { get; set; }
        public string FinancialOtherLaibilitiesType1 { get; set; }

        public virtual ICollection<ApplicationFinancialOtherLaibility> ApplicationFinancialOtherLaibilities { get; set; }
    }
}
