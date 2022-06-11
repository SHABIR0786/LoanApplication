using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class AdminNotificationtype
    {
        public AdminNotificationtype()
        {
            AdminUsernotifications = new HashSet<AdminUsernotification>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<AdminUsernotification> AdminUsernotifications { get; set; }
    }
}
