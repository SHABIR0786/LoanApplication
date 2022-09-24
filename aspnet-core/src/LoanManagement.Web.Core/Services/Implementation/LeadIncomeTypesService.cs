using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.LeadIncomeTypes;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    public class LeadIncomeTypesService : ILeadIncomeTypesService
    {
        private readonly LoanManagementDbContext _dbContext;
        public LeadIncomeTypesService(LoanManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Add(AddLeadIncomeTypes request)
        {
            var entity = new LeadIncomeType
            {
                IncomeType = request.IncomeType,
            };
               _dbContext.LeadIncomeTypes.Add(entity);

            _dbContext.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {
            var obj = _dbContext.LeadIncomeTypes.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.LeadIncomeTypes.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateLeadIncomeTypes> GetAll()
        {
            return _dbContext.LeadIncomeTypes.Select(d => new UpdateLeadIncomeTypes()
            {
                Id = d.Id,
                IncomeType = d.IncomeType
            }).ToList();
        }

        public UpdateLeadIncomeTypes GetById(int id)
        {
            return _dbContext.LeadIncomeTypes.Where(s => s.Id == id).Select(d => new UpdateLeadIncomeTypes()
            {
                Id = d.Id,
                IncomeType = d.IncomeType
            }).FirstOrDefault();
        }

        public string Update(UpdateLeadIncomeTypes request)
        {

            var obj = _dbContext.LeadIncomeTypes.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.IncomeType = request.IncomeType;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
