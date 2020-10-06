using Abp.Domain.Entities.Auditing;

namespace LoanManagement.Models
{
    public class BorrowerMonthlyIncome : FullAuditedEntity<long>
    {
        public int? Base { get; set; }
        public int? Overtime { get; set; }
        public int? Bonuses { get; set; }
        public int? Commissions { get; set; }
        public int? Dividends { get; set; }


        public BorrowerType BorrowerType { get; set; }
        public int? BorrowerTypeId { get; set; }

        public LoanApplication LoanApplication { get; set; }
        public long LoanApplicationId { get; set; }
    }
}