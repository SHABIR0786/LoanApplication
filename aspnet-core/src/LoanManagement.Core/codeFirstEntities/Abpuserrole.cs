using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Abpuserrole
    {
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public int? TenantId { get; set; }
        public long UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Abpuser User { get; set; }
    }
}
