using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.LeadApplicationTypes;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    public class LeadApplicationTypesService : ILeadApplicationTypesService
    {
        private readonly LoanManagementDbContext _dbContext;
        public LeadApplicationTypesService(LoanManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Add(AddLeadApplicationType request)
        {
            var entity = new LeadApplicationType { ApplicationType = request.ApplicationType };
            _dbContext.LeadApplicationTypes.Add(entity);

            _dbContext.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {

            var obj = _dbContext.LeadApplicationTypes.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.LeadApplicationTypes.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateLeadApplicationType> GetAll()
        {
            return _dbContext.LeadApplicationTypes.Select(d => new UpdateLeadApplicationType()
            {
                Id = d.Id,
                ApplicationType = d.ApplicationType
            }).ToList();
        }

        public UpdateLeadApplicationType GetById(int id)
        {
            return _dbContext.LeadApplicationTypes.Where(s => s.Id == id).Select(d => new UpdateLeadApplicationType()
            {
                Id = d.Id,
                ApplicationType = d.ApplicationType
            }).FirstOrDefault();
        }

        public string Update(UpdateLeadApplicationType request)
        {
            var obj = _dbContext.LeadApplicationTypes.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.ApplicationType = request.ApplicationType;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
