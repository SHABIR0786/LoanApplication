using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class ManualAssetEntryService : AbpServiceBase, IManualAssetEntryService
    {
        private readonly IRepository<Manualassetentry, long> _repository;
        private readonly IRepository<Stockandbond, long> _stockAndBondRepository;

        public ManualAssetEntryService(
            IRepository<Manualassetentry, long> manualAssetEntryRepository,
            IRepository<Stockandbond, long> stockAndBondRepository)
        {
            _repository = manualAssetEntryRepository;
            _stockAndBondRepository = stockAndBondRepository;
        }

        public async Task<ManualAssetEntryDto> CreateAsync(ManualAssetEntryDto input)
        {
            var manualAssetEntry = new Manualassetentry
            {
                AccountNumber = input.AccountNumber,
                Address = input.Address,
                Address2 = input.Address2,
                AssetTypeId = input.AssetTypeId,
                BankName = input.BankName,
                BorrowerTypeId = input.BorrowerTypeId,
                CashValue = input.CashValue,
                City = input.City,
                Description = input.Description,
                GrossRentalIncome = input.GrossRentalIncome,
                MonthlyMortgagePayment = input.MonthlyMortgagePayment,
                LoanApplicationId = input.LoanApplicationId,
                Name = input.Name,
                OutstandingMortgageBalance = input.OutstandingMortgageBalance,
                PresentMarketValue = input.PresentMarketValue,
                PropertyIsUsedAs = input.PropertyIsUsedAs,
                PropertyStatus = input.PropertyStatus,
                PropertyType = input.PropertyType,
                PurchasePrice = input.PurchasePrice,
                StateId = Convert.ToInt32(input.StateId),
                Stockandbonds = input.StockAndBonds != null && input.StockAndBonds.Any() ? input.StockAndBonds.Select(i => new Stockandbond 
                {
                    AccountNumber = i.AccountNumber,
                    CompanyName = i.CompanyName,
                    Value = Convert.ToDecimal(i.Value)
                }).ToList() : null,
                TaxesInsuranceAndOther = input.TaxesInsuranceAndOther,
                ZipCode = input.ZipCode
            };
            await _repository.InsertAsync(manualAssetEntry);


            await UnitOfWorkManager.Current.SaveChangesAsync();

            input.Id = manualAssetEntry.Id;
            if (manualAssetEntry.Stockandbonds != null && manualAssetEntry.Stockandbonds.Any())
            {
                for (var index = 0; index < manualAssetEntry.Stockandbonds.Count; index++)
                {
                    input.StockAndBonds[index].Id = Convert.ToInt64(manualAssetEntry.Stockandbonds.ToList()[index].Id);
                }
            }
            return input;
        }

        public Task DeleteAsync(EntityDto<long?> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<ManualAssetEntryDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ManualAssetEntryDto> GetAsync(EntityDto<long?> input)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Manualassetentry>> GetAllByLoanApplicationIdAsync(long loanApplicationId)
        {
            return await _repository.GetAll()
                .Where(i => i.LoanApplicationId == loanApplicationId)
                .Select(i => new Manualassetentry
                {
                    AccountNumber = i.AccountNumber,
                    Address = i.Address,
                    Address2 = i.Address2,
                    AssetTypeId = i.AssetTypeId,
                    BankName = i.BankName,
                    BorrowerTypeId = i.BorrowerTypeId,
                    CashValue = i.CashValue,
                    City = i.City,
                    Description = i.Description,
                    GrossRentalIncome = i.GrossRentalIncome,
                    MonthlyMortgagePayment = i.MonthlyMortgagePayment,
                    LoanApplicationId = i.LoanApplicationId,
                    Name = i.Name,
                    OutstandingMortgageBalance = i.OutstandingMortgageBalance,
                    PresentMarketValue = i.PresentMarketValue,
                    PropertyIsUsedAs = i.PropertyIsUsedAs,
                    PropertyStatus = i.PropertyStatus,
                    PropertyType = i.PropertyType,
                    PurchasePrice = i.PurchasePrice,
                    StateId = i.StateId,
                    TaxesInsuranceAndOther = i.TaxesInsuranceAndOther,
                    ZipCode = i.ZipCode,
                    Id = i.Id,
                    Stockandbonds = i.Stockandbonds.Select(o => new Stockandbond
                    {
                        AccountNumber = o.AccountNumber,
                        CompanyName = o.CompanyName,
                        Value = o.Value
                    }).ToList()
                })
                .ToListAsync();
        }
        public async Task<ManualAssetEntryDto> UpdateAsync(ManualAssetEntryDto input)
        {
            var stockAndBonds = new List<Stockandbond>();

            await _repository.UpdateAsync(input.Id.Value, async manualAssetEntry =>
            {
                manualAssetEntry.AccountNumber = input.AccountNumber;
                manualAssetEntry.Address = input.Address;
                manualAssetEntry.Address2 = input.Address2;
                manualAssetEntry.AssetTypeId = input.AssetTypeId;
                manualAssetEntry.BankName = input.BankName;
                manualAssetEntry.BorrowerTypeId = input.BorrowerTypeId;
                manualAssetEntry.CashValue = input.CashValue;
                manualAssetEntry.City = input.City;
                manualAssetEntry.Description = input.Description;
                manualAssetEntry.GrossRentalIncome = input.GrossRentalIncome;
                manualAssetEntry.MonthlyMortgagePayment = input.MonthlyMortgagePayment;
                manualAssetEntry.LoanApplicationId = input.LoanApplicationId;
                manualAssetEntry.Name = input.Name;
                manualAssetEntry.OutstandingMortgageBalance = input.OutstandingMortgageBalance;
                manualAssetEntry.PresentMarketValue = input.PresentMarketValue;
                manualAssetEntry.PropertyIsUsedAs = input.PropertyIsUsedAs;
                manualAssetEntry.PropertyStatus = input.PropertyStatus;
                manualAssetEntry.PropertyType = input.PropertyType;
                manualAssetEntry.PurchasePrice = input.PurchasePrice;
                manualAssetEntry.StateId = Convert.ToInt32(input.StateId);
                manualAssetEntry.TaxesInsuranceAndOther = input.TaxesInsuranceAndOther;
                manualAssetEntry.ZipCode = input.ZipCode;

                if (input.StockAndBonds != null && input.StockAndBonds.Any())
                    foreach (var stockAndBond in input.StockAndBonds)
                    {
                        if (!stockAndBond.Id.HasValue || stockAndBond.Id.Value == default)
                        {
                            var dbStockAndBond = new Stockandbond
                            {
                                AccountNumber = stockAndBond.AccountNumber,
                                CompanyName = stockAndBond.CompanyName,
                                Value = Convert.ToInt64(stockAndBond.Value)
                            };
                            manualAssetEntry.Stockandbonds.Add(dbStockAndBond);
                            stockAndBonds.Add(dbStockAndBond);
                        }
                        else
                        {
                            stockAndBonds.Add(new Stockandbond
                            {
                                Id = stockAndBond.Id.Value
                            });
                            await _stockAndBondRepository.UpdateAsync(stockAndBond.Id.Value, dbStockAndBond =>
                            {
                                dbStockAndBond.AccountNumber = stockAndBond.AccountNumber;
                                dbStockAndBond.CompanyName = stockAndBond.CompanyName;
                                dbStockAndBond.Value =Convert.ToDecimal(stockAndBond.Value);

                                return Task.CompletedTask;
                            });
                        }
                    }
                manualAssetEntry.TaxesInsuranceAndOther = input.TaxesInsuranceAndOther;
                manualAssetEntry.ZipCode = input.ZipCode;
            });


            await UnitOfWorkManager.Current.SaveChangesAsync();

            if (stockAndBonds != null && stockAndBonds.Any())
            {
                for (var index = 0; index < stockAndBonds.Count; index++)
                {
                    input.StockAndBonds[index].Id = stockAndBonds[index].Id;
                }
            }
            return input;
        }
    }
}
