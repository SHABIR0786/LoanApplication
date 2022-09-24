using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Abpuserlogin
    {
        public long Id { get; set; }
        public int? TenantId { get; set; }
        public long UserId { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }

        public virtual Abpuser User { get; set; }
    }
}
