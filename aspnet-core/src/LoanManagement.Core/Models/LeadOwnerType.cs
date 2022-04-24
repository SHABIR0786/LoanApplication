using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class LeadOwnerType
    {
        public LeadOwnerType()
        {
            LeadAssetsDetails = new HashSet<LeadAssetsDetail>();
        }

        public int Id { get; set; }
        public string OwnerType { get; set; }

        public virtual ICollection<LeadAssetsDetail> LeadAssetsDetails { get; set; }
    }
}
