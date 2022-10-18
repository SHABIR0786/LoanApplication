using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LeadApplicationQuestion: FullAuditedEntity<int>
    {
        
        public string Question { get; set; }
    }
}
