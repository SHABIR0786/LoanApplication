using System;
using System.Collections.Generic;

namespace  LoanManagement.Features.AdminUserEnabledDevice
{
    public partial class AddAdminUserEnabledDevice
    {
        //public int UserId { get; set; }
        public string DeviceId { get; set; }
        public string BioMetricData { get; set; }
        public ulong? IsEnabled { get; set; }
    }
}
