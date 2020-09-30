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
    public class EConsentService : AbpServiceBase, IEConsentService
    {
        private readonly IRepository<EConsent, long> _repository;

        public EConsentService(IRepository<EConsent, long> repository)
        {
            _repository = repository;
        }

        public async Task<EConsentDto> GetAsync(EntityDto<long> input)
        {
             throw new NotImplementedException();
        }

        public async Task<PagedResultDto<EConsentDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<EConsentDto> CreateAsync(EConsentDto input)
        {
            try
            {
                var eConsent = new EConsent
                {
                  AgreeEConsent = input.AgreeEConsent

                };
                await _repository.InsertAsync(eConsent);
                await UnitOfWorkManager.Current.SaveChangesAsync();

                input.Id = eConsent.Id;
                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EConsentDto> UpdateAsync(EConsentDto input)
        {
            await _repository.UpdateAsync(input.Id, eConsent =>
            { 
                 eConsent.AgreeEConsent = input.AgreeEConsent;
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
