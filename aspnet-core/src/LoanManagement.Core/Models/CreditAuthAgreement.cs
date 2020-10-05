using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.Models
{
    public class CreditAuthAgreement : FullAuditedEntity<long>
    {
        public bool? AgreeCreditAuthAgreement { get; set; }
        [ForeignKey("LoanApplicationId")]
        public LoanApplication LoanApplication { get; set; }
        public long LoanApplicationId { get; set; }
    }
}
