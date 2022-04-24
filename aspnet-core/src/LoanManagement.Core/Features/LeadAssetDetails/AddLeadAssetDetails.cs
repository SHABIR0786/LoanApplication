using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.LeadAssetDetails
{
    public class AddLeadAssetDetails
    {
        public int LeadApplicationDetailPurchasingId { get; set; }
        public int? LeadApplicationDetailRefinancingId { get; set; }
        public int AssetTypeId { get; set; }
        public int LeadApplicationTypeId { get; set; }
        public string FinancialInstitution { get; set; }
        public float? Balance { get; set; }
        public int OwnerTypeId { get; set; }
    }
}
