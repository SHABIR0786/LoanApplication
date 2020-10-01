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
    public class EmploymentIncomeService : AbpServiceBase, IEmploymentIncomeService
    {
        private readonly IRepository<BorrowerMonthlyIncome, long> _repository;

        public EmploymentIncomeService(IRepository<BorrowerMonthlyIncome, long> repository)
        {
            _repository = repository;
        }

        public async Task<EmploymentIncomeDto> GetAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<EmploymentIncomeDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<EmploymentIncomeDto> CreateAsync(EmploymentIncomeDto input)
        {
            try
            {
                var employmentIncome = new BorrowerMonthlyIncome
                {
                };
                await _repository.InsertAsync(employmentIncome);
                await UnitOfWorkManager.Current.SaveChangesAsync();

                input.Id = employmentIncome.Id;
                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EmploymentIncomeDto> UpdateAsync(EmploymentIncomeDto input)
        {
            await _repository.UpdateAsync(input.Id, employmentIncome =>
            {
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
