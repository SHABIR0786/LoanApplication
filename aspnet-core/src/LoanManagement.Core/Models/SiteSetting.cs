using Abp.Domain.Entities;

namespace LoanManagement.Models
{
    public class SiteSetting : Entity<int>
    {
        public string PageIdentifier { get; set; }
        public string PageName { get; set; }
        public string PageSetting { get; set; }
    }
}