using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class LeadIncomeType
    {
        public LeadIncomeType()
        {
            LeadRefinancingIncomeDetails = new HashSet<LeadRefinancingIncomeDetail>();
        }

        public int Id { get; set; }
        public string IncomeType { get; set; }

        public virtual ICollection<LeadRefinancingIncomeDetail> LeadRefinancingIncomeDetails { get; set; }
    }
}
