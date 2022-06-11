using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class LeadQuestionAnswer
    {
        public int Id { get; set; }
        public int LeadApplicationDetailPurchasingId { get; set; }
        public int? LeadApplicationDetailRefinancingId { get; set; }
        public int? LeadApplicationTypeId { get; set; }
        public int QuestionId { get; set; }
        public ulong? IsYes { get; set; }

        public virtual LeadApplicationDetailPurchasing LeadApplicationDetailPurchasing { get; set; }
        public virtual LeadApplicationDetailRefinancing LeadApplicationDetailRefinancing { get; set; }
        public virtual LeadApplicationType LeadApplicationType { get; set; }
        public virtual LeadApplicationQuestion Question { get; set; }
    }
}
