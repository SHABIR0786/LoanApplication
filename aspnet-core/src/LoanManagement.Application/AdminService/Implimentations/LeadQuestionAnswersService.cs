using Abp.Domain.Repositories;
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
    public class LeadQuestionAnswersService : Abp.Application.Services.ApplicationService, ILeadQuestionAnswersService
    {
        private readonly IRepository<LeadQuestionAnswer, int> repository;

        public LeadQuestionAnswersService(IRepository<LeadQuestionAnswer,int> repository)
        {
            this.repository = repository;
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

        public List<UpdateLeadQuestionAnswers> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateLeadQuestionAnswers()
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
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateLeadQuestionAnswers()
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

            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.LeadApplicationTypeId = request.LeadApplicationTypeId;
            obj.LeadApplicationDetailRefinancingId = request.LeadApplicationDetailRefinancingId;
            obj.IsYes = request.IsYes;
            obj.LeadApplicationDetailPurchasingId = request.LeadApplicationDetailPurchasingId;
            obj.QuestionId = request.QuestionId;

            repository.Update(obj);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
