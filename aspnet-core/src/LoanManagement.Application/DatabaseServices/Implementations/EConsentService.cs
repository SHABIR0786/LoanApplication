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
    public class EConsentService : AbpServiceBase, IEConsentService
    {
        private readonly IRepository<ConsentDetail, long> _repository;

        public EConsentService(IRepository<ConsentDetail, long> repository)
        {
            _repository = repository;
        }

        public async Task<EConsentDto> GetAsync(EntityDto<long?> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<EConsentDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<EConsentDto> CreateAsync(EConsentDto input)
        {
            try
            {
                var consentDetail = new ConsentDetail
                {
                    AgreeEConsent = input.AgreeEConsent,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Email = input.Email
                };
                await _repository.InsertAsync(consentDetail);
                await UnitOfWorkManager.Current.SaveChangesAsync();

                input.Id = consentDetail.Id;
                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EConsentDto> UpdateAsync(EConsentDto input)
        {
            await _repository.UpdateAsync(input.Id.Value, consentDetail =>
            {
                consentDetail.AgreeEConsent = input.AgreeEConsent;
                consentDetail.FirstName = input.FirstName;
                consentDetail.LastName = input.LastName;
                consentDetail.Email = input.Email;
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
