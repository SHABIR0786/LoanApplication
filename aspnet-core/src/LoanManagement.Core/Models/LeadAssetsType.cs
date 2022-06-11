using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class LeadAssetsType
    {
        public LeadAssetsType()
        {
            LeadAssetsDetails = new HashSet<LeadAssetsDetail>();
        }

        public int Id { get; set; }
        public string AssetsType { get; set; }

        public virtual ICollection<LeadAssetsDetail> LeadAssetsDetails { get; set; }
    }
}
