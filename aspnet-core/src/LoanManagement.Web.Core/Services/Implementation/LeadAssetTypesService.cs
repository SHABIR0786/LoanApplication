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
    public class LeadAssetTypesService : ILeadAssetTypesService
    {
        private readonly LoanManagementDbContext _dbContext;
        public LeadAssetTypesService(LoanManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Add(AddLeadAssetTypes request)
        {
            var entity = new LeadAssetsType
            {
                AssetsType = request.AssetsType,
            };
            _dbContext.LeadAssetsTypes.Add(entity);

            _dbContext.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {
            var obj = _dbContext.LeadAssetsTypes.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.LeadAssetsTypes.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateLeadAssetTypes> GetAll()
        {
            return _dbContext.LeadAssetsTypes.Select(d => new UpdateLeadAssetTypes()
            {
                Id = d.Id,
                AssetsType = d.AssetsType,
            }).ToList();
        }

        public UpdateLeadAssetTypes GetById(int id)
        {
            return _dbContext.LeadAssetsTypes.Where(s => s.Id == id).Select(d => new UpdateLeadAssetTypes()
            {
                Id = d.Id,
                AssetsType = d.AssetsType,
            }).FirstOrDefault();
        }

        public string Update(UpdateLeadAssetTypes request)
        {

            var obj = _dbContext.LeadAssetsTypes.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.AssetsType = request.AssetsType;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
