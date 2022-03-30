using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class FinancialAccountType
    {
        public FinancialAccountType()
        {
            ApplicationFinancialAssets = new HashSet<ApplicationFinancialAsset>();
        }

        public int Id { get; set; }
        public string FinancialAccountType1 { get; set; } = null!;

        public virtual ICollection<ApplicationFinancialAsset> ApplicationFinancialAssets { get; set; }
    }
}
