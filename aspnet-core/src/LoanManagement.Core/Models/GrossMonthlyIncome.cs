using Abp.Domain.Entities.Auditing;

namespace LoanManagement.Models
{
    public class GrossMonthlyIncome : FullAuditedEntity<long>
    {
        public decimal BasicIncome { get; set; }
        public decimal Overtime { get; set; }
        public decimal Bonuses { get; set; }
        public decimal Commissions { get; set; }
        public decimal DividendAndInterest { get; set; }
        public decimal NetRentalIncome { get; set; }
        public decimal Other { get; set; }
        public int BorrowerTypeId { get; set; }
        public long LoanApplicationId { get; set; }

        public BorrowerType BorrowerType { get; set; }
        public LoanApplication LoanApplication { get; set; }
    }
}
