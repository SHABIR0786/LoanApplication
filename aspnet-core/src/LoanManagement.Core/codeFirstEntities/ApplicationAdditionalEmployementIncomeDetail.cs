using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class ApplicationAdditionalEmployementIncomeDetail: FullAuditedEntity<int>
    {
        public int ApplicationAdditionalEmployementDetails { get; set; }
        public int IncomeTypeId { get; set; }
        public float? Amount { get; set; }

        public virtual ApplicationAdditionalEmployementDetail ApplicationAdditionalEmployementDetailsNavigation { get; set; }
        public virtual IncomeType IncomeType { get; set; }
    }
}
