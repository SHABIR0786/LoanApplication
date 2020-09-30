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
    public class PersonalInformationService : AbpServiceBase, IPersonalInformationService
    {
        private readonly IRepository<PersonalInformation, long> _repository;

        public PersonalInformationService(IRepository<PersonalInformation, long> repository)
        {
            _repository = repository;
        }

        public async Task<PersonalInformationDto> GetAsync(EntityDto<long> input)
        {
             throw new NotImplementedException();
        }

        public async Task<PagedResultDto<PersonalInformationDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonalInformationDto> CreateAsync(PersonalInformationDto input)
        {
            try
            {
                var personalInformation = new PersonalInformation
                {
                   IsApplyingWithCoBorrower = input.IsApplyingWithCoBorrower,
                   UseIncomeOfPersonOtherThanBorrower = input.UseIncomeOfPersonOtherThanBorrower,
                   AgreePrivacyPolicy = input.AgreePrivacyPolicy,
                   Borrower = input.Borrower,
                   CoBorrower = input.CoBorrower

                };
                await _repository.InsertAsync(personalInformation);
                await UnitOfWorkManager.Current.SaveChangesAsync();

                input.Id = personalInformation.Id;
                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PersonalInformationDto> UpdateAsync(PersonalInformationDto input)
        {
            await _repository.UpdateAsync(input.Id, personalInformation =>
            { personalInformation.IsApplyingWithCoBorrower = input.IsApplyingWithCoBorrower;
                  personalInformation. UseIncomeOfPersonOtherThanBorrower = input.UseIncomeOfPersonOtherThanBorrower;
                 personalInformation.  AgreePrivacyPolicy = input.AgreePrivacyPolicy;
                 personalInformation.  Borrower = input.Borrower;
                   personalInformation.CoBorrower = input.CoBorrower;

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
