using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.LeadQuestionAnswers;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    public class LeadQuestionAnswersService : ILeadQuestionAnswersService
    {
        private readonly LoanManagementDbContext _dbContext;
        public LeadQuestionAnswersService(LoanManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Add(AddLeadQuestionAnswers request)
        {
            var entity = new LeadQuestionAnswer
            {
                LeadApplicationTypeId = request.LeadApplicationTypeId,
                LeadApplicationDetailRefinancingId = request.LeadApplicationDetailRefinancingId,
                IsYes = request.IsYes,
                LeadApplicationDetailPurchasingId = request.LeadApplicationDetailPurchasingId,
                QuestionId = request.QuestionId,
            };
            _dbContext.LeadQuestionAnswers.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {
            var obj = _dbContext.LeadQuestionAnswers.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.LeadQuestionAnswers.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateLeadQuestionAnswers> GetAll()
        {
            return _dbContext.LeadQuestionAnswers.Select(d => new UpdateLeadQuestionAnswers()
            {
                Id = d.Id,
                QuestionId = d.QuestionId,
                LeadApplicationTypeId = d.LeadApplicationTypeId,
                IsYes = d.IsYes,
                LeadApplicationDetailPurchasingId = d.LeadApplicationDetailPurchasingId,
                LeadApplicationDetailRefinancingId = d.LeadApplicationDetailRefinancingId,
            }).ToList();
        }

        public UpdateLeadQuestionAnswers GetById(int id)
        {
            return _dbContext.LeadQuestionAnswers.Where(s => s.Id == id).Select(d => new UpdateLeadQuestionAnswers()
            {
                Id = d.Id,
                QuestionId = d.QuestionId,
                LeadApplicationTypeId = d.LeadApplicationTypeId,
                IsYes = d.IsYes,
                LeadApplicationDetailPurchasingId = d.LeadApplicationDetailPurchasingId,
                LeadApplicationDetailRefinancingId = d.LeadApplicationDetailRefinancingId,
            }).FirstOrDefault();
        }

        public string Update(UpdateLeadQuestionAnswers request)
        {

            var obj = _dbContext.LeadQuestionAnswers.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.LeadApplicationTypeId = request.LeadApplicationTypeId;
            obj.LeadApplicationDetailRefinancingId = request.LeadApplicationDetailRefinancingId;
            obj.IsYes = request.IsYes;
            obj.LeadApplicationDetailPurchasingId = request.LeadApplicationDetailPurchasingId;
            obj.QuestionId = request.QuestionId;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
