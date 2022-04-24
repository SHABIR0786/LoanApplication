using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class LeadTaxesType
    {
        public LeadTaxesType()
        {
            LeadEmployementDetails = new HashSet<LeadEmployementDetail>();
        }

        public int Id { get; set; }
        public string TaxesType { get; set; }

        public virtual ICollection<LeadEmployementDetail> LeadEmployementDetails { get; set; }
    }
}
