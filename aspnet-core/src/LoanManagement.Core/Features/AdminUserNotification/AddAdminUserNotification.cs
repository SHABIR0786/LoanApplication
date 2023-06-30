using System;
using System.Collections.Generic;

namespace  LoanManagement.Features.AdminUserNotification
{
    public partial class AddAdminUserNotification
    {
       // public int UserId { get; set; }
        public int NotificationTypeId { get; set; }
        public DateTime? Date { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public ulong? IsSeen { get; set; }
    }
}
