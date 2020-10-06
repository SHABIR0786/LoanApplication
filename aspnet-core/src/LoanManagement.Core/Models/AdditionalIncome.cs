using Abp.Domain.Entities.Auditing;

namespace LoanManagement.Models
{
    public class AdditionalIncome : FullAuditedEntity<long>
    {
        public decimal? Amount { get; set; }
        public int? IncomeSourceId { get; set; }
        public int? BorrowerTypeId { get; set; }
        public long LoanApplicationId { get; set; }

        public BorrowerType BorrowerType { get; set; }
        public LoanApplication LoanApplication { get; set; }
    }
}