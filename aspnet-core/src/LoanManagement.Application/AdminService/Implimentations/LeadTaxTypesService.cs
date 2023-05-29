using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.LeadTaxTypes;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    public class LeadTaxTypesService : Abp.Application.Services.ApplicationService, ILeadTaxTypesService
    {
        private readonly IRepository<LeadTaxesType, int> repository;

        public LeadTaxTypesService(IRepository<LeadTaxesType,int> repository)
        {
            this.repository = repository;
        }
        public string Add(AddLeadTaxTypes request)
        {
            var entity = new LeadTaxesType
            {
                TaxesType = request.TaxesType
            };
            try
            {
                repository.Insert(entity);

                UnitOfWorkManager.Current.SaveChanges();
                return entity.Id.ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public string Update(UpdateLeadTaxTypes request)
        {
            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.TaxesType = request.TaxesType;

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

        public List<UpdateLeadTaxTypes> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateLeadTaxTypes()
            {
                Id = d.Id,
                TaxesType = d.TaxesType
            }).ToList();
        }

        public UpdateLeadTaxTypes GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateLeadTaxTypes()
            {
                Id = d.Id,
                TaxesType = d.TaxesType
            }).FirstOrDefault();
        }

       
    }
}
