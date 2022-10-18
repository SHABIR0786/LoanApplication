using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class FinancialPropertyStatus:Entity<int>
    {
        public FinancialPropertyStatus()
        {
            ApplicationFinancialRealEstates = new HashSet<ApplicationFinancialRealEstate>();
        }

        
        public string FinancialPropertyStatus1 { get; set; }

        public virtual ICollection<ApplicationFinancialRealEstate> ApplicationFinancialRealEstates { get; set; }
    }
}
