using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LeadApplicationType:Entity<int>
    {
        
        public string ApplicationType { get; set; }
    }
}
