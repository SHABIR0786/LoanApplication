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
    public class BorrowerMonthlyIncomeServices : AbpServiceBase, IBorrowerMonthlyIncomeServices
    {
        private readonly IRepository<BorrowerMonthlyIncome, long> _repository;

        public BorrowerMonthlyIncomeServices(IRepository<BorrowerMonthlyIncome, long> repository)
        {
            _repository = repository;
        }

        public async Task<BorrowerMonthlyIncomeDto> GetAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<BorrowerMonthlyIncomeDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<BorrowerMonthlyIncomeDto> CreateAsync(BorrowerMonthlyIncomeDto input)
        {
            try
            {
                var additionalDetail = new BorrowerMonthlyIncome
                {
                    Id = input.Id,
                    Base = input.Base,
                    Overtime = input.Overtime,
                    Bonuses = input.Bonuses,
                    Commissions = input.Commissions,
                    Dividends = input.Dividends,
                    BorrowerTypeId = input.BorrowerTypeId,
                    LoanApplicationId = input.LoanApplicationId.Value,
                };
                await _repository.InsertAsync(additionalDetail);
                await UnitOfWorkManager.Current.SaveChangesAsync();

                input.Id = additionalDetail.Id;
                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<BorrowerMonthlyIncomeDto> UpdateAsync(BorrowerMonthlyIncomeDto input)
        {
            await _repository.UpdateAsync(input.Id, additionalDetail =>
            {
                additionalDetail.Base = input.Base;
                additionalDetail.Overtime = input.Overtime;
                additionalDetail.Bonuses = input.Bonuses;
                additionalDetail.Commissions = input.Commissions;
                additionalDetail.Dividends = input.Dividends;

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
