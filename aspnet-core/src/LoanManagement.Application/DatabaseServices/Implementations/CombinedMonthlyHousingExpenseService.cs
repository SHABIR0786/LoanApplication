using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class CombinedMonthlyHousingExpenseService : ICombinedMonthlyHousingExpenseService
    {
        private readonly IRepository<CombinedMonthlyHousingExpense, long> _repository;

        public CombinedMonthlyHousingExpenseService(IRepository<CombinedMonthlyHousingExpense, long> repository)
        {
            _repository = repository;
        }

        public async Task<CombinedMonthlyHousingExpenseDto> CreateAsync(CombinedMonthlyHousingExpenseDto input)
        {
            var combinedMonthlyHousingExpense = new CombinedMonthlyHousingExpense
            {
                FirstMortage = input.FirstMortage,
                LoanApplicationId = input.LoanApplicationId,
                MortgageInsurance = input.MortgageInsurance,
                Other = input.Other,
                OtherMortage = input.OtherMortage,
                RealEstateTaxes = input.RealEstateTaxes,
                Rental = input.Rental,
            };
            await _repository.InsertAsync(combinedMonthlyHousingExpense);

            input.Id = combinedMonthlyHousingExpense.Id;

            return input;
        }

        public Task DeleteAsync(EntityDto<long> input)
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedResultDto<CombinedMonthlyHousingExpenseDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new System.NotImplementedException();
        }

        public Task<CombinedMonthlyHousingExpenseDto> GetAsync(EntityDto<long> input)
        {
            throw new System.NotImplementedException();
        }

        public async Task<CombinedMonthlyHousingExpenseDto> UpdateAsync(CombinedMonthlyHousingExpenseDto input)
        {
            await _repository.UpdateAsync(input.Id, combinedMonthlyHousingExpense =>
            {
                combinedMonthlyHousingExpense.FirstMortage = input.FirstMortage;
                combinedMonthlyHousingExpense.LoanApplicationId = input.LoanApplicationId;
                combinedMonthlyHousingExpense.MortgageInsurance = input.MortgageInsurance;
                combinedMonthlyHousingExpense.Other = input.Other;
                combinedMonthlyHousingExpense.OtherMortage = input.OtherMortage;
                combinedMonthlyHousingExpense.RealEstateTaxes = input.RealEstateTaxes;
                combinedMonthlyHousingExpense.Rental = input.Rental;

                return Task.CompletedTask;
            });

            return input;
        }
    }
}
