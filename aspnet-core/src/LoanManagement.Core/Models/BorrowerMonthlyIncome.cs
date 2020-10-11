using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.Models
{
    public class BorrowerMonthlyIncome : FullAuditedEntity<long>
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Base { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Overtime { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Bonuses { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Commissions { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Dividends { get; set; }

        public BorrowerType BorrowerType { get; set; }
        public int? BorrowerTypeId { get; set; }

        public LoanApplication LoanApplication { get; set; }
        public long LoanApplicationId { get; set; }
    }
}