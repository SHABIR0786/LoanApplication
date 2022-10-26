using Abp.AspNetCore.SignalR.Hubs;
using Abp.AspNetCore.SignalR.Notifications;
using Abp.Domain.Repositories;
using Abp.Notifications;
using Abp.RealTime;
using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminUserNotification;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace LoanManagement.Services.Implementation
{
    public class AdminUserNotificationService :  IAdminUserNotificationService
    {
        private readonly IRepository<AdminUsernotification, int> repository;
        private readonly IOnlineClientManager _onlineClientManager;
        private readonly IHubContext<AbpCommonHub> _hubContext;
        public AdminUserNotificationService(IRepository<AdminUsernotification,int> repository, IOnlineClientManager onlineClientManager, IHubContext<AbpCommonHub> hubContext)
        {
            this.repository = repository;
            _onlineClientManager = onlineClientManager;
            _hubContext = hubContext;
        }
        public string Add(AddAdminUserNotification request)
        {
            var entity = new AdminUsernotification
            {
                Content = request.Content,
                Date = request.Date,
                IsSeen = request.IsSeen,
                NotificationTypeId = request.NotificationTypeId,
                Subject = request.Subject,
                //UserId = request.UserId
            };
            repository.Insert(entity);

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

            var obj = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            repository.Delete(obj);
            //UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateAdminUserNotification> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateAdminUserNotification()
            {
                Id = d.Id,
                Content = d.Content,
                Date = d.Date,
                IsSeen = d.IsSeen,
                NotificationTypeId = d.NotificationTypeId,
                Subject = d.Subject,
                //UserId = d.UserId,
            }).ToList();
        }

        public UpdateAdminUserNotification GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateAdminUserNotification()
            {
                Id = d.Id,
                Content = d.Content,
                Date = d.Date,
                IsSeen = d.IsSeen,
                NotificationTypeId = d.NotificationTypeId,
                Subject = d.Subject,
                //UserId = d.UserId,
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminUserNotification request)
        {
            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.Content = request.Content;
            obj.Date = request.Date;
            obj.IsSeen = request.IsSeen;
            obj.NotificationTypeId = request.NotificationTypeId;
            obj.Subject = request.Subject;
            //obj.UserId = request.UserId;

            repository.Update(obj);
            //UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
