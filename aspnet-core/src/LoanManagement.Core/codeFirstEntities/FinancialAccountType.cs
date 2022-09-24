using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class FinancialAccountType
    {
        public FinancialAccountType()
        {
            ApplicationFinancialAssets = new HashSet<ApplicationFinancialAsset>();
        }

        public int Id { get; set; }
        public string FinancialAccountType1 { get; set; }

        public virtual ICollection<ApplicationFinancialAsset> ApplicationFinancialAssets { get; set; }
    }
}
