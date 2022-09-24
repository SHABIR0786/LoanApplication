using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.LeadRefinancingIncomeDetails;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    public class LeadRefinancingIncomeDetailsService : ILeadRefinancingIncomeDetailsService
    {
        private readonly LoanManagementDbContext _dbContext;
        public LeadRefinancingIncomeDetailsService(LoanManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Add(AddLeadRefinancingIncomeDetails request)
        {
            var entity = new LeadRefinancingIncomeDetail
            {
                IncomeTypeId = request.IncomeTypeId,
                LeadApplicationDetailRefinancingId = request.LeadApplicationDetailRefinancingId,
                LeadApplicationTypeId = request.LeadApplicationTypeId,
                MonthlyAmount = request.MonthlyAmount
            };
               _dbContext.LeadRefinancingIncomeDetails.Add(entity);

            _dbContext.SaveChanges();
            return entity.Id.ToString();
        }
        public string Update(UpdateLeadRefinancingIncomeDetails request)
        {
            var obj = _dbContext.LeadRefinancingIncomeDetails.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.LeadApplicationTypeId = request.LeadApplicationTypeId;
            obj.LeadApplicationDetailRefinancingId = request.LeadApplicationDetailRefinancingId;
            obj.MonthlyAmount = request.MonthlyAmount;
            obj.IncomeTypeId = request.IncomeTypeId;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
        public string Delete(int id)
        {
            var obj = _dbContext.LeadRefinancingIncomeDetails.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.LeadRefinancingIncomeDetails.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateLeadRefinancingIncomeDetails> GetAll()
        {
            return _dbContext.LeadRefinancingIncomeDetails.Select(d => new UpdateLeadRefinancingIncomeDetails()
            {
                Id = d.Id,
                IncomeTypeId = d.IncomeTypeId,
                MonthlyAmount = d.MonthlyAmount,
                LeadApplicationDetailRefinancingId = d.LeadApplicationDetailRefinancingId,  
                LeadApplicationTypeId = d.LeadApplicationTypeId
            }).ToList();
        }

        public UpdateLeadRefinancingIncomeDetails GetById(int id)
        {
            return _dbContext.LeadRefinancingIncomeDetails.Where(s => s.Id == id).Select(d => new UpdateLeadRefinancingIncomeDetails()
            {
                Id = d.Id,
                IncomeTypeId = d.IncomeTypeId,
                MonthlyAmount = d.MonthlyAmount,
                LeadApplicationDetailRefinancingId = d.LeadApplicationDetailRefinancingId,
                LeadApplicationTypeId = d.LeadApplicationTypeId
            }).FirstOrDefault();
        }

        
    }
}
