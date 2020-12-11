using Abp.Domain.Entities;
using System.Collections.Generic;

namespace LoanManagement.Models
{
    public class AssetType : Entity<long>
    {
        public string Name { get; set; }
        public List<ManualAssetEntry> ManualAssetEntries { get; set; }
    }
}
