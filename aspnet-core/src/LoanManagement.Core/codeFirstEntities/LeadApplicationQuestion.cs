using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LeadApplicationQuestion:Entity<int>
    {
        
        public string Question { get; set; }
    }
}
