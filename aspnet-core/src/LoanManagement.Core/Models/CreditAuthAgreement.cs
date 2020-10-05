using Abp.Domain.Entities.Auditing;

namespace LoanManagement.Models
{
    public class CreditAuthAgreement : FullAuditedEntity<long>
    {
        public bool? AgreeCreditAuthAgreement { get; set; }
    }
}
