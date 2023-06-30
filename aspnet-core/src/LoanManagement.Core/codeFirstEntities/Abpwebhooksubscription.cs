using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Abpwebhooksubscription
    {
        public Guid Id { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public int? TenantId { get; set; }
        public string WebhookUri { get; set; }
        public string Secret { get; set; }
        public bool IsActive { get; set; }
        public string Webhooks { get; set; }
        public string Headers { get; set; }
    }
}
