using Abp.Domain.Entities.Auditing;

namespace LoanManagement.Models
{
    public class CombinedMonthlyHousingExpense : FullAuditedEntity<long>
    {
        public decimal Rental { get; set; }
        public decimal FirstMortage { get; set; }
        public decimal OtherMortage { get; set; }
        public decimal HazardInsurance { get; set; }
        public decimal RealEstateTaxes { get; set; }
        public decimal MortgageInsurance { get; set; }
        public decimal HomeOwnerAssociationDue { get; set; }
        public decimal Other { get; set; }
        public int HousingExpenseTypeId { get; set; }
        public long LoanApplicationId { get; set; }

        public HousingExpenseType HousingExpenseType { get; set; }
        public LoanApplication LoanApplication { get; set; }
    }
}
