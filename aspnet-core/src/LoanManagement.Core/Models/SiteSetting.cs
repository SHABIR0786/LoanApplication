using Abp.Domain.Entities.Auditing;

namespace LoanManagement.Models
{
    public class SiteSetting : FullAuditedEntity<int>
    {
        public string PageIdentifier { get; set; }
        public string PageName { get; set; }
        public string PageSetting { get; set; }
    }
}