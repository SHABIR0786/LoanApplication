using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.LeadAssetTypes;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    public class LeadAssetTypesService : Abp.Application.Services.ApplicationService, ILeadAssetTypesService
    {
        private readonly IRepository<LeadAssetsType, int> repository;

        public LeadAssetTypesService(IRepository<LeadAssetsType,int> repository)
        {
            
            this.repository = repository;
        }
        public string Add(AddLeadAssetTypes request)
        {
            var entity = new LeadAssetsType
            {
                AssetsType = request.AssetsType,
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

        public List<UpdateLeadAssetTypes> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateLeadAssetTypes()
            {
                Id = d.Id,
                AssetsType = d.AssetsType,
            }).ToList();
        }

        public UpdateLeadAssetTypes GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateLeadAssetTypes()
            {
                Id = d.Id,
                AssetsType = d.AssetsType,
            }).FirstOrDefault();
        }

        public string Update(UpdateLeadAssetTypes request)
        {

            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.AssetsType = request.AssetsType;

            repository.Update(obj);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
