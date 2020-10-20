using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.Models
{
    public class AdditionalIncome : FullAuditedEntity<long>
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Amount { get; set; }
        public int? IncomeSourceId { get; set; }
        public int? BorrowerTypeId { get; set; }
        public long LoanApplicationId { get; set; }

        public BorrowerType BorrowerType { get; set; }
        public LoanApplication LoanApplication { get; set; }
        public IncomeSource IncomeSource { get; set; }
    }
}