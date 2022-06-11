using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminNotificationType;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Services.Implementation
{
    public class AdminNotificationTypeService : IAdminNotificationTypeService
    {
        private readonly MortgagedbContext _dbContext;
        public AdminNotificationTypeService(MortgagedbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Add(AddAdminNotificationType request)
        {
            var entity = new Entities.Models.AdminNotificationtype
            {
                Type = request.Type,
            };
            _dbContext.AdminNotificationtypes.Add(entity);

            _dbContext.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {

            var obj = _dbContext.AdminNotificationtypes.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.AdminNotificationtypes.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateAdminNotificationType> GetAll()
        {
            return _dbContext.AdminNotificationtypes.Select(d => new UpdateAdminNotificationType()
            {
                Id = d.Id,
                Type = d.Type,
            }).ToList();
        }

        public UpdateAdminNotificationType GetById(int id)
        {
            return _dbContext.AdminNotificationtypes.Where(s => s.Id == id).Select(d => new UpdateAdminNotificationType()
            {
                Id = d.Id,
                Type = d.Type,
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminNotificationType request)
        {
            var obj = _dbContext.AdminNotificationtypes.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.Type = request.Type;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
