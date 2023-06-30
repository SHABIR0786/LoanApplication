using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class FinancialAccountType: FullAuditedEntity<int>
    {
        public FinancialAccountType()
        {
            ApplicationFinancialAssets = new HashSet<ApplicationFinancialAsset>();
        }

       
        public string FinancialAccountType1 { get; set; }

        public virtual ICollection<ApplicationFinancialAsset> ApplicationFinancialAssets { get; set; }
    }
}
