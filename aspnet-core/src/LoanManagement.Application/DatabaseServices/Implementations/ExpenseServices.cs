using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using System;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class ExpenseServices : AbpServiceBase, IExpenseService
    {
        private readonly IRepository<Expense, long> _repository;

        public ExpenseServices(IRepository<Expense, long> repository)
        {
            _repository = repository;
        }

        public async Task<ExpensesDto> GetAsync(EntityDto<long?> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<ExpensesDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<ExpensesDto> CreateAsync(ExpensesDto input)
        {
            try
            {
                var expense = new Expense
                {
                    IsLiveWithFamilySelectRent = input.IsLiveWithFamilySelectRent,
                    Rent = input.Rent,
                    OtherHousingExpenses = input.OtherHousingExpenses,
                    FirstMortgage = input.FirstMortgage,
                    SecondMortgage = input.SecondMortgage,
                    HazardInsurance = input.HazardInsurance,
                    RealEstateTaxes = input.RealEstateTaxes,
                    MortgageInsurance = input.MortgageInsurance,
                    HomeOwnersAssociation = input.HomeOwnersAssociation,
                };
                await _repository.InsertAsync(expense);
                await UnitOfWorkManager.Current.SaveChangesAsync();

                input.Id = expense.Id;
                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ExpensesDto> UpdateAsync(ExpensesDto input)
        {
            if (input.IsLiveWithFamilySelectRent == true)
                await _repository.UpdateAsync(input.Id.Value, expense =>
               {
                   expense.Rent = input.Rent;
                   expense.OtherHousingExpenses = input.OtherHousingExpenses;
                   expense.IsLiveWithFamilySelectRent = input.IsLiveWithFamilySelectRent;

                   return Task.CompletedTask;
               });
            else if (input.IsLiveWithFamilySelectRent == false)
                await _repository.UpdateAsync(input.Id.Value, expense =>
                  {
                      expense.IsLiveWithFamilySelectRent = input.IsLiveWithFamilySelectRent;
                      expense.FirstMortgage = input.FirstMortgage;
                      expense.SecondMortgage = input.SecondMortgage;
                      expense.HazardInsurance = input.HazardInsurance;
                      expense.RealEstateTaxes = input.RealEstateTaxes;
                      expense.MortgageInsurance = input.MortgageInsurance;
                      expense.HomeOwnersAssociation = input.HomeOwnersAssociation;

                      return Task.CompletedTask;
                  });

            await UnitOfWorkManager.Current.SaveChangesAsync();
            return input;
        }

        public Task DeleteAsync(EntityDto<long?> input)
        {
            throw new NotImplementedException();
        }
    }
}
