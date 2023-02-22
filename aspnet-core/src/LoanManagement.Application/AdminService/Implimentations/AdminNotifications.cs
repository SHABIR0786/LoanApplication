using Abp.Domain.Entities;
using Abp.Domain.Uow;
using Abp.Notifications;
using Abp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.AspNetCore.SignalR.Hubs;
using Abp.RealTime;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.SignalR;
using Abp.Timing;
using Abp.Extensions;

namespace LoanManagement.AdminService.Implimentations
{
    public class AdminNotifications : ApplicationService
    {
        private readonly INotificationPublisher notificationPublisher;
        private readonly IUserNotificationManager userNotificationManager;
        private readonly IOnlineClientManager onlineClientManager;
        private readonly IHubContext<AbpCommonHub> hubContext;
        private readonly IAbpSession session;
        private readonly INotificationStore store;
        private readonly IGuidGenerator guidGenerator;
        public AdminNotifications(INotificationPublisher notificationPublisher, IUserNotificationManager userNotificationManager
            , IOnlineClientManager onlineClientManager, IHubContext<AbpCommonHub> hubContext, IAbpSession session
            , INotificationStore store, IGuidGenerator guidGenerator)
        {
            this.notificationPublisher = notificationPublisher;
            this.userNotificationManager = userNotificationManager;
            this.onlineClientManager = onlineClientManager;
            this.hubContext = hubContext;
            this.session = session;
            this.store = store;
            this.guidGenerator = guidGenerator;
        }
        public async Task MarkAsRead(string id)
        {
            var guid = new Guid(id);
            // userNotificationManager.UpdateUserNotificationState(session.TenantId, guid, UserNotificationState.Read);
        }
        public async Task PublishNotification(string message="")
        {
            try
            {
                if (message.IsNullOrEmpty())
                {
                    message = "This is a test notification, created at " + Clock.Now;
                }

                var defaultTenantAdmin = new UserIdentifier(1, 2);
                var hostAdmin = new UserIdentifier(null, 1);

                await notificationPublisher.PublishAsync(
                    "App.SimpleMessage",
                    new MessageNotificationData(message),
                    severity: NotificationSeverity.Info,
                    userIds: new[] { defaultTenantAdmin, hostAdmin }
                );
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<UserNotification> GetNotifications()
        {
            var defaultTenantAdmin = new UserIdentifier(1, 2);
            return userNotificationManager.GetUserNotifications(defaultTenantAdmin, UserNotificationState.Unread);
        }
    }
}
