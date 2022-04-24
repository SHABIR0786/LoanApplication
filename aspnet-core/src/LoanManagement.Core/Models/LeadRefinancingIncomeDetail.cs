using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class LeadRefinancingIncomeDetail
    {
        public int Id { get; set; }
        public int? LeadApplicationDetailRefinancingId { get; set; }
        public int? LeadApplicationTypeId { get; set; }
        public int IncomeTypeId { get; set; }
        public float? MonthlyAmount { get; set; }

        public virtual LeadIncomeType IncomeType { get; set; }
        public virtual LeadApplicationDetailRefinancing LeadApplicationDetailRefinancing { get; set; }
        public virtual LeadApplicationType LeadApplicationType { get; set; }
    }
}
