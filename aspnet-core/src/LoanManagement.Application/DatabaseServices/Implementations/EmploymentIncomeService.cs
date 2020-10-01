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
        private readonly IRepository<EmploymentIncome, long> _repository;

        public EmploymentIncomeService(IRepository<EmploymentIncome, long> repository)
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
                var personalDetail = new EmploymentIncome
                {
                };
                await _repository.InsertAsync(personalDetail);
                await UnitOfWorkManager.Current.SaveChangesAsync();

                input.Id = personalDetail.Id;
                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EmploymentIncomeDto> UpdateAsync(EmploymentIncomeDto input)
        {
            await _repository.UpdateAsync(input.Id, personalDetail =>
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
