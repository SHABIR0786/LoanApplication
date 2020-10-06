using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class AdditionalIncomeService : AbpServiceBase, IAdditionalIncomeService
    {
        private readonly IRepository<AdditionalIncome, long> _repository;

        public AdditionalIncomeService(IRepository<AdditionalIncome, long> repository)
        {
            _repository = repository;
        }

        public async Task<AdditionalIncomeDto> CreateAsync(AdditionalIncomeDto input)
        {
            var additionalIncome = new AdditionalIncome
            {
                Amount = input.Amount,
                BorrowerTypeId = input.BorrowerTypeId,
                IncomeSourceId = input.IncomeSourceId,
                LoanApplicationId = input.LoanApplicationId
            };

            await _repository.InsertAsync(additionalIncome);
            await UnitOfWorkManager.Current.SaveChangesAsync();
            input.Id = additionalIncome.Id;

            return input;
        }

        public Task DeleteAsync(EntityDto<long?> input)
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedResultDto<AdditionalIncomeDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new System.NotImplementedException();
        }

        public Task<AdditionalIncomeDto> GetAsync(EntityDto<long?> input)
        {
            throw new System.NotImplementedException();
        }

        public async Task<AdditionalIncomeDto> UpdateAsync(AdditionalIncomeDto input)
        {
            var additionalIncome = new AdditionalIncome
            {
                Amount = input.Amount,
                BorrowerTypeId = input.BorrowerTypeId,
                IncomeSourceId = input.IncomeSourceId,
                LoanApplicationId = input.LoanApplicationId
            };

            await _repository.UpdateAsync(input.Id.Value, additionalIncome =>
            {
                additionalIncome.Amount = input.Amount;
                additionalIncome.IncomeSourceId = input.IncomeSourceId;

                return Task.CompletedTask;
            });
            await UnitOfWorkManager.Current.SaveChangesAsync();

            return input;
        }
    }
}
