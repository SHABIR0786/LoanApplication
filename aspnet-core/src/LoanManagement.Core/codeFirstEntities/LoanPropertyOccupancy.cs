using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LoanPropertyOccupancy: FullAuditedEntity<int>
    {
        public string LoanPropertyOccupancy1 { get; set; }
    }
}
