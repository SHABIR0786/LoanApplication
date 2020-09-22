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
    public class DetailOfTransactionService : AbpServiceBase, IDetailOfTransactionService
    {
        private readonly IRepository<DetailsOfTransaction, long> _repository;

        public DetailOfTransactionService(IRepository<DetailsOfTransaction, long> repository)
        {
            _repository = repository;
        }

        public async Task<CreateOrUpdateDetailsOfTransactionDto> CreateAsync(CreateOrUpdateDetailsOfTransactionDto input)
        {
            var detailsOfTransaction = new DetailsOfTransaction
            {
                Alterations = input.Alterations,
                BorrowersClosingCost = input.BorrowersClosingCost,
                CashFrom = input.CashFrom,
                Discount = input.Discount,
                EstimatedClosingCost = input.EstimatedClosingCost,
                EstimatedPreparedItem = input.EstimatedPreparedItem,
                FundingFee = input.FundingFee,
                Land = input.Land,
                LoanAmount = input.LoanAmount,
                OtherCredits = input.OtherCredits,
                PurchasePrice = input.PurchasePrice,
                Refinance = input.Refinance,
                SubOrdinateFinancing = input.SubOrdinateFinancing,
                TotalCost = input.TotalCost
            };
            await _repository.InsertAsync(detailsOfTransaction);
            await UnitOfWorkManager.Current.SaveChangesAsync();
            input.Id = detailsOfTransaction.Id;
            return input;
        }

        public Task DeleteAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<CreateOrUpdateDetailsOfTransactionDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<CreateOrUpdateDetailsOfTransactionDto> GetAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateOrUpdateDetailsOfTransactionDto> UpdateAsync(CreateOrUpdateDetailsOfTransactionDto input)
        {
            await _repository.UpdateAsync(input.Id, detailsOfTransaction =>
            {
                detailsOfTransaction.Alterations = input.Alterations;
                detailsOfTransaction.BorrowersClosingCost = input.BorrowersClosingCost;
                detailsOfTransaction.CashFrom = input.CashFrom;
                detailsOfTransaction.Discount = input.Discount;
                detailsOfTransaction.EstimatedClosingCost = input.EstimatedClosingCost;
                detailsOfTransaction.EstimatedPreparedItem = input.EstimatedPreparedItem;
                detailsOfTransaction.FundingFee = input.FundingFee;
                detailsOfTransaction.Land = input.Land;
                detailsOfTransaction.LoanAmount = input.LoanAmount;
                detailsOfTransaction.OtherCredits = input.OtherCredits;
                detailsOfTransaction.PurchasePrice = input.PurchasePrice;
                detailsOfTransaction.Refinance = input.Refinance;
                detailsOfTransaction.SubOrdinateFinancing = input.SubOrdinateFinancing;
                detailsOfTransaction.TotalCost = input.TotalCost;

                return Task.CompletedTask;
            });

            await UnitOfWorkManager.Current.SaveChangesAsync();

            return input;
        }
    }
}
