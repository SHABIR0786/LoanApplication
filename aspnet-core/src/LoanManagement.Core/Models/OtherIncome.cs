using Abp.Domain.Entities.Auditing;

namespace LoanManagement.Models
{
    public class OtherIncome : FullAuditedEntity<long>
    {
        public int BorrowerTypeId { get; set; }
        public string Type { get; set; }
        public decimal MonthlyAmount { get; set; }
        public long LoanApplicationId { get; set; }

        public LoanApplication LoanApplication { get; set; }
    }
}
