using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class AdminUsernotification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int NotificationTypeId { get; set; }
        public DateTime? Date { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public ulong? IsSeen { get; set; }

        public virtual AdminNotificationtype NotificationType { get; set; }
        public virtual AdminUser User { get; set; }
    }
}
