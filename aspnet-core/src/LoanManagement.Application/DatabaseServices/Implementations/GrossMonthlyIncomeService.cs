using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class GrossMonthlyIncomeService : IGrossMonthlyIncomeService
    {
        private readonly IRepository<GrossMonthlyIncome, long> _repository;

        public GrossMonthlyIncomeService(IRepository<GrossMonthlyIncome, long> repository)
        {
            _repository = repository;
        }

        public async Task<GrossMonthlyIncomeDto> CreateAsync(GrossMonthlyIncomeDto input)
        {
            var grossMonthlyIncome = new GrossMonthlyIncome
            {
                BasicIncome = input.BasicIncome,
                Bonuses = input.Bonuses,
                BorrowerTypeId = input.BorrowerTypeId,
                Commissions = input.Commissions,
                DividendAndInterest = input.DividendAndInterest,
                LoanApplicationId = input.LoanApplicationId,
                NetRentalIncome = input.NetRentalIncome,
                Other = input.Other,
                Overtime = input.Overtime
            };
            await _repository.InsertAsync(grossMonthlyIncome);

            input.Id = grossMonthlyIncome.Id;

            return input;
        }

        public Task DeleteAsync(EntityDto<long> input)
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedResultDto<GrossMonthlyIncomeDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new System.NotImplementedException();
        }

        public Task<GrossMonthlyIncomeDto> GetAsync(EntityDto<long> input)
        {
            throw new System.NotImplementedException();
        }

        public async Task<GrossMonthlyIncomeDto> UpdateAsync(GrossMonthlyIncomeDto input)
        {
            await _repository.UpdateAsync(input.Id, grossMonthlyIncome =>
            {
                grossMonthlyIncome.BasicIncome = input.BasicIncome;
                grossMonthlyIncome.Bonuses = input.Bonuses;
                grossMonthlyIncome.BorrowerTypeId = input.BorrowerTypeId;
                grossMonthlyIncome.Commissions = input.Commissions;
                grossMonthlyIncome.DividendAndInterest = input.DividendAndInterest;
                grossMonthlyIncome.LoanApplicationId = input.LoanApplicationId;
                grossMonthlyIncome.NetRentalIncome = input.NetRentalIncome;
                grossMonthlyIncome.Other = input.Other;
                grossMonthlyIncome.Overtime = input.Overtime;

                return Task.CompletedTask;
            });

            return input;
        }
    }
}
