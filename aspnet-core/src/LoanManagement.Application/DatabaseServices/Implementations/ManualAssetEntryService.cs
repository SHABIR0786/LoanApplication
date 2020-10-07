﻿using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class ManualAssetEntryService : AbpServiceBase, IManualAssetEntryService
    {
        private readonly IRepository<ManualAssetEntry, long> _repository;
        private readonly IRepository<StockAndBond, long> _stockAndBondRepository;

        public ManualAssetEntryService(
            IRepository<ManualAssetEntry, long> manualAssetEntryRepository,
            IRepository<StockAndBond, long> stockAndBondRepository)
        {
            _repository = manualAssetEntryRepository;
            _stockAndBondRepository = stockAndBondRepository;
        }

        public async Task<ManualAssetEntryDto> CreateAsync(ManualAssetEntryDto input)
        {
            var manualAssetEntry = new ManualAssetEntry
            {
                AccountNumber = input.AccountNumber,
                Address = input.Address,
                Address2 = input.AccountNumber,
                AssetTypeId = input.AssetTypeId,
                BankName = input.BankName,
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
                State = input.State,
                StockAndBonds = input.StockAndBonds != null && input.StockAndBonds.Any() ? input.StockAndBonds.Select(i => new StockAndBond
                {
                    AccountNumber = i.AccountNumber,
                    CompanyName = i.CompanyName,
                    Value = i.Value
                }).ToList() : null,
                TaxesInsuranceAndOther = input.TaxesInsuranceAndOther,
                ZipCode = input.ZipCode
            };
            await _repository.InsertAsync(manualAssetEntry);


            await UnitOfWorkManager.Current.SaveChangesAsync();

            input.Id = manualAssetEntry.Id;
            if (manualAssetEntry.StockAndBonds != null && manualAssetEntry.StockAndBonds.Any())
            {
                for (var index = 0; index < manualAssetEntry.StockAndBonds.Count; index++)
                {
                    input.StockAndBonds[index].Id = manualAssetEntry.StockAndBonds[index].Id;
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

        public async Task<ManualAssetEntryDto> UpdateAsync(ManualAssetEntryDto input)
        {
            var manualAssetEntry = new ManualAssetEntry
            {

            };
            await _repository.UpdateAsync(input.Id.Value, async manualAssetEntry =>
            {
                manualAssetEntry.AccountNumber = input.AccountNumber;
                manualAssetEntry.Address = input.Address;
                manualAssetEntry.Address2 = input.AccountNumber;
                manualAssetEntry.AssetTypeId = input.AssetTypeId;
                manualAssetEntry.BankName = input.BankName;
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
                manualAssetEntry.State = input.State;

                if (input.StockAndBonds != null && input.StockAndBonds.Any())
                    foreach (var stockAndBond in input.StockAndBonds)
                    {
                        if (!stockAndBond.Id.HasValue || stockAndBond.Id.Value == default)
                        {
                            manualAssetEntry.StockAndBonds.Add(new StockAndBond
                            {
                                AccountNumber = stockAndBond.AccountNumber,
                                CompanyName = stockAndBond.CompanyName,
                                Value = stockAndBond.Value
                            });
                        }
                        else
                        {
                            await _stockAndBondRepository.UpdateAsync(stockAndBond.Id.Value, dbStockAndBond =>
                            {
                                dbStockAndBond.AccountNumber = stockAndBond.AccountNumber;
                                dbStockAndBond.CompanyName = stockAndBond.CompanyName;
                                dbStockAndBond.Value = stockAndBond.Value;

                                return Task.CompletedTask;
                            });
                        }
                    }
                manualAssetEntry.TaxesInsuranceAndOther = input.TaxesInsuranceAndOther;
                manualAssetEntry.ZipCode = input.ZipCode;
            });


            await UnitOfWorkManager.Current.SaveChangesAsync();

            if (manualAssetEntry.StockAndBonds != null && manualAssetEntry.StockAndBonds.Any())
            {
                for (var index = 0; index < manualAssetEntry.StockAndBonds.Count; index++)
                {
                    input.StockAndBonds[index].Id = manualAssetEntry.StockAndBonds[index].Id;
                }
            }
            return input;
        }
    }
}
