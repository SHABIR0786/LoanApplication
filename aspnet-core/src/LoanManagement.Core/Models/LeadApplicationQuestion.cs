using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class LeadApplicationQuestion
    {
        public LeadApplicationQuestion()
        {
            LeadQuestionAnswers = new HashSet<LeadQuestionAnswer>();
        }

        public int Id { get; set; }
        public string Question { get; set; }

        public virtual ICollection<LeadQuestionAnswer> LeadQuestionAnswers { get; set; }
    }
}
