using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Abpwebhooksendattempt
    {
        public Guid Id { get; set; }
        public Guid WebhookEventId { get; set; }
        public Guid WebhookSubscriptionId { get; set; }
        public string Response { get; set; }
        public int? ResponseStatusCode { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public int? TenantId { get; set; }

        public virtual Abpwebhookevent WebhookEvent { get; set; }
    }
}
