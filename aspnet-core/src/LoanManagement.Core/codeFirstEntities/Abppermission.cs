using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Abppermission
    {
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public bool IsGranted { get; set; }
        public string Discriminator { get; set; }
        public int? RoleId { get; set; }
        public long? UserId { get; set; }

        public virtual Abprole Role { get; set; }
        public virtual Abpuser User { get; set; }
    }
}
