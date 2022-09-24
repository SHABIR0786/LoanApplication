using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminDisclosure;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Services.Implementation
{
    public class AdminDisclosureService : IAdminDisclosureService
    {
        private readonly LoanManagementDbContext _dbContext;
        public AdminDisclosureService(LoanManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Add(AddAdminDisclosure request)
        {
            var entity = new AdminDisclosure
            {
                Title = request.Title,
            };
            _dbContext.AdminDisclosures.Add(entity);

            _dbContext.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {

            var obj = _dbContext.AdminDisclosures.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.AdminDisclosures.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateAdminDisclosure> GetAll()
        {
            return _dbContext.AdminDisclosures.Select(d => new UpdateAdminDisclosure()
            {
                Id = d.Id,
                Title = d.Title,
            }).ToList();
        }

        public UpdateAdminDisclosure GetById(int id)
        {
            return _dbContext.AdminDisclosures.Where(s => s.Id == id).Select(d => new UpdateAdminDisclosure()
            {
                Id = d.Id,
                Title = d.Title,
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminDisclosure request)
        {
            var obj = _dbContext.AdminDisclosures.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.Title = request.Title;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
