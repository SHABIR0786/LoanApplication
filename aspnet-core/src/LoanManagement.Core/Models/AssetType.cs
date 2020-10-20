using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace LoanManagement.Models
{
    public class AssetType : FullAuditedEntity<long>
    {
        public string Name { get; set; }
        public List<ManualAssetEntry> ManualAssetEntries { get; set; }
    }
}
