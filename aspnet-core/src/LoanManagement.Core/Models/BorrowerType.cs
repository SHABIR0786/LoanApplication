using Abp.Domain.Entities;

namespace LoanManagement.Models
{
    public class BorrowerType: Entity<int>
    {
        public string Name { get; set; }
    }
}
