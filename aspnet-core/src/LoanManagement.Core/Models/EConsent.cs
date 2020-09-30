using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace LoanManagement.Models
{
    public class EConsent : FullAuditedEntity<long>
    {
        public bool AgreeEConsent { get; set; }
    }
}