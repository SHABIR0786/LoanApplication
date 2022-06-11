using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminUserEnabledDevice;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Services.Implementation
{
    public class AdminUserEnabledDeviceService : IAdminUserEnabledDeviceService
    {
        private readonly MortgagedbContext _dbContext;
        public AdminUserEnabledDeviceService(MortgagedbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Add(AddAdminUserEnabledDevice request)
        {
            var entity = new Entities.Models.AdminUserenableddevice
            {
                BioMetricData = request.BioMetricData,
                DeviceId = request.DeviceId,
                IsEnabled = request.IsEnabled,
                UserId = request.UserId,
            };
            _dbContext.AdminUserenableddevices.Add(entity);

            _dbContext.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {

            var obj = _dbContext.AdminUserenableddevices.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.AdminUserenableddevices.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateAdminUserEnabledDevice> GetAll()
        {
            return _dbContext.AdminUserenableddevices.Select(d => new UpdateAdminUserEnabledDevice()
            {
                Id = d.Id,
                BioMetricData = d.BioMetricData,
                DeviceId = d.DeviceId,
                IsEnabled = d.IsEnabled,
                UserId = d.UserId,
            }).ToList();
        }

        public UpdateAdminUserEnabledDevice GetById(int id)
        {
            return _dbContext.AdminUserenableddevices.Where(s => s.Id == id).Select(d => new UpdateAdminUserEnabledDevice()
            {
                Id = d.Id,
                BioMetricData = d.BioMetricData,
                DeviceId = d.DeviceId,
                IsEnabled = d.IsEnabled,
                UserId = d.UserId,
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminUserEnabledDevice request)
        {
            var obj = _dbContext.AdminUserenableddevices.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.BioMetricData = request.BioMetricData;
            obj.DeviceId = request.DeviceId;
            obj.IsEnabled = request.IsEnabled;
            obj.UserId = request.UserId;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
