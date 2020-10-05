using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.Models
{
    public class AdditionalIncome : FullAuditedEntity<long>
    {
        public decimal? Amount { get; set; }
        public int? IncomeSourceId { get; set; }

        [ForeignKey("BorrowerTypeId")]
        public BorrowerType BorrowerType { get; set; }
        public int? BorrowerTypeId { get; set; }

        [ForeignKey("LoanApplicationId")]
        public LoanApplication LoanApplication { get; set; }
        public long LoanApplicationId { get; set; }
    }
}