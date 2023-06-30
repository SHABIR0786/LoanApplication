using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LoanPropertyGiftType: FullAuditedEntity<int>
    {
        public string LoanPropertyGiftType1 { get; set; }
    }
}
