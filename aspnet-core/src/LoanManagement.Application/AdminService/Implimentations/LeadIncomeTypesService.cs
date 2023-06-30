using Abp.Domain.Repositories;
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
    public class LeadIncomeTypesService : Abp.Application.Services.ApplicationService, ILeadIncomeTypesService
    {
        private readonly IRepository<LeadIncomeType, int> repository;

        public LeadIncomeTypesService(IRepository<LeadIncomeType,int>repository)
        {
            this.repository = repository;
        }
        public string Add(AddLeadIncomeTypes request)
        {
            var entity = new LeadIncomeType
            {
                IncomeType = request.IncomeType,
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

        public List<UpdateLeadIncomeTypes> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateLeadIncomeTypes()
            {
                Id = d.Id,
                IncomeType = d.IncomeType
            }).ToList();
        }

        public UpdateLeadIncomeTypes GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateLeadIncomeTypes()
            {
                Id = d.Id,
                IncomeType = d.IncomeType
            }).FirstOrDefault();
        }

        public string Update(UpdateLeadIncomeTypes request)
        {

            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.IncomeType = request.IncomeType;

            repository.Update(obj);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
