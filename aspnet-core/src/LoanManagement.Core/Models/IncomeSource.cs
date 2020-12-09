using Abp.Domain.Entities;

namespace LoanManagement.Models
{
    public class IncomeSource : Entity<int>
    {
        public string Name { get; set; }
    }
}
