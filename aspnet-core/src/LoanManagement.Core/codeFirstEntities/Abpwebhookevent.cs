using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Abpwebhookevent
    {
        public Abpwebhookevent()
        {
            Abpwebhooksendattempts = new HashSet<Abpwebhooksendattempt>();
        }

        public Guid Id { get; set; }
        public string WebhookName { get; set; }
        public string Data { get; set; }
        public DateTime CreationTime { get; set; }
        public int? TenantId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }

        public virtual ICollection<Abpwebhooksendattempt> Abpwebhooksendattempts { get; set; }
    }
}
