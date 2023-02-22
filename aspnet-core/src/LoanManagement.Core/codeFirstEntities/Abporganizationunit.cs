using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Abporganizationunit
    {
        public Abporganizationunit()
        {
            InverseParent = new HashSet<Abporganizationunit>();
        }

        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public int? TenantId { get; set; }
        public long? ParentId { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }

        public virtual Abporganizationunit Parent { get; set; }
        public virtual ICollection<Abporganizationunit> InverseParent { get; set; }
    }
}
