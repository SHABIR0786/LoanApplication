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
    public class CreditAuthAgreementService : AbpServiceBase, ICreditAuthAgreementService
    {
        private readonly IRepository<CreditAuthAgreement, long> _repository;

        public CreditAuthAgreementService(IRepository<CreditAuthAgreement, long> repository)
        {
            _repository = repository;
        }

        public async Task<CreditAuthAgreementDto> GetAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<CreditAuthAgreementDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<CreditAuthAgreementDto> CreateAsync(CreditAuthAgreementDto input)
        {
            try
            {
                var creditAuthAgreement = new CreditAuthAgreement
                {
                    Id = input.Id,
                    AgreeCreditAuthAgreement = input.AgreeCreditAuthAgreement
                };
                await _repository.InsertAsync(creditAuthAgreement);
                await UnitOfWorkManager.Current.SaveChangesAsync();

                input.Id = creditAuthAgreement.Id;
                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CreditAuthAgreementDto> UpdateAsync(CreditAuthAgreementDto input)
        {
            await _repository.UpdateAsync(input.Id, creditAuthAgreement =>
            {
                creditAuthAgreement.Id = input.Id;
                creditAuthAgreement.AgreeCreditAuthAgreement = input.AgreeCreditAuthAgreement;
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
