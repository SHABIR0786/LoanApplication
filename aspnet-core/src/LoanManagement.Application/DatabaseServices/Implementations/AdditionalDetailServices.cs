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
    public class AdditionalDetailServices : AbpServiceBase, IAdditionalDetailService
    {
        private readonly IRepository<AdditionalDetail, long> _repository;

        public AdditionalDetailServices(IRepository<AdditionalDetail, long> repository)
        {
            _repository = repository;
        }

        public async Task<AdditionalDetailsDto> GetAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<AdditionalDetailsDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<AdditionalDetailsDto> CreateAsync(AdditionalDetailsDto input)
        {
            try
            {
                var additionalDetail = new AdditionalDetail
                {
                    Id = input.Id,
                    NameOfIndividualsOnTitle = input.NameOfIndividualsOnTitle,
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

        public async Task<AdditionalDetailsDto> UpdateAsync(AdditionalDetailsDto input)
        {
            await _repository.UpdateAsync(input.Id, additionalDetail =>
            {
                additionalDetail.NameOfIndividualsOnTitle = input.NameOfIndividualsOnTitle;
                additionalDetail.LoanApplicationId = input.LoanApplicationId.Value;
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
