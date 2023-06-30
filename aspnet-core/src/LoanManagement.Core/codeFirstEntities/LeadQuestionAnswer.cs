using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LeadQuestionAnswer: FullAuditedEntity<int>
    {
        public int LeadApplicationDetailPurchasingId { get; set; }
        public int? LeadApplicationDetailRefinancingId { get; set; }
        public int? LeadApplicationTypeId { get; set; }
        public int QuestionId { get; set; }
        public ulong? IsYes { get; set; }
    }
}
