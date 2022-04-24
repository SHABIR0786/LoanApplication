using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.LeadQuestionAnswers
{
    public class AddLeadQuestionAnswers
    {
        public int LeadApplicationDetailPurchasingId { get; set; }
        public int? LeadApplicationDetailRefinancingId { get; set; }
        public int? LeadApplicationTypeId { get; set; }
        public int QuestionId { get; set; }
        public ulong? IsYes { get; set; }
    }
}
