using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LeadEmployementType: FullAuditedEntity<int>
    {
        public string EmployementType { get; set; }
    }
}
