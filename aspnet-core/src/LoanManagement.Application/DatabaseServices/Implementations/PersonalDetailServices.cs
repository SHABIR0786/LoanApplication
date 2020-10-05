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
    public class PersonalDetailServices : AbpServiceBase, IPersonalDetailService
    {
        private readonly IRepository<PersonalDetail, long> _repository;
        private readonly IRepository<Borrower, long> _borrowerRepository;

        public PersonalDetailServices(
            IRepository<PersonalDetail, long> repository,
            IRepository<Borrower, long> borrowerRepository
            )
        {
            _repository = repository;
            _borrowerRepository = borrowerRepository;
        }

        public async Task<PersonalInformationDto> GetAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<PersonalInformationDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonalInformationDto> CreateAsync(PersonalInformationDto input)
        {
            try
            {


                if (input.Borrower != null)
                {
                    var borrower = new Borrower
                    {
                        Id = input.Borrower.Id,
                        FirstName = input.Borrower.FirstName,
                        LastName = input.Borrower.LastName,
                        Suffix = input.Borrower.Suffix,
                        Email = input.Borrower.Email,
                        DateOfBirth = input.Borrower.DateOfBirth,
                        SocialSecurityNumber = input.Borrower.SocialSecurityNumber,
                        MaritalStatusId = input.Borrower.MaritalStatusId,
                        NumberOfDependents = input.Borrower.NumberOfDependents,
                        CellPhone = input.Borrower.CellPhone,
                        HomePhone = input.Borrower.HomePhone,
                        PersonalDetailId = input.Borrower.PersonalDetailId,
                        BorrowerTypeId = (int)Enums.BorrowerType.CoBorrower
                    };

                    await _borrowerRepository.InsertAsync(borrower);
                    input.Borrower.Id = borrower.Id;
                }

                if (input.CoBorrower != null)
                {
                    var borrower = new Borrower
                    {
                        Id = input.CoBorrower.Id,
                        FirstName = input.CoBorrower.FirstName,
                        LastName = input.CoBorrower.LastName,
                        Suffix = input.CoBorrower.Suffix,
                        Email = input.CoBorrower.Email,
                        DateOfBirth = input.CoBorrower.DateOfBirth,
                        SocialSecurityNumber = input.CoBorrower.SocialSecurityNumber,
                        MaritalStatusId = input.CoBorrower.MaritalStatusId,
                        NumberOfDependents = input.CoBorrower.NumberOfDependents,
                        CellPhone = input.CoBorrower.CellPhone,
                        HomePhone = input.CoBorrower.HomePhone,
                        PersonalDetailId = input.Borrower.PersonalDetailId,
                        BorrowerTypeId = (int)Enums.BorrowerType.CoBorrower

                    };

                    await _borrowerRepository.InsertAsync(borrower);
                    input.CoBorrower.Id = borrower.Id;
                }

                var personalDetail = new PersonalDetail
                {
                    IsApplyingWithCoBorrower = input.IsApplyingWithCoBorrower,
                    UseIncomeOfPersonOtherThanBorrower = input.UseIncomeOfPersonOtherThanBorrower,
                    AgreePrivacyPolicy = input.AgreePrivacyPolicy,
                    BorrowerId = input.CoBorrower?.Id,
                    CoBorrowerId = input.Borrower?.Id,
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

        public async Task<PersonalInformationDto> UpdateAsync(PersonalInformationDto input)
        {
            await _repository.UpdateAsync(input.Id, personalDetail =>
            {
                personalDetail.Id = input.Id;
                personalDetail.IsApplyingWithCoBorrower = input.IsApplyingWithCoBorrower;
                personalDetail.UseIncomeOfPersonOtherThanBorrower = input.UseIncomeOfPersonOtherThanBorrower;
                personalDetail.AgreePrivacyPolicy = input.AgreePrivacyPolicy;
                // personalDetail.Addresses= input.
            
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
