using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Abpentitychange
    {
        public Abpentitychange()
        {
            Abpentitypropertychanges = new HashSet<Abpentitypropertychange>();
        }

        public long Id { get; set; }
        public DateTime ChangeTime { get; set; }
        public byte ChangeType { get; set; }
        public long EntityChangeSetId { get; set; }
        public string EntityId { get; set; }
        public string EntityTypeFullName { get; set; }
        public int? TenantId { get; set; }

        public virtual Abpentitychangeset EntityChangeSet { get; set; }
        public virtual ICollection<Abpentitypropertychange> Abpentitypropertychanges { get; set; }
    }
}
