using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class LeadAssetsDetail
    {
        public int Id { get; set; }
        public int LeadApplicationDetailPurchasingId { get; set; }
        public int? LeadApplicationDetailRefinancingId { get; set; }
        public int AssetTypeId { get; set; }
        public int LeadApplicationTypeId { get; set; }
        public string FinancialInstitution { get; set; }
        public float? Balance { get; set; }
        public int OwnerTypeId { get; set; }

        public virtual LeadAssetsType AssetType { get; set; }
        public virtual LeadApplicationDetailPurchasing LeadApplicationDetailPurchasing { get; set; }
        public virtual LeadApplicationDetailRefinancing LeadApplicationDetailRefinancing { get; set; }
        public virtual LeadApplicationType LeadApplicationType { get; set; }
        public virtual LeadOwnerType OwnerType { get; set; }
    }
}
