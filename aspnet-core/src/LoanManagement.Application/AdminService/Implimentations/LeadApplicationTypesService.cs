using Abp.Domain.Repositories;
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
    public class LeadApplicationTypesService : Abp.Application.Services.ApplicationService, ILeadApplicationTypesService
    {
        private readonly IRepository<LeadApplicationType, int> repository;

        public LeadApplicationTypesService(IRepository<LeadApplicationType,int> repository)
        {
            this.repository = repository;
        }
        public string Add(AddLeadApplicationType request)
        {
            var entity = new LeadApplicationType { ApplicationType = request.ApplicationType };
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

        public List<UpdateLeadApplicationType> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateLeadApplicationType()
            {
                Id = d.Id,
                ApplicationType = d.ApplicationType
            }).ToList();
        }

        public UpdateLeadApplicationType GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateLeadApplicationType()
            {
                Id = d.Id,
                ApplicationType = d.ApplicationType
            }).FirstOrDefault();
        }

        public string Update(UpdateLeadApplicationType request)
        {
            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.ApplicationType = request.ApplicationType;

           repository.Update(obj);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
