using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LeadRefinancingIncomeDetail
    {
        public int Id { get; set; }
        public int? LeadApplicationDetailRefinancingId { get; set; }
        public int? LeadApplicationTypeId { get; set; }
        public int IncomeTypeId { get; set; }
        public float? MonthlyAmount { get; set; }
    }
}
