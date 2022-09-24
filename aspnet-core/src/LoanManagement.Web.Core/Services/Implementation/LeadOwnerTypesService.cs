using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.LeadOwnerTypes;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    public class LeadOwnerTypesService : ILeadOwnerTypesService
    {
        private readonly LoanManagementDbContext _dbContext;
        public LeadOwnerTypesService(LoanManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Add(AddLeadOwnerTypes request)
        {
            var entity = new LeadOwnerType
            {
                OwnerType = request.OwnerType
            };
               _dbContext.LeadOwnerTypes.Add(entity);

            _dbContext.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {
            var obj = _dbContext.LeadOwnerTypes.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.LeadOwnerTypes.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateLeadOwnerTypes> GetAll()
        {
            return _dbContext.LeadOwnerTypes.Select(d => new UpdateLeadOwnerTypes()
            {
                Id = d.Id,
                OwnerType = d.OwnerType
            }).ToList();
        }

        public UpdateLeadOwnerTypes GetById(int id)
        {
            return _dbContext.LeadOwnerTypes.Where(s => s.Id == id).Select(d => new UpdateLeadOwnerTypes()
            {
                Id = d.Id,
                OwnerType = d.OwnerType
            }).FirstOrDefault();
        }

        public string Update(UpdateLeadOwnerTypes request)
        {

            var obj = _dbContext.LeadOwnerTypes.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.OwnerType = request.OwnerType;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
