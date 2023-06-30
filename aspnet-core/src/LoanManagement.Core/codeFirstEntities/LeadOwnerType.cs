using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LeadOwnerType: FullAuditedEntity<int>
    {
        public string OwnerType { get; set; }
    }
}
