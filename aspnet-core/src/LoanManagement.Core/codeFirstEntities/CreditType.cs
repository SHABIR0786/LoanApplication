using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class CreditType:Entity<int>
    {
        public CreditType()
        {
            Applications = new HashSet<Application>();
        }

        
        public string CreditType1 { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}
