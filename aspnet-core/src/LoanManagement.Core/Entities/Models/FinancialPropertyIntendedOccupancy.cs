using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class FinancialPropertyIntendedOccupancy
    {
        public FinancialPropertyIntendedOccupancy()
        {
            ApplicationFinancialRealEstates = new HashSet<ApplicationFinancialRealEstate>();
        }

        public int Id { get; set; }
        public string FinancialPropertyIntendedOccupancy1 { get; set; } = null!;

        public virtual ICollection<ApplicationFinancialRealEstate> ApplicationFinancialRealEstates { get; set; }
    }
}
