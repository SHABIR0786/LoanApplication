using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class ApplicationIncomeSource : FullAuditedEntity<int>
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public int IncomeSourceId1e1 { get; set; }
        public float? Amount1e2 { get; set; }

        public virtual ApplicationPersonalInformation ApplicationPersonalInformation { get; set; }
        public virtual IncomeSource IncomeSourceId1e1Navigation { get; set; }
    }
}
