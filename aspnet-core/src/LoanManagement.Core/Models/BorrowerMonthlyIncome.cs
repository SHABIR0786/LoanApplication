using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.Models
{
    public class BorrowerMonthlyIncome : FullAuditedEntity<long>
    {
        [Required]
        [StringLength(100)]
        public int? Base { get; set; }
        public int? Overtime { get; set; }
        public int? Bonuses { get; set; }
        public int? Commissions { get; set; }
        public int? Dividends { get; set; }

        [ForeignKey("BorrowerTypeId")]
        public BorrowerType BorrowerType { get; set; }
        public int? BorrowerTypeId { get; set; }
        [ForeignKey("LoanApplicationId")]
        public LoanApplication LoanApplication { get; set; }
        public long LoanApplicationId { get; set; }
    }
}