using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LeadEmployementType:Entity<int>
    {
        public string EmployementType { get; set; }
    }
}
