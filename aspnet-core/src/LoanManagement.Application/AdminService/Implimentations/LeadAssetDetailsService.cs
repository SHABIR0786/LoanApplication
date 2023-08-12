using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.LeadAssetDetails;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    public class LeadAssetDetailsService : Abp.Application.Services.ApplicationService, ILeadAssetsDetailsService
    {
        private readonly IRepository<LeadAssetsDetail, int> repository;

        public LeadAssetDetailsService(IRepository<LeadAssetsDetail,int> repository)
        {
            this.repository = repository;
        }
        public string Add(AddLeadAssetDetails request)
        {
            var entity = new LeadAssetsDetail
            {
                LeadApplicationDetailPurchasingId = request.LeadApplicationDetailPurchasingId,
                LeadApplicationTypeId = request.LeadApplicationTypeId,
                LeadApplicationDetailRefinancingId = request.LeadApplicationDetailRefinancingId,
                OwnerTypeId = request.OwnerTypeId,
                AssetTypeId = request.AssetTypeId,
                Balance = request.Balance,
                FinancialInstitution = request.FinancialInstitution
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

        public List<UpdateLeadAssetDetails> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateLeadAssetDetails()
            {
                Id = d.Id,
                LeadApplicationDetailPurchasingId = d.LeadApplicationDetailPurchasingId,
                LeadApplicationTypeId = d.LeadApplicationTypeId,
                LeadApplicationDetailRefinancingId = d.LeadApplicationDetailRefinancingId,
                OwnerTypeId = d.OwnerTypeId,
                AssetTypeId = d.AssetTypeId,
                Balance = d.Balance,
                FinancialInstitution = d.FinancialInstitution
            }).ToList();
        }
        
        public List<UpdateLeadAssetDetails> GetLeadAssetDetailsByPurchasingId(int Id)
        {
            return repository.GetAll().Where(x=>x.LeadApplicationDetailPurchasingId == Id).Select(d => new UpdateLeadAssetDetails()
            {
                Id = d.Id,
                LeadApplicationDetailPurchasingId = d.LeadApplicationDetailPurchasingId,
                LeadApplicationTypeId = d.LeadApplicationTypeId,
                LeadApplicationDetailRefinancingId = d.LeadApplicationDetailRefinancingId,
                OwnerTypeId = d.OwnerTypeId,
                AssetTypeId = d.AssetTypeId,
                Balance = d.Balance,
                FinancialInstitution = d.FinancialInstitution
            }).ToList();
        }
        public List<UpdateLeadAssetDetails> GetLeadAssetDetailsByRefinancingId(int Id)
        {
            return repository.GetAll().Where(x => x.LeadApplicationDetailRefinancingId == Id).Select(d => new UpdateLeadAssetDetails()
            {
                Id = d.Id,
                LeadApplicationDetailPurchasingId = d.LeadApplicationDetailPurchasingId,
                LeadApplicationTypeId = d.LeadApplicationTypeId,
                LeadApplicationDetailRefinancingId = d.LeadApplicationDetailRefinancingId,
                OwnerTypeId = d.OwnerTypeId,
                AssetTypeId = d.AssetTypeId,
                Balance = d.Balance,
                FinancialInstitution = d.FinancialInstitution
            }).ToList();
        }

        public UpdateLeadAssetDetails GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateLeadAssetDetails()
            {
                Id = d.Id,
                LeadApplicationDetailPurchasingId = d.LeadApplicationDetailPurchasingId,
                LeadApplicationTypeId = d.LeadApplicationTypeId,
                LeadApplicationDetailRefinancingId = d.LeadApplicationDetailRefinancingId,
                OwnerTypeId = d.OwnerTypeId,
                AssetTypeId = d.AssetTypeId,
                Balance = d.Balance,
                FinancialInstitution = d.FinancialInstitution
            }).FirstOrDefault();
        }

        public string Update(UpdateLeadAssetDetails request)
        {

            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.LeadApplicationDetailPurchasingId = request.LeadApplicationDetailPurchasingId;
            obj.LeadApplicationTypeId = request.LeadApplicationTypeId;
            obj.LeadApplicationDetailRefinancingId = request.LeadApplicationDetailRefinancingId;
            obj.OwnerTypeId = request.OwnerTypeId;
            obj.AssetTypeId = request.AssetTypeId;
            obj.Balance = request.Balance;
            obj.FinancialInstitution = request.FinancialInstitution;

            repository.Update   (obj);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
