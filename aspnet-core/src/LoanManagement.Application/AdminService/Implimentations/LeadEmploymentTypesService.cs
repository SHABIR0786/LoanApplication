using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.LeadEmploymentTypes;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    public class LeadEmploymentTypesService : Abp.Application.Services.ApplicationService, ILeadEmploymentTypesService
    {
        private readonly IRepository<LeadEmployementType, int> repository;

        public LeadEmploymentTypesService(IRepository<LeadEmployementType,int> repository)
        {
            this.repository = repository;
        }
        public string Add(AddLeadEmploymentTypes request)
        {
            var entity = new LeadEmployementType
            {
                EmployementType = request.EmployementType,
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

        public List<UpdateLeadEmploymentTypes> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateLeadEmploymentTypes()
            {
                Id = d.Id,
                EmployementType = d.EmployementType
            }).ToList();
        }

        public UpdateLeadEmploymentTypes GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateLeadEmploymentTypes()
            {
                Id = d.Id,
                EmployementType = d.EmployementType
            }).FirstOrDefault();
        }

        public string Update(UpdateLeadEmploymentTypes request)
        {

            var obj =repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.EmployementType = request.EmployementType;

            repository.Update(obj);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
