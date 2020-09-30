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
    public class ExpensesService : AbpServiceBase, IExpensesService
    {
        private readonly IRepository<Expenses, long> _repository;

        public ExpensesService(IRepository<Expenses, long> repository)
        {
            _repository = repository;
        }

        public async Task<ExpensesDto> GetAsync(EntityDto<long> input)
        {
             throw new NotImplementedException();
        }

        public async Task<PagedResultDto<ExpensesDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<ExpensesDto> CreateAsync(ExpensesDto input)
        {
            try
            {
                var expenses = new Expenses
                {
                  IsLiveWithFamilySelectRent = input.IsLiveWithFamilySelectRent,
                  FirstMortgage = input.FirstMortgage,
                  MortgageInsurance = input.MortgageInsurance,
                  HazardInsurance = input.HazardInsurance,
                  HomeOwnersAssociation = input.HomeOwnersAssociation,
                  RealEstateTaxes = input.RealEstateTaxes,
                  OtherHousingExpenses= input .OtherHousingExpenses,
                  SecondMortgage = input.SecondMortgage,
                  Rent = input.Rent
                  




                };
                await _repository.InsertAsync(expenses);
                await UnitOfWorkManager.Current.SaveChangesAsync();

                input.Id = expenses.Id;
                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ExpensesDto> UpdateAsync(ExpensesDto input)
        {
            await _repository.UpdateAsync(input.Id, expenses =>
            { 
               
                 expenses. IsLiveWithFamilySelectRent = input.IsLiveWithFamilySelectRent;
                 expenses. FirstMortgage = input.FirstMortgage;
                 expenses. MortgageInsurance = input.MortgageInsurance;
                  expenses.HazardInsurance = input.HazardInsurance;
                 expenses. HomeOwnersAssociation = input.HomeOwnersAssociation;
                 expenses. RealEstateTaxes = input.RealEstateTaxes;
                  expenses.OtherHousingExpenses= input .OtherHousingExpenses;
                 expenses. SecondMortgage = input.SecondMortgage;
                expenses.  Rent = input.Rent;
                  
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
