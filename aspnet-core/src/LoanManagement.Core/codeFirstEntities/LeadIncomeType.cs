using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LeadIncomeType:Entity<int>
    {
        public string IncomeType { get; set; }
    }
}
