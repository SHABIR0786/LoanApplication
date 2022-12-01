using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.LeadOwnerTypes;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    public class LeadOwnerTypesService : Abp.Application.Services.ApplicationService, ILeadOwnerTypesService
    {
        private readonly IRepository<LeadOwnerType, int> repository;

        public LeadOwnerTypesService(IRepository<LeadOwnerType,int> repository)
        {
            this.repository = repository;
        }
        public string Add(AddLeadOwnerTypes request)
        {
            var entity = new LeadOwnerType
            {
                OwnerType = request.OwnerType
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

        public List<UpdateLeadOwnerTypes> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateLeadOwnerTypes()
            {
                Id = d.Id,
                OwnerType = d.OwnerType
            }).ToList();
        }

        public UpdateLeadOwnerTypes GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateLeadOwnerTypes()
            {
                Id = d.Id,
                OwnerType = d.OwnerType
            }).FirstOrDefault();
        }

        public string Update(UpdateLeadOwnerTypes request)
        {

            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.OwnerType = request.OwnerType;

           repository.Update(obj);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
