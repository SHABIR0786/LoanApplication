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
    public class DeclarationService : AbpServiceBase, IDeclarationService
    {
        private readonly IRepository<Declaration, long> _repository;
        private readonly IRepository<DeclarationBorrowereDemographicsInformation, long> _declarationBorrowerRepository;

        public DeclarationService(
            IRepository<Declaration, long> repository,
            IRepository<DeclarationBorrowereDemographicsInformation, long> declarationBorrowerRepository)
        {
            _repository = repository;
            _declarationBorrowerRepository = declarationBorrowerRepository;
        }

        public DeclarationService(IRepository<Declaration, long> repository)
        {
            _repository = repository;
        }

        public async Task<DeclarationDto> GetAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<DeclarationDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<DeclarationDto> CreateAsync(DeclarationDto input)
        {
            try
            {
                var expense = new Declaration
                {
                    Id = input.Id,
                    IsOutstandingJudgmentsAgainstYou = input.IsOutstandingJudgmentsAgainstYou,
                    IsDeclaredBankrupt = input.IsDeclaredBankrupt,
                    IsPropertyForeClosedUponOrGivenTitle = input.IsPropertyForeClosedUponOrGivenTitle,
                    IsPartyToLawsuit = input.IsPartyToLawsuit,
                    IsObligatedOnAnyLoanWhichResultedForeclosure = input.IsObligatedOnAnyLoanWhichResultedForeclosure,
                    IsPresentlyDelinquent = input.IsPresentlyDelinquent,
                    IsObligatedToPayAlimonyChildSupport = input.IsObligatedToPayAlimonyChildSupport,
                    IsAnyPartOfTheDownPayment = input.IsAnyPartOfTheDownPayment,
                    IsCoMakerOrEndorser = input.IsCoMakerOrEndorser,
                    IsUSCitizen = input.IsUSCitizen,
                    IsPermanentResidentSlien = input.IsPermanentResidentSlien,
                    IsIntendToOccupyThePropertyAsYourPrimary = input.IsIntendToOccupyThePropertyAsYourPrimary,
                    IsOwnershipInterestInPropertyInTheLastThreeYears = input.IsOwnershipInterestInPropertyInTheLastThreeYears,
                    DeclarationsSection = input.DeclarationsSection,
                };
                await _repository.InsertAsync(expense);
                await UnitOfWorkManager.Current.SaveChangesAsync();

                input.Id = expense.Id;
                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<DeclarationBorrowereDemographicsInformationDto> CreateDeclarationBorrowereDemographicsInformation(DeclarationBorrowereDemographicsInformationDto input)
        {
            try
            {
                var model = new DeclarationBorrowereDemographicsInformation
                {
                    Id = input.Id,
                    IsHispanicOrLatino = input.IsHispanicOrLatino,
                    IsMexican = input.IsMexican,
                    IsPuertoRican = input.IsPuertoRican,
                    IsCuban = input.IsCuban,
                    IsOtherHispanicOrLatino = input.IsOtherHispanicOrLatino,
                    Origin = input.Origin,
                    IsNotHispanicOrLatino = input.IsNotHispanicOrLatino,
                    IsNotProvideInformation = input.IsNotProvideInformation,
                    IsAmericanIndianOrAlaskaNative = input.IsAmericanIndianOrAlaskaNative,
                    NameOfEnrolledOrPrincipalTribe = input.NameOfEnrolledOrPrincipalTribe,
                    IsAsian = input.IsAsian,
                    IsAsianIndian = input.IsAsianIndian,
                    IsChinese = input.IsChinese,
                    IsFilipino = input.IsFilipino,
                    IsJapanese = input.IsJapanese,
                    IsKorean = input.IsKorean,
                    IsVietnamese = input.IsVietnamese,
                    IsOtherAsian = input.IsOtherAsian,
                    EnterRace = input.EnterRace,
                    IsWhite = input.IsWhite,
                    IsWishToprovideInformation = input.IsWishToprovideInformation,
                    IsMale = input.IsMale,
                    IsFemale = input.IsFemale,
                    IsDonotProvideSexInformattion = input.IsDonotProvideSexInformattion,
                };
                await _declarationBorrowerRepository.InsertAsync(model);
                await UnitOfWorkManager.Current.SaveChangesAsync();

                input.Id = model.Id;
                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<DeclarationDto> UpdateAsync(DeclarationDto input)
        {
            await _repository.UpdateAsync(input.Id, expense =>
            {
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
