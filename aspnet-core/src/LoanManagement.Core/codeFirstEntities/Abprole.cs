using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Abprole
    {
        public Abprole()
        {
            Abppermissions = new HashSet<Abppermission>();
            Abproleclaims = new HashSet<Abproleclaim>();
        }

        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsStatic { get; set; }
        public bool IsDefault { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Description { get; set; }

        public virtual Abpuser CreatorUser { get; set; }
        public virtual Abpuser DeleterUser { get; set; }
        public virtual Abpuser LastModifierUser { get; set; }
        public virtual ICollection<Abppermission> Abppermissions { get; set; }
        public virtual ICollection<Abproleclaim> Abproleclaims { get; set; }
    }
}
