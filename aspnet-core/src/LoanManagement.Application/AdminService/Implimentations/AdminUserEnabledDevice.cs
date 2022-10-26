using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminUserEnabledDevice;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Services.Implementation
{
    public class AdminUserEnabledDeviceService : Abp.Application.Services.ApplicationService, IAdminUserEnabledDeviceService
    {
        private readonly IRepository<AdminUserenableddevice, int> repository;

        public AdminUserEnabledDeviceService(IRepository<AdminUserenableddevice,int> repository)
        {
            this.repository = repository;
        }
        public string Add(AddAdminUserEnabledDevice request)
        {
            var entity = new AdminUserenableddevice
            {
                BioMetricData = request.BioMetricData,
                DeviceId = request.DeviceId,
                IsEnabled = request.IsEnabled,
                //UserId = request.UserId,
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

        public List<UpdateAdminUserEnabledDevice> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateAdminUserEnabledDevice()
            {
                Id = d.Id,
                BioMetricData = d.BioMetricData,
                DeviceId = d.DeviceId,
                IsEnabled = d.IsEnabled,
                //UserId = d.UserId,
            }).ToList();
        }

        public UpdateAdminUserEnabledDevice GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateAdminUserEnabledDevice()
            {
                Id = d.Id,
                BioMetricData = d.BioMetricData,
                DeviceId = d.DeviceId,
                IsEnabled = d.IsEnabled,
                //UserId = d.UserId,
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminUserEnabledDevice request)
        {
            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.BioMetricData = request.BioMetricData;
            obj.DeviceId = request.DeviceId;
            obj.IsEnabled = request.IsEnabled;
            //obj.UserId = request.UserId;

            repository.Update(obj);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
