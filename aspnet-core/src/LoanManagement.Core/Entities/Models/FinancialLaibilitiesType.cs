using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class FinancialLaibilitiesType
    {
        public FinancialLaibilitiesType()
        {
            ApplicationFinancialLaibilities = new HashSet<ApplicationFinancialLaibility>();
        }

        public int Id { get; set; }
        public string FinancialLaibilitiesType1 { get; set; } = null!;

        public virtual ICollection<ApplicationFinancialLaibility> ApplicationFinancialLaibilities { get; set; }
    }
}
