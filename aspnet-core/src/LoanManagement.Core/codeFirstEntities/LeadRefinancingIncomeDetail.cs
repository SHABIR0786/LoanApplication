using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LeadRefinancingIncomeDetail: FullAuditedEntity<int>
    {
        public int? LeadApplicationDetailRefinancingId { get; set; }
        public int? LeadApplicationDetailPurchasingId { get; set; }
        public int? LeadApplicationTypeId { get; set; }
        public int IncomeTypeId { get; set; }
        public float? MonthlyAmount { get; set; }
    }
}
