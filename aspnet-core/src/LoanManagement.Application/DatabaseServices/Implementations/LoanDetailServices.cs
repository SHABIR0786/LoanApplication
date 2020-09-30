using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class LoanDetailServices : AbpServiceBase, ILoanDetailServices
    {
        private readonly IRepository<LoanDetail, long> _repository;

        public LoanDetailServices(IRepository<LoanDetail, long> repository)
        {
            _repository = repository;
        }

        public async Task<LoanDetailDto> GetAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<LoanDetailDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<LoanDetailDto> CreateAsync(LoanDetailDto input)
        {
            try
            {
                var loanDetail = new LoanDetail
                {
                    City = input.City,
                    CurrentLoanAmount = input.CurrentLoanAmount,
                    DownPaymentAmount = input.DownPaymentAmount,
                    DownPaymentPercentage = input.DownPaymentPercentage,
                    EstimatedPurchasePrice = input.EstimatedPurchasePrice,
                    EstimatedValue = input.EstimatedValue,
                    GiftAmount = input.GiftAmount,
                    GiftExplanation = input.GiftExplanation,
                    HaveSecondMortgage = input.HaveSecondMortgage,
                    IsWorkingWithOfficer = input.IsWorkingWithOfficer,
                    LoanOfficerId = input.LoanOfficerId,
                    OriginalPrice = input.OriginalPrice,
                    PayLoanWithNewLoan = input.PayLoanWithNewLoan,
                    PropertyTypeId = input.PropertyTypeId,
                    PropertyUseId = input.PropertyUseId,
                    PurposeOfLoan = input.PurposeOfLoan,
                    RefinancingCurrentHome = input.RefinancingCurrentHome,
                    ReferredBy = input.ReferredBy,
                    RequestedLoanAmount = input.RequestedLoanAmount,
                    SecondMortgageAmount = input.SecondMortgageAmount,
                    SourceOfDownPayment = input.SourceOfDownPayment,
                    StateId = input.StateId,
                    YearAcquired = input.YearAcquired
                };
                await _repository.InsertAsync(loanDetail);
                await UnitOfWorkManager.Current.SaveChangesAsync();

                input.Id = loanDetail.Id;
                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<LoanDetailDto> UpdateAsync(LoanDetailDto input)
        {
            await _repository.UpdateAsync(input.Id, loanDetail =>
            {
                loanDetail.City = input.City;
                loanDetail.CurrentLoanAmount = input.CurrentLoanAmount;
                loanDetail.DownPaymentAmount = input.DownPaymentAmount;
                loanDetail.DownPaymentPercentage = input.DownPaymentPercentage;
                loanDetail.EstimatedPurchasePrice = input.EstimatedPurchasePrice;
                loanDetail.EstimatedValue = input.EstimatedValue;
                loanDetail.GiftAmount = input.GiftAmount;
                loanDetail.GiftExplanation = input.GiftExplanation;
                loanDetail.HaveSecondMortgage = input.HaveSecondMortgage;
                loanDetail.IsWorkingWithOfficer = input.IsWorkingWithOfficer;
                loanDetail.LoanOfficerId = input.LoanOfficerId;
                loanDetail.OriginalPrice = input.OriginalPrice;
                loanDetail.PayLoanWithNewLoan = input.PayLoanWithNewLoan;
                loanDetail.PropertyTypeId = input.PropertyTypeId;
                loanDetail.PropertyUseId = input.PropertyUseId;
                loanDetail.PurposeOfLoan = input.PurposeOfLoan;
                loanDetail.RefinancingCurrentHome = input.RefinancingCurrentHome;
                loanDetail.ReferredBy = input.ReferredBy;
                loanDetail.RequestedLoanAmount = input.RequestedLoanAmount;
                loanDetail.SecondMortgageAmount = input.SecondMortgageAmount;
                loanDetail.SourceOfDownPayment = input.SourceOfDownPayment;
                loanDetail.StateId = input.StateId;
                loanDetail.YearAcquired = input.YearAcquired;

                return Task.CompletedTask;
            });

            await UnitOfWorkManager.Current.SaveChangesAsync();
            return input;
        }

        public Task DeleteAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }
    }
}
