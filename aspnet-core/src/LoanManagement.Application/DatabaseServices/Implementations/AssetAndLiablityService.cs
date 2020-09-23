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
                AccountName = input.AccountName,
                AddressOfBank1 = input.AddressOfBank1,
                AddressOfBank2 = input.AddressOfBank2,
                AddressOfBank3 = input.AddressOfBank3,
                AddressOfBank4 = input.AddressOfBank4,
                AddressOfCompany1 = input.AddressOfCompany1,
                AddressOfCompany2 = input.AddressOfCompany2,
                AddressOfCompany3 = input.AddressOfCompany3,
                AddressOfCompany4 = input.AddressOfCompany4,
                AddressOfCompany5 = input.AddressOfCompany5,
                AddressOfCompany6 = input.AddressOfCompany6,
                AlternateName = input.AlternateName,
                Amount1 = input.Amount1,
                AssetsCompletion = input.AssetsCompletion,
                AutomobileOwned = input.AutomobileOwned,
                BankAccountNo1 = input.BankAccountNo1,
                BankAccountNo2 = input.BankAccountNo2,
                BankAccountNo3 = input.BankAccountNo3,
                BankAccountNo4 = input.BankAccountNo4,
                BankAmount2 = input.BankAmount2,
                BankAmount3 = input.BankAmount3,
                BankAmount4 = input.BankAmount4,
                CashDepositPurchaseHeldBy = input.CashDepositPurchaseHeldBy,
                CashOrMarketValue = input.CashOrMarketValue,
                CompanyAccountNo1 = input.CompanyAccountNo1,
                CompanyAccountNo2 = input.CompanyAccountNo2,
                CompanyAccountNo3 = input.CompanyAccountNo3,
                CompanyAccountNo4 = input.CompanyAccountNo4,
                CompanyAccountNo5 = input.CompanyAccountNo5,
                CompanyAccountNo6 = input.CompanyAccountNo6,
                CreditorName = input.CreditorName,
                Description = input.Description,
                JobRelatedExpense = input.JobRelatedExpense,
                LifeInsuranceNetCashValue = input.LifeInsuranceNetCashValue,
                NameOfBank1 = input.NameOfBank1,
                NameOfBank2 = input.NameOfBank2,
                NameOfBank3 = input.NameOfBank3,
                NameOfBank4 = input.NameOfBank4,
                NameOfCompany1 = input.NameOfCompany1,
                NameOfCompany2 = input.NameOfCompany2,
                NameOfCompany3 = input.NameOfCompany3,
                NameOfCompany4 = input.NameOfCompany4,
                NameOfCompany5 = input.NameOfCompany5,
                NameOfCompany6 = input.NameOfCompany6,
                NetWorth = input.NetWorth,
                NetworthOfBussiness = input.NetworthOfBussiness,
                OtherAssests = input.OtherAssests,
                PaymentMethod1 = input.PaymentMethod1,
                PaymentMethod2 = input.PaymentMethod2,
                PaymentMethod3 = input.PaymentMethod3,
                PaymentMethod4 = input.PaymentMethod4,
                PaymentMethod5 = input.PaymentMethod5,
                PaymentMethod6 = input.PaymentMethod6,
                RealEstateOwned = input.RealEstateOwned,
                RetirementFund = input.RetirementFund,
                SeparateMaintenancePaymentsOwedTo = input.SeparateMaintenancePaymentsOwedTo,
                StockBondCompanyDescription = input.StockBondCompanyDescription,
                SubtotalLiquidAssets = input.SubtotalLiquidAssets,
                TotalAssests = input.TotalAssests,
                TotalLiablities = input.TotalLiablities,
                TotalMoneyPayment = input.TotalMoneyPayment,
                UnpaidBalance1 = input.UnpaidBalance1,
                UnpaidBalance2 = input.UnpaidBalance2,
                UnpaidBalance3 = input.UnpaidBalance3,
                UnpaidBalance4 = input.UnpaidBalance4,
                UnpaidBalance5 = input.UnpaidBalance5,
                UnpaidBalance6 = input.UnpaidBalance6
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
                assetAndLiablity.AccountName = input.AccountName;
                assetAndLiablity.AddressOfBank1 = input.AddressOfBank1;
                assetAndLiablity.AddressOfBank2 = input.AddressOfBank2;
                assetAndLiablity.AddressOfBank3 = input.AddressOfBank3;
                assetAndLiablity.AddressOfBank4 = input.AddressOfBank4;
                assetAndLiablity.AddressOfCompany1 = input.AddressOfCompany1;
                assetAndLiablity.AddressOfCompany2 = input.AddressOfCompany2;
                assetAndLiablity.AddressOfCompany3 = input.AddressOfCompany3;
                assetAndLiablity.AddressOfCompany4 = input.AddressOfCompany4;
                assetAndLiablity.AddressOfCompany5 = input.AddressOfCompany5;
                assetAndLiablity.AddressOfCompany6 = input.AddressOfCompany6;
                assetAndLiablity.AlternateName = input.AlternateName;
                assetAndLiablity.Amount1 = input.Amount1;
                assetAndLiablity.AssetsCompletion = input.AssetsCompletion;
                assetAndLiablity.AutomobileOwned = input.AutomobileOwned;
                assetAndLiablity.BankAccountNo1 = input.BankAccountNo1;
                assetAndLiablity.BankAccountNo2 = input.BankAccountNo2;
                assetAndLiablity.BankAccountNo3 = input.BankAccountNo3;
                assetAndLiablity.BankAccountNo4 = input.BankAccountNo4;
                assetAndLiablity.BankAmount2 = input.BankAmount2;
                assetAndLiablity.BankAmount3 = input.BankAmount3;
                assetAndLiablity.BankAmount4 = input.BankAmount4;
                assetAndLiablity.CashDepositPurchaseHeldBy = input.CashDepositPurchaseHeldBy;
                assetAndLiablity.CashOrMarketValue = input.CashOrMarketValue;
                assetAndLiablity.CompanyAccountNo1 = input.CompanyAccountNo1;
                assetAndLiablity.CompanyAccountNo2 = input.CompanyAccountNo2;
                assetAndLiablity.CompanyAccountNo3 = input.CompanyAccountNo3;
                assetAndLiablity.CompanyAccountNo4 = input.CompanyAccountNo4;
                assetAndLiablity.CompanyAccountNo5 = input.CompanyAccountNo5;
                assetAndLiablity.CompanyAccountNo6 = input.CompanyAccountNo6;
                assetAndLiablity.CreditorName = input.CreditorName;
                assetAndLiablity.Description = input.Description;
                assetAndLiablity.JobRelatedExpense = input.JobRelatedExpense;
                assetAndLiablity.LifeInsuranceNetCashValue = input.LifeInsuranceNetCashValue;
                assetAndLiablity.NameOfBank1 = input.NameOfBank1;
                assetAndLiablity.NameOfBank2 = input.NameOfBank2;
                assetAndLiablity.NameOfBank3 = input.NameOfBank3;
                assetAndLiablity.NameOfBank4 = input.NameOfBank4;
                assetAndLiablity.NameOfCompany1 = input.NameOfCompany1;
                assetAndLiablity.NameOfCompany2 = input.NameOfCompany2;
                assetAndLiablity.NameOfCompany3 = input.NameOfCompany3;
                assetAndLiablity.NameOfCompany4 = input.NameOfCompany4;
                assetAndLiablity.NameOfCompany5 = input.NameOfCompany5;
                assetAndLiablity.NameOfCompany6 = input.NameOfCompany6;
                assetAndLiablity.NetWorth = input.NetWorth;
                assetAndLiablity.NetworthOfBussiness = input.NetworthOfBussiness;
                assetAndLiablity.OtherAssests = input.OtherAssests;
                assetAndLiablity.PaymentMethod1 = input.PaymentMethod1;
                assetAndLiablity.PaymentMethod2 = input.PaymentMethod2;
                assetAndLiablity.PaymentMethod3 = input.PaymentMethod3;
                assetAndLiablity.PaymentMethod4 = input.PaymentMethod4;
                assetAndLiablity.PaymentMethod5 = input.PaymentMethod5;
                assetAndLiablity.PaymentMethod6 = input.PaymentMethod6;
                assetAndLiablity.RealEstateOwned = input.RealEstateOwned;
                assetAndLiablity.RetirementFund = input.RetirementFund;
                assetAndLiablity.SeparateMaintenancePaymentsOwedTo = input.SeparateMaintenancePaymentsOwedTo;
                assetAndLiablity.StockBondCompanyDescription = input.StockBondCompanyDescription;
                assetAndLiablity.SubtotalLiquidAssets = input.SubtotalLiquidAssets;
                assetAndLiablity.TotalAssests = input.TotalAssests;
                assetAndLiablity.TotalLiablities = input.TotalLiablities;
                assetAndLiablity.TotalMoneyPayment = input.TotalMoneyPayment;
                assetAndLiablity.UnpaidBalance1 = input.UnpaidBalance1;
                assetAndLiablity.UnpaidBalance2 = input.UnpaidBalance2;
                assetAndLiablity.UnpaidBalance3 = input.UnpaidBalance3;
                assetAndLiablity.UnpaidBalance4 = input.UnpaidBalance4;
                assetAndLiablity.UnpaidBalance5 = input.UnpaidBalance5;
                assetAndLiablity.UnpaidBalance6 = input.UnpaidBalance6;

                return Task.CompletedTask;
            });

            await UnitOfWorkManager.Current.SaveChangesAsync();

            return input;
        }
    }
}
