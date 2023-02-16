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
    public class MortgageApplicationFinancialAssetAppService : AsyncCrudAppService<MortgageAppliactionFinancialAccount, MortgageAppliactionFinancialAccountDto, int>
    {
        private readonly IRepository<MortgageAppliactionFinancialAccount> _mortgageAppliactionFinancialAssetRepo;
        private readonly IRepository<MortgageAppliactionFinancialCredit> _mortgageAppliactionFinancialOtherAssetRepo;
        private readonly IRepository<MortgageAppliactionFinancialLiability> _mortgageAppliactionFinancialLiabilityRepo;
        private readonly IRepository<MortgageAppliactionFinancialOtherLiability> _mortgageAppliactionFinancialOtherLiabilityRepo;
        private readonly IRepository<MortgageFinancialAccountType> _mortgageFinancialAccountTypeRepo;
        private readonly IRepository<MortgageFinancialCreditType> _mortgageFinancialAssetsTypeRepo;
        private readonly IRepository<MortgageFinancialLaibilitiesType> _mortgageFinancialLaibilitiesTypeRepo;
        private readonly IRepository<MortgageFinancialOtherLaibilitiesType> _mortgageFinancialOtherLaibilitiesTypeRepo;
        public MortgageApplicationFinancialAssetAppService(

            IRepository<MortgageAppliactionFinancialAccount> mortgageAppliactionFinancialAssetRepo,
            IRepository<MortgageAppliactionFinancialCredit> mortgageAppliactionFinancialOtherAssetRepo,
            IRepository<MortgageAppliactionFinancialLiability> mortgageAppliactionFinancialLiabilityRepo,
             IRepository<MortgageAppliactionFinancialOtherLiability> mortgageAppliactionFinancialOtherLiabilityRepo,
              IRepository<MortgageFinancialAccountType> mortgageFinancialAccountTypeRepo,
      IRepository<MortgageFinancialCreditType> mortgageFinancialAssetsTypeRepo,
        IRepository<MortgageFinancialLaibilitiesType> mortgageFinancialLaibilitiesTypeRepo,
        IRepository<MortgageFinancialOtherLaibilitiesType> mortgageFinancialOtherLaibilitiesTypeRepo


            ) : base(mortgageAppliactionFinancialAssetRepo)
        {

            this._mortgageAppliactionFinancialAssetRepo = mortgageAppliactionFinancialAssetRepo;
            this._mortgageAppliactionFinancialOtherAssetRepo = mortgageAppliactionFinancialOtherAssetRepo;
            this._mortgageAppliactionFinancialLiabilityRepo = mortgageAppliactionFinancialLiabilityRepo;
            this._mortgageAppliactionFinancialOtherLiabilityRepo = mortgageAppliactionFinancialOtherLiabilityRepo;
            this._mortgageFinancialAccountTypeRepo = mortgageFinancialAccountTypeRepo;
            this._mortgageFinancialAssetsTypeRepo = mortgageFinancialAssetsTypeRepo;
            this._mortgageFinancialLaibilitiesTypeRepo = mortgageFinancialLaibilitiesTypeRepo;
            this._mortgageFinancialOtherLaibilitiesTypeRepo = mortgageFinancialOtherLaibilitiesTypeRepo;


        }



        public async Task CreateMortgageApplicationAssetandLiability(CreateMotgageApplicationFinancialAsset input)
        {
            try
            {
                var mortgageAsset = ObjectMapper.Map<MortgageAppliactionFinancialAccount>(input.MortgageAppliactionFinancialAccount);
                var mortgageAssetId = await _mortgageAppliactionFinancialAssetRepo.InsertAndGetIdAsync(mortgageAsset);
                if (input.MortgageAppliactionFinancialAccount.MortgageFinancialAccountType.Count > 0)
                {
                    foreach (var item in input.MortgageAppliactionFinancialAccount.MortgageFinancialAccountType)
                    {
                        //var account = new MortgageFinancialAccountType()
                        //{
                        //    accountNumber = item.accountNumber,
                        //    financialInstitution = item.financialInstitution,
                        //    cashMarketValue = item.cashMarketValue,
                        //    MortgageAppliactionFinancialAccountId = mortgageAssetId,
                        //    accountType = item.accountType,
                        //};
                        var account = ObjectMapper.Map<MortgageFinancialAccountType>(item);
                        account.MortgageAppliactionFinancialAccountId = mortgageAssetId;
                        await _mortgageFinancialAccountTypeRepo.InsertAsync(account);
                    }
                }


                var mortgageOtherAsset = ObjectMapper.Map<MortgageAppliactionFinancialCredit>(input.MortgageAppliactionFinancialCredit);
                var mortgageOtherAssetId = await _mortgageAppliactionFinancialOtherAssetRepo.InsertAndGetIdAsync(mortgageOtherAsset);
                if (input.MortgageAppliactionFinancialCredit.MortgageFinancialAssetsType.Count > 0)
                {
                    foreach (var item in input.MortgageAppliactionFinancialCredit.MortgageFinancialAssetsType)
                    {
                        //var credit = new MortgageFinancialCreditType()
                        //{
                        //    assetsCreditType = item.assetsCreditType,
                        //    MortgageAppliactionFinancialCreditId = mortgageOtherAssetId,
                        //    cashMarketValue = item.cashMarketValue,
                        //};
                        var credit = ObjectMapper.Map<MortgageFinancialCreditType>(item);
                        credit.MortgageAppliactionFinancialCreditId= mortgageOtherAssetId;
                        await _mortgageFinancialAssetsTypeRepo.InsertAsync(credit);
                    }
                }

                var liability = ObjectMapper.Map<MortgageAppliactionFinancialLiability>(input.MortgageappliactionFinancialLiability);
                var liabilityId = await _mortgageAppliactionFinancialLiabilityRepo.InsertAndGetIdAsync(liability);
                if(input.MortgageappliactionFinancialLiability.MortgageFinancialLaibilitiesType.Count > 0)
                {
                    foreach (var item in input.MortgageappliactionFinancialLiability.MortgageFinancialLaibilitiesType)
                    {
                        //var liabilityType = new MortgageFinancialLaibilitiesType()
                        //{
                        //    accountNumber = item.accountNumber,
                        //    accountType = item.accountType,
                        //    MortgageApplicationFinancialLiabilityId = mortgageOtherAssetId,
                        //    companyName = item.companyName,
                        //    unpaidBalance = item.unpaidBalance,
                        //    cashMarketValue = item.cashMarketValue,
                        //};
                        var liabilityType= ObjectMapper.Map<MortgageFinancialLaibilitiesType>(item);
                        liabilityType.MortgageApplicationFinancialLiabilityId= liabilityId;
                        await _mortgageFinancialLaibilitiesTypeRepo.InsertAsync(liabilityType);
                    }
                }
             
                var Otherliability = ObjectMapper.Map<MortgageAppliactionFinancialOtherLiability>(input.MortgageappliactionFinancialOtherLiability);
                var OtherliabilityId = await _mortgageAppliactionFinancialOtherLiabilityRepo.InsertAndGetIdAsync(Otherliability);
                if (input.MortgageappliactionFinancialOtherLiability.MortgageFinancialOtherLaibilitiesType.Count > 0)
                {
                    foreach (var item in input.MortgageappliactionFinancialOtherLiability.MortgageFinancialOtherLaibilitiesType)
                    {
                        //var otherLiabilityType = new MortgageFinancialOtherLaibilitiesType()
                        //{
                        //    cashMarketValue = item.cashMarketValue,
                        //    MortgageApplicationFinancialOtherLiabilityId = mortgageOtherAssetId,
                        //    expense = item.expense,
                        //};
                         var otherLiabilityType= ObjectMapper.Map<MortgageFinancialOtherLaibilitiesType>(item);
                        otherLiabilityType.MortgageApplicationFinancialOtherLiabilityId = OtherliabilityId;
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