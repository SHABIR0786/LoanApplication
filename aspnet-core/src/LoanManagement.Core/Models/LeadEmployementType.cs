using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class LeadEmployementType
    {
        public LeadEmployementType()
        {
            LeadEmployementDetails = new HashSet<LeadEmployementDetail>();
        }

        public int Id { get; set; }
        public string EmployementType { get; set; }

        public virtual ICollection<LeadEmployementDetail> LeadEmployementDetails { get; set; }
    }
}
