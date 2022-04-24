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
    internal class LeadApplicationQuestionsService : ILeadApplicationQuestionService
    {
        private readonly MortgagedbContext _dbContext;
        public string Add(AddLeadApplicationQuestions request)
        {
            _dbContext.LeadApplicationQuestions.Add(new Entities.Models.LeadApplicationQuestion
            {
                Question = request.Question
            });

            _dbContext.SaveChanges();
            return AppConsts.SuccessfullyInserted;
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
