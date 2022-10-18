using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class FinancialPropertyIntendedOccupancy:Entity<int>
    {
        public FinancialPropertyIntendedOccupancy()
        {
            ApplicationFinancialRealEstates = new HashSet<ApplicationFinancialRealEstate>();
        }


        public string FinancialPropertyIntendedOccupancy1 { get; set; }

        public virtual ICollection<ApplicationFinancialRealEstate> ApplicationFinancialRealEstates { get; set; }
    }
}
