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
    public class MortageService : AbpServiceBase, IMortageService
    {
        private readonly IRepository<MortgageType, long> _repository;
        public MortageService(IRepository<MortgageType, long> repository)
        {
            _repository = repository;
        }

        public async Task<MortgageTypeDto> CreateAsync(MortgageTypeDto input)
        {
            await _repository.InsertAsync(new MortgageType
            {
                AgencyCaseNumber = input.AgencyCaseNumber,
                AmortizationType = input.AmortizationType,
                AmortizationTypeExplain = input.AmortizationTypeExplain,
                Amount = input.Amount,
                AppliedFor = input.AppliedFor,
                InterestRate = input.InterestRate,
                LenderCaseNumber = input.LenderCaseNumber,
                NumberOfMonths = input.NumberOfMonths,
                Type = input.Type,
                TypeExplain = input.TypeExplain
            });

            await UnitOfWorkManager.Current.SaveChangesAsync();

            return input;
        }

        public Task DeleteAsync(EntityDto<int> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<MortgageTypeDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<MortgageTypeDto> GetAsync(EntityDto<int> input)
        {
            throw new NotImplementedException();
        }

        public async Task<MortgageTypeDto> UpdateAsync(MortgageTypeDto input)
        {
            await _repository.UpdateAsync(input.Id, mortage =>
            {
                mortage.AgencyCaseNumber = input.AgencyCaseNumber;
                mortage.AmortizationType = input.AmortizationType;
                mortage.AmortizationTypeExplain = input.AmortizationTypeExplain;
                mortage.Amount = input.Amount;
                mortage.AppliedFor = input.AppliedFor;
                mortage.InterestRate = input.InterestRate;
                mortage.LenderCaseNumber = input.LenderCaseNumber;
                mortage.NumberOfMonths = input.NumberOfMonths;
                mortage.Type = input.Type;
                mortage.TypeExplain = input.TypeExplain;
                return Task.CompletedTask;
            });

            await UnitOfWorkManager.Current.SaveChangesAsync();

            return input;
        }
    }
}
