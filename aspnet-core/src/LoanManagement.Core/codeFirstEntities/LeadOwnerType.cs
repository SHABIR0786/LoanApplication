using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LeadOwnerType:Entity<int>
    {
        public string OwnerType { get; set; }
    }
}
