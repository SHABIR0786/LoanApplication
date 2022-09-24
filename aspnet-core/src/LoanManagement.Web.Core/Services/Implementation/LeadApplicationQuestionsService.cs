using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.LeadApplicationQuestions;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    public class LeadApplicationQuestionsService : ILeadApplicationQuestionService
    {
        private readonly LoanManagementDbContext _dbContext;
        public LeadApplicationQuestionsService(LoanManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Add(AddLeadApplicationQuestions request)
        {
            var entity = new LeadApplicationQuestion
            {
                Question = request.Question
            };
            _dbContext.LeadApplicationQuestions.Add(entity);

            _dbContext.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {
            
            var obj = _dbContext.LeadApplicationQuestions.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.LeadApplicationQuestions.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateLeadApplicationQuestions> GetAll()
        {
            return _dbContext.LeadApplicationQuestions.Select(d => new UpdateLeadApplicationQuestions()
            {
                Id = d.Id,
                Question = d.Question,
            }).ToList();
        }

        public UpdateLeadApplicationQuestions GetById(int id)
        {
            return _dbContext.LeadApplicationQuestions.Where(s => s.Id == id).Select(d => new UpdateLeadApplicationQuestions()
            {
                Id = d.Id,
                Question = d.Question,
            }).FirstOrDefault();
        }

        public string Update(UpdateLeadApplicationQuestions request)
        {
            var obj = _dbContext.LeadApplicationQuestions.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.Question = request.Question;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
