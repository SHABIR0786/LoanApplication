using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class IncomeType: FullAuditedEntity<int>
    {
        public IncomeType()
        {
            ApplicationAdditionalEmployementIncomeDetails = new HashSet<ApplicationAdditionalEmployementIncomeDetail>();
            ApplicationEmployementIncomeDetails = new HashSet<ApplicationEmployementIncomeDetail>();
        }

       
        public string IncomeType1 { get; set; }

        public virtual ICollection<ApplicationAdditionalEmployementIncomeDetail> ApplicationAdditionalEmployementIncomeDetails { get; set; }
        public virtual ICollection<ApplicationEmployementIncomeDetail> ApplicationEmployementIncomeDetails { get; set; }
    }
}
