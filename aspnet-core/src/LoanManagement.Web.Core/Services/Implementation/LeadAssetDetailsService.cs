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
    public class LeadAssetDetailsService : ILeadAssetsDetailsService
    {
        private readonly LoanManagementDbContext _dbContext;
        public LeadAssetDetailsService(LoanManagementDbContext dbContext)
        {
            _dbContext = dbContext;
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
            _dbContext.LeadAssetsDetails.Add(entity);

            _dbContext.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {
            var obj = _dbContext.LeadAssetsDetails.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.LeadAssetsDetails.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateLeadAssetDetails> GetAll()
        {
            return _dbContext.LeadAssetsDetails.Select(d => new UpdateLeadAssetDetails()
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
            return _dbContext.LeadAssetsDetails.Where(s => s.Id == id).Select(d => new UpdateLeadAssetDetails()
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

            var obj = _dbContext.LeadAssetsDetails.Where(s => s.Id == request.Id).FirstOrDefault();

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

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
