using Abp.Domain.Entities.Auditing;

namespace LoanManagement.Models
{
    public class HousingExpenseType : FullAuditedEntity<int>
    {
        public string Name { get; set; }
    }
}
