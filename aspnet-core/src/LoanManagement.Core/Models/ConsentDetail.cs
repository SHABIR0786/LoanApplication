using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.Models
{
    public class ConsentDetail : FullAuditedEntity<long>
    {
        public bool? AgreeEConsent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [ForeignKey("LoanApplicationId")]
        public LoanApplication LoanApplication { get; set; }
        public long LoanApplicationId { get; set; }
    }
}
