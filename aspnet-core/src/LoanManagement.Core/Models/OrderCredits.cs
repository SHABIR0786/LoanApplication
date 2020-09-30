using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace LoanManagement.Models
{
    public class OrderCredits : FullAuditedEntity<long>
    {
        public bool AgreeCreditAuthAgreement { get; set; }

    }
}