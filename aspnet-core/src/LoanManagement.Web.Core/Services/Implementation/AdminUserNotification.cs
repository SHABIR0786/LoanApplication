using Abp.AspNetCore.SignalR.Hubs;
using Abp.AspNetCore.SignalR.Notifications;
using Abp.Notifications;
using Abp.RealTime;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminUserNotification;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace LoanManagement.Services.Implementation
{
    public class AdminUserNotificationService : IAdminUserNotificationService
    {
        private readonly MortgagedbContext _dbContext;
        private readonly IOnlineClientManager _onlineClientManager;
        private readonly IHubContext<AbpCommonHub> _hubContext;
        public AdminUserNotificationService(MortgagedbContext dbContext, IOnlineClientManager onlineClientManager, IHubContext<AbpCommonHub> hubContext)
        {
            _dbContext = dbContext;
            _onlineClientManager = onlineClientManager;
            _hubContext = hubContext;
        }
        public string Add(AddAdminUserNotification request)
        {
            var entity = new Entities.Models.AdminUsernotification
            {
                Content = request.Content,
                Date = request.Date,
                IsSeen = request.IsSeen,
                NotificationTypeId = request.NotificationTypeId,
                Subject = request.Subject,
                UserId = request.UserId
            };
            _dbContext.AdminUsernotifications.Add(entity);

           // _dbContext.SaveChanges();
            var serializeData = JsonSerializer.Serialize(entity);

            UserNotification[] userNotifications = {new UserNotification
            {
                Notification = new TenantNotification
                {
                    Data = new MessageNotificationData(serializeData),
                    TenantId = 1,
                    Severity = NotificationSeverity.Info,
                    NotificationName = "abp.notifications.received",
                    EntityTypeName = "LoanManagement.Features.AdminUserNotification.AddAdminUserNotification"
                },
                TenantId = 1,
                UserId = 2,
                State = request.IsSeen == 0? UserNotificationState.Unread:UserNotificationState.Read
            } };

            var notifier = new SignalRRealTimeNotifier(_onlineClientManager, _hubContext);
            notifier.SendNotificationsAsync(userNotifications);
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {

            var obj = _dbContext.AdminUsernotifications.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.AdminUsernotifications.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateAdminUserNotification> GetAll()
        {
            return _dbContext.AdminUsernotifications.Select(d => new UpdateAdminUserNotification()
            {
                Id = d.Id,
                Content = d.Content,
                Date = d.Date,
                IsSeen = d.IsSeen,
                NotificationTypeId = d.NotificationTypeId,
                Subject = d.Subject,
                UserId = d.UserId,
            }).ToList();
        }

        public UpdateAdminUserNotification GetById(int id)
        {
            return _dbContext.AdminUsernotifications.Where(s => s.Id == id).Select(d => new UpdateAdminUserNotification()
            {
                Id = d.Id,
                Content = d.Content,
                Date = d.Date,
                IsSeen = d.IsSeen,
                NotificationTypeId = d.NotificationTypeId,
                Subject = d.Subject,
                UserId = d.UserId,
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminUserNotification request)
        {
            var obj = _dbContext.AdminUsernotifications.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.Content = request.Content;
            obj.Date = request.Date;
            obj.IsSeen = request.IsSeen;
            obj.NotificationTypeId = request.NotificationTypeId;
            obj.Subject = request.Subject;
            obj.UserId = request.UserId;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
