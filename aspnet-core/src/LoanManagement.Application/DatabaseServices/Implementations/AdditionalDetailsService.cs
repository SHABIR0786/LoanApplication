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
    public class AdditionalDetailsService : AbpServiceBase, IAdditionalDetailsService
    {
        private readonly IRepository<AdditionalDetails, long> _repository;

        public AdditionalDetailsService(IRepository<AdditionalDetails, long> repository)
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
                var additionalDetails = new AdditionalDetails
                {
                  NameOfIndividualsOnTitle = input.NameOfIndividualsOnTitle

                };
                await _repository.InsertAsync(additionalDetails);
                await UnitOfWorkManager.Current.SaveChangesAsync();

                input.Id = additionalDetails.Id;
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
