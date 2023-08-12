using Abp.Domain.Repositories;
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
    public class LeadRefinancingIncomeDetailsService : Abp.Application.Services.ApplicationService, ILeadRefinancingIncomeDetailsService
    {
        private readonly IRepository<LeadRefinancingIncomeDetail, int> repository;

        public LeadRefinancingIncomeDetailsService(IRepository<LeadRefinancingIncomeDetail,int> repository)
        {
            this.repository = repository;
        }
        public string Add(AddLeadRefinancingIncomeDetails request)
        {
            var entity = new LeadRefinancingIncomeDetail
            {
                IncomeTypeId = request.IncomeTypeId,
                LeadApplicationDetailRefinancingId = request.LeadApplicationDetailRefinancingId,
                LeadApplicationDetailPurchasingId = request.LeadApplicationDetailPurchasingId,
                LeadApplicationTypeId = request.LeadApplicationTypeId,
                MonthlyAmount = request.MonthlyAmount
            };
               repository.Insert(entity);

            UnitOfWorkManager.Current.SaveChanges();
            return entity.Id.ToString();
        }
        public string Update(UpdateLeadRefinancingIncomeDetails request)
        {
            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.LeadApplicationTypeId = request.LeadApplicationTypeId;
            obj.LeadApplicationDetailRefinancingId = request.LeadApplicationDetailRefinancingId;
            obj.MonthlyAmount = request.MonthlyAmount;
            obj.IncomeTypeId = request.IncomeTypeId;

            repository.Update(obj);
            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyUpdated;
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

        public List<UpdateLeadRefinancingIncomeDetails> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateLeadRefinancingIncomeDetails()
            {
                Id = d.Id,
                IncomeTypeId = d.IncomeTypeId,
                MonthlyAmount = d.MonthlyAmount,
                LeadApplicationDetailRefinancingId = d.LeadApplicationDetailRefinancingId,  
                LeadApplicationTypeId = d.LeadApplicationTypeId
            }).ToList();
        }

        public List<UpdateLeadRefinancingIncomeDetails> getPurchaseIncomeDetails(int id)
        {
            return repository.GetAll().Where(x=> x.LeadApplicationDetailPurchasingId == id).Select(d => new UpdateLeadRefinancingIncomeDetails()
            {
                Id = d.Id,
                IncomeTypeId = d.IncomeTypeId,
                MonthlyAmount = d.MonthlyAmount,
                LeadApplicationDetailRefinancingId = d.LeadApplicationDetailRefinancingId,
                LeadApplicationTypeId = d.LeadApplicationTypeId
            }).ToList();
        }

        public List<UpdateLeadRefinancingIncomeDetails> GetRefinancingIncomeDetails(int id)
        {
            return repository.GetAll().Where(x => x.LeadApplicationDetailRefinancingId == id).Select(d => new UpdateLeadRefinancingIncomeDetails()
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
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateLeadRefinancingIncomeDetails()
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
