using Abp.Application.Services;
using Abp.Dependency;
using Abp.Net.Mail;
using Abp.Notifications;
using Abp.Runtime.Session;
using Castle.Core.Logging;
using LoanManagement.Authorization.Users;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Notification
{
    public class NotificationDistributer : IRealTimeNotifier
    {
        public Task SendNotificationsAsync(UserNotification[] userNotifications)
        {
            
            throw new NotImplementedException();
        }
    }
}
