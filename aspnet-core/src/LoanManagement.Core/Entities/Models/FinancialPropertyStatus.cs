using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class FinancialPropertyStatus
    {
        public FinancialPropertyStatus()
        {
            ApplicationFinancialRealEstates = new HashSet<ApplicationFinancialRealEstate>();
        }

        public int Id { get; set; }
        public string FinancialPropertyStatus1 { get; set; } = null!;

        public virtual ICollection<ApplicationFinancialRealEstate> ApplicationFinancialRealEstates { get; set; }
    }
}
