using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminUserNotification;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Services.Implementation
{
    public class AdminUserNotificationService : IAdminUserNotificationService
    {
        private readonly MortgagedbContext _dbContext;
        public AdminUserNotificationService(MortgagedbContext dbContext)
        {
            _dbContext = dbContext;
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

            _dbContext.SaveChanges();
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
