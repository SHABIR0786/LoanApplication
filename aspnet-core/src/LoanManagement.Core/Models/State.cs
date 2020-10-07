using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace LoanManagement.Models
{
    public class State : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public List<ManualAssetEntry> ManualAssetEntries { get; set; }
    }
}
