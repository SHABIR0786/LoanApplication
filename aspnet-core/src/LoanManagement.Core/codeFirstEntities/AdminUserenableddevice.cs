using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class AdminUserenableddevice
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string DeviceId { get; set; }
        public string BioMetricData { get; set; }
        public ulong? IsEnabled { get; set; }

        public virtual AdminUser User { get; set; }
    }
}
