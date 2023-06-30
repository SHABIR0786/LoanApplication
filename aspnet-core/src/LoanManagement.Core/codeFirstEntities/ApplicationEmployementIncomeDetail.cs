using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class ApplicationEmployementIncomeDetail: FullAuditedEntity<int>
    {
        public int ApplicationEmployementDetailsId { get; set; }
        public int IncomeTypeId1b101 { get; set; }
        public float? Amount1b10 { get; set; }

        public virtual ApplicationEmployementDetail ApplicationEmployementDetails { get; set; }
        public virtual IncomeType IncomeTypeId1b101Navigation { get; set; }
    }
}
