using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class AdminNotificationtype:Entity<int>
    {
        public AdminNotificationtype()
        {
            AdminUsernotifications = new HashSet<AdminUsernotification>();
        }

        public string Type { get; set; }

        public virtual ICollection<AdminUsernotification> AdminUsernotifications { get; set; }
    }
}
