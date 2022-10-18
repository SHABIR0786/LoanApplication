using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminNotificationType;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Services.Implementation
{
    public class AdminNotificationTypeService : Abp.Application.Services.ApplicationService, IAdminNotificationTypeService
    {
        private readonly IRepository<AdminNotificationtype, int> repository;

        public AdminNotificationTypeService(IRepository<AdminNotificationtype,int> repository)
        {
            
            this.repository = repository;
        }
        public string Add(AddAdminNotificationType request)
        {
            var entity = new AdminNotificationtype
            {
                Type = request.Type,
            };
            repository.Insert(entity);

            UnitOfWorkManager.Current.SaveChanges();
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
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateAdminNotificationType> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateAdminNotificationType()
            {
                Id = d.Id,
                Type = d.Type,
            }).ToList();
        }

        public UpdateAdminNotificationType GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateAdminNotificationType()
            {
                Id = d.Id,
                Type = d.Type,
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminNotificationType request)
        {
            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.Type = request.Type;

            repository.Update(obj);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
