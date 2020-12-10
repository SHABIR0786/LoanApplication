using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.Models
{
    public class StockAndBond : Entity<long>
    {
        public string CompanyName { get; set; }
        public string AccountNumber { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Value { get; set; }
        public long ManualAssetEntryId { get; set; }

        public ManualAssetEntry ManualAssetEntry { get; set; }
    }
}
