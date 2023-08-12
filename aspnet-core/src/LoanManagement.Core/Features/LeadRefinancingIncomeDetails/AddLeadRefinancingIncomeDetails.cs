using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.LeadRefinancingIncomeDetails
{
    public class AddLeadRefinancingIncomeDetails
    {
        public int? LeadApplicationDetailRefinancingId { get; set; }
        public int? LeadApplicationDetailPurchasingId { get; set; }
        public int? LeadApplicationTypeId { get; set; }
        public int IncomeTypeId { get; set; }
        public float? MonthlyAmount { get; set; }

    }
}
