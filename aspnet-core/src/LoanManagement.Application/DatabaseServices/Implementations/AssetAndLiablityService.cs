using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using System;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class AssetAndLiablityService : AbpServiceBase, IAssetAndLiablityService
    {
        private readonly IRepository<AssetAndLiablity, long> _repository;

        public AssetAndLiablityService(IRepository<AssetAndLiablity, long> repository)
        {
            _repository = repository;
        }

        public async Task<AssetAndLiabilityDto> CreateAsync(AssetAndLiabilityDto input)
        {
            var assetAndLiablity = new AssetAndLiablity
            {
                AssetsCompletion = input.AssetsCompletion,
                Description = input.Description,
                CashOrMarketValue = input.CashOrMarketValue,
                CashDepositPurchaseHeldBy = input.CashDepositPurchaseHeldBy,
                NameOfBank1 = input.NameOfBank1,
                AddressOfBank1 = input.AddressOfBank1,
                BankAccountNo1 = input.BankAccountNo1,
                Amount1 = input.Amount1,
                NameOfCompany1 = input.NameOfCompany1,
                AddressOfCompany1 = input.AddressOfCompany1,
                CompanyAccountNo1 = input.CompanyAccountNo1,
                MonthlyPayment1 = input.MonthlyPayment1,
                MonthsLeft1 = input.MonthsLeft1,
                UnpaidBalance1 = input.UnpaidBalance1,
                NameOfBank2 = input.NameOfBank2,
                AddressOfBank2 = input.AddressOfBank2,
                BankAccountNo2 = input.BankAccountNo2,
                BankAmount2 = input.BankAmount2,
                NameOfCompany2 = input.NameOfCompany2,
                AddressOfCompany2 = input.AddressOfCompany2,
                CompanyAccountNo2 = input.CompanyAccountNo2,
                MonthlyPayment2 = input.MonthlyPayment2,
                MonthsLeft2 = input.MonthsLeft2,
                UnpaidBalance2 = input.UnpaidBalance2,
                NameOfBank3 = input.NameOfBank3,
                AddressOfBank3 = input.AddressOfBank3,
                BankAccountNo3 = input.BankAccountNo3,
                BankAmount3 = input.BankAmount3,
                NameOfCompany3 = input.NameOfCompany3,
                AddressOfCompany3 = input.AddressOfCompany3,
                CompanyAccountNo3 = input.CompanyAccountNo3,
                MonthlyPayment3 = input.MonthlyPayment3,
                MonthsLeft3 = input.MonthsLeft3,
                UnpaidBalance3 = input.UnpaidBalance3,
                NameOfBank4 = input.NameOfBank4,
                AddressOfBank4 = input.AddressOfBank4,
                BankAccountNo4 = input.BankAccountNo4,
                BankAmount4 = input.BankAmount4,
                NameOfCompany4 = input.NameOfCompany4,
                AddressOfCompany4 = input.AddressOfCompany4,
                CompanyAccountNo4 = input.CompanyAccountNo4,
                MonthlyPayment4 = input.MonthlyPayment4,
                MonthsLeft4 = input.MonthsLeft4,
                UnpaidBalance4 = input.UnpaidBalance4,
                StockCompanyName = input.StockCompanyName,
                StockCompanyNumber = input.StockCompanyNumber,
                StockCompanyDescription = input.StockCompanyDescription,
                StockAmount = input.StockAmount,
                NameOfCompany5 = input.NameOfCompany5,
                AddressOfCompany5 = input.AddressOfCompany5,
                CompanyAccountNo5 = input.CompanyAccountNo5,
                MonthlyPayment5 = input.MonthlyPayment5,
                MonthsLeft5 = input.MonthsLeft5,
                UnpaidBalance5 = input.UnpaidBalance5,
                LifeInsuranceNetCashValue = input.LifeInsuranceNetCashValue,
                SubtotalLiquidAssets = input.SubtotalLiquidAssets,
                RealEstateOwned = input.RealEstateOwned,
                RetirementFund = input.RetirementFund,
                NetworthOfBussiness = input.NetworthOfBussiness,
                NameOfCompany6 = input.NameOfCompany6,
                AddressOfCompany6 = input.AddressOfCompany6,
                CompanyAccountNo6 = input.CompanyAccountNo6,
                MonthlyPayment6 = input.MonthlyPayment6,
                MonthsLeft6 = input.MonthsLeft6,
                UnpaidBalance6 = input.UnpaidBalance6,
                AutomobileMake = input.AutomobileMake,
                AutomobileYear = input.AutomobileYear,
                AutomobileAmount = input.AutomobileAmount,
                MaintenancePaymentOwedTo = input.MaintenancePaymentOwedTo,
                MaintenancePayment = input.MaintenancePayment,
                OtherAssets = input.OtherAssets,
                OtherAssetsAmount = input.OtherAssetsAmount,
                JobRelatedExpenses = input.JobRelatedExpenses,
                JobRelatedExpensesPayment = input.JobRelatedExpensesPayment,
                AlternateName = input.AlternateName,
                CreditorName = input.CreditorName,
                AccountName = input.AccountName,
                TenantId = input.TenantId,
            };

            await _repository.InsertAsync(assetAndLiablity);
            await UnitOfWorkManager.Current.SaveChangesAsync();
            input.Id = assetAndLiablity.Id;
            return input;
        }

        public Task DeleteAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<AssetAndLiabilityDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<AssetAndLiabilityDto> GetAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public async Task<AssetAndLiabilityDto> UpdateAsync(AssetAndLiabilityDto input)
        {
            await _repository.UpdateAsync(input.Id, assetAndLiablity =>
            {
                assetAndLiablity.AssetsCompletion = input.AssetsCompletion;
                assetAndLiablity.Description = input.Description;
                assetAndLiablity.CashOrMarketValue = input.CashOrMarketValue;
                assetAndLiablity.CashDepositPurchaseHeldBy = input.CashDepositPurchaseHeldBy;
                assetAndLiablity.NameOfBank1 = input.NameOfBank1;
                assetAndLiablity.AddressOfBank1 = input.AddressOfBank1;
                assetAndLiablity.BankAccountNo1 = input.BankAccountNo1;
                assetAndLiablity.Amount1 = input.Amount1;
                assetAndLiablity.NameOfCompany1 = input.NameOfCompany1;
                assetAndLiablity.AddressOfCompany1 = input.AddressOfCompany1;
                assetAndLiablity.CompanyAccountNo1 = input.CompanyAccountNo1;
                assetAndLiablity.MonthlyPayment1 = input.MonthlyPayment1;
                assetAndLiablity.MonthsLeft1 = input.MonthsLeft1;
                assetAndLiablity.UnpaidBalance1 = input.UnpaidBalance1;
                assetAndLiablity.NameOfBank2 = input.NameOfBank2;
                assetAndLiablity.AddressOfBank2 = input.AddressOfBank2;
                assetAndLiablity.BankAccountNo2 = input.BankAccountNo2;
                assetAndLiablity.BankAmount2 = input.BankAmount2;
                assetAndLiablity.NameOfCompany2 = input.NameOfCompany2;
                assetAndLiablity.AddressOfCompany2 = input.AddressOfCompany2;
                assetAndLiablity.CompanyAccountNo2 = input.CompanyAccountNo2;
                assetAndLiablity.MonthlyPayment2 = input.MonthlyPayment2;
                assetAndLiablity.MonthsLeft2 = input.MonthsLeft2;
                assetAndLiablity.UnpaidBalance2 = input.UnpaidBalance2;
                assetAndLiablity.NameOfBank3 = input.NameOfBank3;
                assetAndLiablity.AddressOfBank3 = input.AddressOfBank3;
                assetAndLiablity.BankAccountNo3 = input.BankAccountNo3;
                assetAndLiablity.BankAmount3 = input.BankAmount3;
                assetAndLiablity.NameOfCompany3 = input.NameOfCompany3;
                assetAndLiablity.AddressOfCompany3 = input.AddressOfCompany3;
                assetAndLiablity.CompanyAccountNo3 = input.CompanyAccountNo3;
                assetAndLiablity.MonthlyPayment3 = input.MonthlyPayment3;
                assetAndLiablity.MonthsLeft3 = input.MonthsLeft3;
                assetAndLiablity.UnpaidBalance3 = input.UnpaidBalance3;
                assetAndLiablity.NameOfBank4 = input.NameOfBank4;
                assetAndLiablity.AddressOfBank4 = input.AddressOfBank4;
                assetAndLiablity.BankAccountNo4 = input.BankAccountNo4;
                assetAndLiablity.BankAmount4 = input.BankAmount4;
                assetAndLiablity.NameOfCompany4 = input.NameOfCompany4;
                assetAndLiablity.AddressOfCompany4 = input.AddressOfCompany4;
                assetAndLiablity.CompanyAccountNo4 = input.CompanyAccountNo4;
                assetAndLiablity.MonthlyPayment4 = input.MonthlyPayment4;
                assetAndLiablity.MonthsLeft4 = input.MonthsLeft4;
                assetAndLiablity.UnpaidBalance4 = input.UnpaidBalance4;
                assetAndLiablity.StockCompanyName = input.StockCompanyName;
                assetAndLiablity.StockCompanyNumber = input.StockCompanyNumber;
                assetAndLiablity.StockCompanyDescription = input.StockCompanyDescription;
                assetAndLiablity.StockAmount = input.StockAmount;
                assetAndLiablity.NameOfCompany5 = input.NameOfCompany5;
                assetAndLiablity.AddressOfCompany5 = input.AddressOfCompany5;
                assetAndLiablity.CompanyAccountNo5 = input.CompanyAccountNo5;
                assetAndLiablity.MonthlyPayment5 = input.MonthlyPayment5;
                assetAndLiablity.MonthsLeft5 = input.MonthsLeft5;
                assetAndLiablity.UnpaidBalance5 = input.UnpaidBalance5;
                assetAndLiablity.LifeInsuranceNetCashValue = input.LifeInsuranceNetCashValue;
                assetAndLiablity.SubtotalLiquidAssets = input.SubtotalLiquidAssets;
                assetAndLiablity.RealEstateOwned = input.RealEstateOwned;
                assetAndLiablity.RetirementFund = input.RetirementFund;
                assetAndLiablity.NetworthOfBussiness = input.NetworthOfBussiness;
                assetAndLiablity.NameOfCompany6 = input.NameOfCompany6;
                assetAndLiablity.AddressOfCompany6 = input.AddressOfCompany6;
                assetAndLiablity.CompanyAccountNo6 = input.CompanyAccountNo6;
                assetAndLiablity.MonthlyPayment6 = input.MonthlyPayment6;
                assetAndLiablity.MonthsLeft6 = input.MonthsLeft6;
                assetAndLiablity.UnpaidBalance6 = input.UnpaidBalance6;
                assetAndLiablity.AutomobileMake = input.AutomobileMake;
                assetAndLiablity.AutomobileYear = input.AutomobileYear;
                assetAndLiablity.AutomobileAmount = input.AutomobileAmount;
                assetAndLiablity.MaintenancePaymentOwedTo = input.MaintenancePaymentOwedTo;
                assetAndLiablity.MaintenancePayment = input.MaintenancePayment;
                assetAndLiablity.OtherAssets = input.OtherAssets;
                assetAndLiablity.OtherAssetsAmount = input.OtherAssetsAmount;
                assetAndLiablity.JobRelatedExpenses = input.JobRelatedExpenses;
                assetAndLiablity.JobRelatedExpensesPayment = input.JobRelatedExpensesPayment;
                assetAndLiablity.AlternateName = input.AlternateName;
                assetAndLiablity.CreditorName = input.CreditorName;
                assetAndLiablity.AccountName = input.AccountName;
                assetAndLiablity.TenantId = input.TenantId;

                return Task.CompletedTask;
            });

            await UnitOfWorkManager.Current.SaveChangesAsync();

            return input;
        }
    }
}
