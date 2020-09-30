using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace LoanManagement.Models
{
    public class CreditAuthAgreement : FullAuditedEntity<long>
    {
        public bool? AgreeCreditAuthAgreement { get; set; }
    }
}
