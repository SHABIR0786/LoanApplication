using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class LeadApplicationType
    {
        public LeadApplicationType()
        {
            LeadAssetsDetails = new HashSet<LeadAssetsDetail>();
            LeadEmployementDetails = new HashSet<LeadEmployementDetail>();
            LeadQuestionAnswers = new HashSet<LeadQuestionAnswer>();
            LeadRefinancingIncomeDetails = new HashSet<LeadRefinancingIncomeDetail>();
        }

        public int Id { get; set; }
        public string ApplicationType { get; set; }

        public virtual ICollection<LeadAssetsDetail> LeadAssetsDetails { get; set; }
        public virtual ICollection<LeadEmployementDetail> LeadEmployementDetails { get; set; }
        public virtual ICollection<LeadQuestionAnswer> LeadQuestionAnswers { get; set; }
        public virtual ICollection<LeadRefinancingIncomeDetail> LeadRefinancingIncomeDetails { get; set; }
    }
}
