using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class OtherIncomeService : AbpServiceBase, IOtherIncomeService
    {
        private readonly IRepository<OtherIncome, long> _repository;
        public OtherIncomeService(IRepository<OtherIncome, long> repository)
        {
            _repository = repository;
        }

        public async Task<OtherIncomeDto> CreateAsync(OtherIncomeDto input)
        {
            var otherIncome = new OtherIncome
            {
                BorrowerTypeId =  input.BorrowerTypeId,
                LoanApplicationId = input.LoanApplicationId,
                MonthlyAmount = input.MonthlyAmount,
                Type = input.Type
            };
            await _repository.InsertAsync(otherIncome);
            await UnitOfWorkManager.Current.SaveChangesAsync();
            input.Id = otherIncome.Id;
            return input;
        }

        public Task DeleteAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<OtherIncomeDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<OtherIncomeDto> GetAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public async Task<OtherIncomeDto> UpdateAsync(OtherIncomeDto input)
        {
            await _repository.UpdateAsync(input.Id, otherIncome =>
            {
                otherIncome.BorrowerTypeId = input.BorrowerTypeId;
                otherIncome.MonthlyAmount = input.MonthlyAmount;
                otherIncome.Type = input.Type;

                return Task.CompletedTask;
            });

            await UnitOfWorkManager.Current.SaveChangesAsync();

            return input;
        }
    }
}
