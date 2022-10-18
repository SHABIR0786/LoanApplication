using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LeadAssetsDetail: FullAuditedEntity<int>
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
