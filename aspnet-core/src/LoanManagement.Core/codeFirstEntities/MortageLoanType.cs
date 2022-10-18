using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class MortageLoanType:Entity<int>
    {
        public string MortageLoanTypesId { get; set; }
    }
}
