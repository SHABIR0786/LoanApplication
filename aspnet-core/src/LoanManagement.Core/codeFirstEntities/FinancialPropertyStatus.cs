using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class FinancialPropertyStatus
    {
        public FinancialPropertyStatus()
        {
            ApplicationFinancialRealEstates = new HashSet<ApplicationFinancialRealEstate>();
        }

        public int Id { get; set; }
        public string FinancialPropertyStatus1 { get; set; }

        public virtual ICollection<ApplicationFinancialRealEstate> ApplicationFinancialRealEstates { get; set; }
    }
}
