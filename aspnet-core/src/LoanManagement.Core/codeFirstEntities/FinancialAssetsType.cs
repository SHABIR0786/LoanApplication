using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class FinancialAssetsType
    {
        public FinancialAssetsType()
        {
            ApplicationFinancialOtherAssets = new HashSet<ApplicationFinancialOtherAsset>();
        }

        public int Id { get; set; }
        public string FinancialCreditType { get; set; }

        public virtual ICollection<ApplicationFinancialOtherAsset> ApplicationFinancialOtherAssets { get; set; }
    }
}
