using Abp.Domain.Repositories;
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
    public class LeadApplicationQuestionsService : Abp.Application.Services.ApplicationService, ILeadApplicationQuestionService
    {
        private readonly IRepository<LeadApplicationQuestion, int> repository;

        public LeadApplicationQuestionsService(IRepository<LeadApplicationQuestion,int> repository)
        {
            this.repository = repository;
        }
        public string Add(AddLeadApplicationQuestions request)
        {
            var entity = new LeadApplicationQuestion
            {
                Question = request.Question
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

        public List<UpdateLeadApplicationQuestions> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateLeadApplicationQuestions()
            {
                Id = d.Id,
                Question = d.Question,
            }).ToList();
        }

        public UpdateLeadApplicationQuestions GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateLeadApplicationQuestions()
            {
                Id = d.Id,
                Question = d.Question,
            }).FirstOrDefault();
        }

        public string Update(UpdateLeadApplicationQuestions request)
        {
            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.Question = request.Question;

            repository.Update(obj);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
