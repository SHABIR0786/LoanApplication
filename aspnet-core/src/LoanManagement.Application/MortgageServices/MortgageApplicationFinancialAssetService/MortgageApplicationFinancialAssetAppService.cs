using Abp.Application.Services;
using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;
using LoanManagement.MortgageServices.MortgageApplicationFinancialAssetService.Dto;
using LoanManagement.MortgageTables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageServices.MortgageApplicationFinancialAssetService
{
    public class MortgageApplicationFinancialAssetAppService : AsyncCrudAppService<MortgageFinancialAccountType, MortgageFinancialAccountTypeDto, int>
    {
        private readonly IRepository<MortgageFinancialAccountType> _mortgageFinancialAccountTypeRepo;
        private readonly IRepository<MortgageFinancialCreditType> _mortgageFinancialAssetsTypeRepo;
        private readonly IRepository<MortgageFinancialLaibilitiesType> _mortgageFinancialLaibilitiesTypeRepo;
        private readonly IRepository<MortgageFinancialOtherLaibilitiesType> _mortgageFinancialOtherLaibilitiesTypeRepo;
        public MortgageApplicationFinancialAssetAppService(
              IRepository<MortgageFinancialAccountType> mortgageFinancialAccountTypeRepo,
      IRepository<MortgageFinancialCreditType> mortgageFinancialAssetsTypeRepo,
        IRepository<MortgageFinancialLaibilitiesType> mortgageFinancialLaibilitiesTypeRepo,
        IRepository<MortgageFinancialOtherLaibilitiesType> mortgageFinancialOtherLaibilitiesTypeRepo
            ) : base(mortgageFinancialAccountTypeRepo)
        {
            this._mortgageFinancialAccountTypeRepo = mortgageFinancialAccountTypeRepo;
            this._mortgageFinancialAssetsTypeRepo = mortgageFinancialAssetsTypeRepo;
            this._mortgageFinancialLaibilitiesTypeRepo = mortgageFinancialLaibilitiesTypeRepo;
            this._mortgageFinancialOtherLaibilitiesTypeRepo = mortgageFinancialOtherLaibilitiesTypeRepo;
        }
        public async Task CreateMortgageApplicationAssetandLiability(CreateMotgageApplicationFinancialAsset input)
       {
            try
            {
                if (input.MortgageFinancialAssets.Count > 0)
                {
                    foreach (var item in input.MortgageFinancialAssets)
                    {
                        var account = ObjectMapper.Map<MortgageFinancialAccountType>(item);
                        await _mortgageFinancialAccountTypeRepo.InsertAsync(account);
                    }
                }

                if (input.MortgageFinancialOtherAssets.Count > 0)
                {
                    foreach (var item in input.MortgageFinancialOtherAssets)
                    {
                        var credit = ObjectMapper.Map<MortgageFinancialCreditType>(item);
                        await _mortgageFinancialAssetsTypeRepo.InsertAsync(credit);
                    }
                }

                if (input.MortgageFinancialLiabilities.Count > 0)
                {
                    foreach (var item in input.MortgageFinancialLiabilities)
                    {
                        var liabilityType = ObjectMapper.Map<MortgageFinancialLaibilitiesType>(item);
                        await _mortgageFinancialLaibilitiesTypeRepo.InsertAsync(liabilityType);
                    }
                }


                if (input.MortgageFinancialOtherAssets.Count > 0)
                {
                    foreach (var item in input.MortgageFinancialOtherLaibilities)
                    {
                        var otherLiabilityType = ObjectMapper.Map<MortgageFinancialOtherLaibilitiesType>(item);
                        await _mortgageFinancialOtherLaibilitiesTypeRepo.InsertAsync(otherLiabilityType);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }


        }


    }
}