using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Enums;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using System;
using System.Linq;
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

        public Task<DeclarationDto> GetAsync(EntityDto<long?> input)
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
                Declaration borrowerDeclaration = null;
                Declaration coBorrowerDeclaration = null;
                DeclarationBorrowereDemographicsInformation borrowerDemographic = null;
                DeclarationBorrowereDemographicsInformation coBorrowerDemographic = null;

                if (input.BorrowerDeclaration != null)
                {
                    borrowerDeclaration = new Declaration
                    {
                        IsOutstandingJudgmentsAgainstYou = input.BorrowerDeclaration.IsOutstandingJudgmentsAgainstYou,
                        IsDeclaredBankrupt = input.BorrowerDeclaration.IsDeclaredBankrupt,
                        IsPropertyForeClosedUponOrGivenTitle = input.BorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle,
                        IsPartyToLawsuit = input.BorrowerDeclaration.IsPartyToLawsuit,
                        IsObligatedOnAnyLoanWhichResultedForeclosure = input.BorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure,
                        IsPresentlyDelinquent = input.BorrowerDeclaration.IsPresentlyDelinquent,
                        IsObligatedToPayAlimonyChildSupport = input.BorrowerDeclaration.IsObligatedToPayAlimonyChildSupport,
                        IsAnyPartOfTheDownPayment = input.BorrowerDeclaration.IsAnyPartOfTheDownPayment,
                        IsCoMakerOrEndorser = input.BorrowerDeclaration.IsCoMakerOrEndorser,
                        IsUSCitizen = input.BorrowerDeclaration.IsUSCitizen,
                        IsPermanentResidentSlien = input.BorrowerDeclaration.IsPermanentResidentSlien,
                        IsIntendToOccupyThePropertyAsYourPrimary = input.BorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary,
                        IsOwnershipInterestInPropertyInTheLastThreeYears = input.BorrowerDeclaration.IsOwnershipInterestInPropertyInTheLastThreeYears,
                        DeclarationsSection = input.BorrowerDeclaration.DeclarationsSection,
                        LoanApplicationId = input.LoanApplicationId,
                        BorrowerTypeId = (int)Enums.BorrowerType.Borrower
                    };
                    await _repository.InsertAsync(borrowerDeclaration);
                }

                if (input.CoBorrowerDeclaration != null)
                {
                    coBorrowerDeclaration = new Declaration
                    {
                        IsOutstandingJudgmentsAgainstYou = input.CoBorrowerDeclaration.IsOutstandingJudgmentsAgainstYou,
                        IsDeclaredBankrupt = input.CoBorrowerDeclaration.IsDeclaredBankrupt,
                        IsPropertyForeClosedUponOrGivenTitle = input.CoBorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle,
                        IsPartyToLawsuit = input.CoBorrowerDeclaration.IsPartyToLawsuit,
                        IsObligatedOnAnyLoanWhichResultedForeclosure = input.CoBorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure,
                        IsPresentlyDelinquent = input.CoBorrowerDeclaration.IsPresentlyDelinquent,
                        IsObligatedToPayAlimonyChildSupport = input.CoBorrowerDeclaration.IsObligatedToPayAlimonyChildSupport,
                        IsAnyPartOfTheDownPayment = input.CoBorrowerDeclaration.IsAnyPartOfTheDownPayment,
                        IsCoMakerOrEndorser = input.CoBorrowerDeclaration.IsCoMakerOrEndorser,
                        IsUSCitizen = input.CoBorrowerDeclaration.IsUSCitizen,
                        IsPermanentResidentSlien = input.CoBorrowerDeclaration.IsPermanentResidentSlien,
                        IsIntendToOccupyThePropertyAsYourPrimary = input.CoBorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary,
                        IsOwnershipInterestInPropertyInTheLastThreeYears = input.CoBorrowerDeclaration.IsOwnershipInterestInPropertyInTheLastThreeYears,
                        DeclarationsSection = input.CoBorrowerDeclaration.DeclarationsSection,
                        LoanApplicationId = input.LoanApplicationId,
                        BorrowerTypeId = (int)Enums.BorrowerType.CoBorrower
                    };
                    await _repository.InsertAsync(coBorrowerDeclaration);
                }

                if (input.BorrowerDemographic != null)
                {
                    borrowerDemographic = new DeclarationBorrowereDemographicsInformation
                    {
                        BorrowerTypeId = (int)Enums.BorrowerType.Borrower,
                        LoanApplicationId = input.LoanApplicationId
                    };

                    if (input.BorrowerDemographic.Ethnicity != null && input.BorrowerDemographic.Ethnicity.Any())
                        foreach (var ethnic in input.BorrowerDemographic.Ethnicity)
                            switch ((Ethnic)ethnic.Id)
                            {
                                case Ethnic.HispanicOrLatino:
                                    borrowerDemographic.IsHispanicOrLatino = true;
                                    break;
                                case Ethnic.Mexican:
                                    borrowerDemographic.IsMexican = true;
                                    break;
                                case Ethnic.PuertoRican:
                                    borrowerDemographic.IsPuertoRican = true;
                                    break;
                                case Ethnic.Cuban:
                                    borrowerDemographic.IsCuban = true;
                                    break;
                                case Ethnic.OtherHispanicOrLatino:
                                    borrowerDemographic.IsOtherHispanicOrLatino = true;
                                    borrowerDemographic.Origin = ethnic.OtherValue;
                                    break;
                                case Ethnic.NotHispanicOrLatino:
                                    borrowerDemographic.IsNotHispanicOrLatino = true;
                                    break;
                                case Ethnic.CanNotProvideEthnic:
                                    borrowerDemographic.CanNotProvideEthnic = true;
                                    break;
                                default:
                                    break;
                            }

                    if (input.BorrowerDemographic.Race != null && input.BorrowerDemographic.Race.Any())
                        foreach (var race in input.BorrowerDemographic.Race)
                        {
                            switch ((Race)race.Id)
                            {
                                case Race.AmericanIndianOrAlaskaNative:
                                    borrowerDemographic.IsAmericanIndianOrAlaskaNative = true;
                                    borrowerDemographic.NameOfEnrolledOrPrincipalTribe = race.OtherValue;
                                    break;
                                case Race.Asian:
                                    borrowerDemographic.IsAsian = true;
                                    break;
                                case Race.AsianIndian:
                                    borrowerDemographic.IsAsianIndian = true;
                                    break;
                                case Race.Chinese:
                                    borrowerDemographic.IsChinese = true;
                                    break;
                                case Race.Filipino:
                                    borrowerDemographic.IsFilipino = true;
                                    break;
                                case Race.Japanese:
                                    borrowerDemographic.IsJapanese = true;
                                    break;
                                case Race.Korean:
                                    borrowerDemographic.IsKorean = true;
                                    break;
                                case Race.Vietnamese:
                                    borrowerDemographic.IsVietnamese = true;
                                    break;
                                case Race.OtherAsian:
                                    borrowerDemographic.IsOtherAsian = true;
                                    break;
                                case Race.BlackOrAfricanAmerican:
                                    borrowerDemographic.IsBlackOrAfricanAmerican = true;
                                    break;
                                case Race.NativeHawaiianOrOtherPacificIslander:
                                    borrowerDemographic.IsNativeHawaiianOrOtherPacificIslander = true;
                                    break;
                                case Race.NativeHawaiian:
                                    borrowerDemographic.IsNativeHawaiian = true;
                                    break;
                                case Race.GuamanianOrChamorro:
                                    borrowerDemographic.IsGuamanianOrChamorro = true;
                                    break;
                                case Race.Samoan:
                                    borrowerDemographic.IsSamoan = true;
                                    break;
                                case Race.OtherPacificIslander:
                                    borrowerDemographic.IsOtherPacificIslander = true;
                                    borrowerDemographic.EnterRace = race.OtherValue;
                                    break;
                                case Race.White:
                                    borrowerDemographic.IsWhite = true;
                                    break;
                                case Race.CanNotProvideRace:
                                    borrowerDemographic.CanNotProvideRace = true;
                                    break;
                                default:
                                    break;
                            }
                        }

                    if (input.BorrowerDemographic.Sex != null && input.BorrowerDemographic.Sex.Any())
                        foreach (var sex in input.BorrowerDemographic.Sex)
                        {
                            switch ((Sex)sex.Id)
                            {
                                case Sex.Female:
                                    borrowerDemographic.IsFemale = true;
                                    break;
                                case Sex.Male:
                                    borrowerDemographic.IsMale = true;
                                    break;
                                case Sex.CanNotProvideSex:
                                    borrowerDemographic.CanNotProvideSex = true;
                                    break;
                                default:
                                    break;
                            }
                        }

                    await _declarationBorrowerRepository.InsertAsync(borrowerDemographic);
                }

                if (input.CoBorrowerDemographic != null)
                {
                    coBorrowerDemographic = new DeclarationBorrowereDemographicsInformation
                    {
                        BorrowerTypeId = (int)Enums.BorrowerType.CoBorrower,
                        LoanApplicationId = input.LoanApplicationId
                    };
                    if (input.CoBorrowerDemographic.Ethnicity != null && input.CoBorrowerDemographic.Ethnicity.Any())
                        foreach (var ethnic in input.CoBorrowerDemographic.Ethnicity)
                            switch ((Ethnic)ethnic.Id)
                            {
                                case Ethnic.HispanicOrLatino:
                                    coBorrowerDemographic.IsHispanicOrLatino = true;
                                    break;
                                case Ethnic.Mexican:
                                    coBorrowerDemographic.IsMexican = true;
                                    break;
                                case Ethnic.PuertoRican:
                                    coBorrowerDemographic.IsPuertoRican = true;
                                    break;
                                case Ethnic.Cuban:
                                    coBorrowerDemographic.IsCuban = true;
                                    break;
                                case Ethnic.OtherHispanicOrLatino:
                                    coBorrowerDemographic.IsOtherHispanicOrLatino = true;
                                    coBorrowerDemographic.Origin = ethnic.OtherValue;
                                    break;
                                case Ethnic.NotHispanicOrLatino:
                                    coBorrowerDemographic.IsNotHispanicOrLatino = true;
                                    break;
                                case Ethnic.CanNotProvideEthnic:
                                    coBorrowerDemographic.CanNotProvideEthnic = true;
                                    break;
                                default:
                                    break;
                            }

                    if (input.CoBorrowerDemographic.Race != null && input.CoBorrowerDemographic.Race.Any())
                        foreach (var race in input.CoBorrowerDemographic.Race)
                        {
                            switch ((Race)race.Id)
                            {
                                case Race.AmericanIndianOrAlaskaNative:
                                    coBorrowerDemographic.IsAmericanIndianOrAlaskaNative = true;
                                    coBorrowerDemographic.NameOfEnrolledOrPrincipalTribe = race.OtherValue;
                                    break;
                                case Race.Asian:
                                    coBorrowerDemographic.IsAsian = true;
                                    break;
                                case Race.AsianIndian:
                                    coBorrowerDemographic.IsAsianIndian = true;
                                    break;
                                case Race.Chinese:
                                    coBorrowerDemographic.IsChinese = true;
                                    break;
                                case Race.Filipino:
                                    coBorrowerDemographic.IsFilipino = true;
                                    break;
                                case Race.Japanese:
                                    coBorrowerDemographic.IsJapanese = true;
                                    break;
                                case Race.Korean:
                                    coBorrowerDemographic.IsKorean = true;
                                    break;
                                case Race.Vietnamese:
                                    coBorrowerDemographic.IsVietnamese = true;
                                    break;
                                case Race.OtherAsian:
                                    coBorrowerDemographic.IsOtherAsian = true;
                                    break;
                                case Race.BlackOrAfricanAmerican:
                                    coBorrowerDemographic.IsBlackOrAfricanAmerican = true;
                                    break;
                                case Race.NativeHawaiianOrOtherPacificIslander:
                                    coBorrowerDemographic.IsNativeHawaiianOrOtherPacificIslander = true;
                                    break;
                                case Race.NativeHawaiian:
                                    coBorrowerDemographic.IsNativeHawaiian = true;
                                    break;
                                case Race.GuamanianOrChamorro:
                                    coBorrowerDemographic.IsGuamanianOrChamorro = true;
                                    break;
                                case Race.Samoan:
                                    coBorrowerDemographic.IsSamoan = true;
                                    break;
                                case Race.OtherPacificIslander:
                                    coBorrowerDemographic.IsOtherPacificIslander = true;
                                    coBorrowerDemographic.EnterRace = race.OtherValue;
                                    break;
                                case Race.White:
                                    coBorrowerDemographic.IsWhite = true;
                                    break;
                                case Race.CanNotProvideRace:
                                    coBorrowerDemographic.CanNotProvideRace = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                    if (input.CoBorrowerDemographic.Sex != null && input.CoBorrowerDemographic.Sex.Any())
                        foreach (var sex in input.CoBorrowerDemographic.Sex)
                        {
                            switch ((Sex)sex.Id)
                            {
                                case Sex.Female:
                                    coBorrowerDemographic.IsFemale = true;
                                    break;
                                case Sex.Male:
                                    coBorrowerDemographic.IsMale = true;
                                    break;
                                case Sex.CanNotProvideSex:
                                    coBorrowerDemographic.CanNotProvideSex = true;
                                    break;
                                default:
                                    break;
                            }
                        }

                    await _declarationBorrowerRepository.InsertAsync(coBorrowerDemographic);
                }

                await UnitOfWorkManager.Current.SaveChangesAsync();

                if (borrowerDeclaration != null)
                    input.BorrowerDeclaration.Id = borrowerDeclaration.Id;
                if (coBorrowerDeclaration != null)
                    input.CoBorrowerDeclaration.Id = coBorrowerDeclaration.Id;
                if (borrowerDemographic != null)
                    input.BorrowerDemographic.Id = borrowerDemographic.Id;
                if (coBorrowerDemographic != null)
                    input.CoBorrowerDemographic.Id = coBorrowerDemographic.Id;

                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //public async Task<DeclarationBorrowereDemographicsInformationDto> CreateDeclarationBorrowereDemographicsInformation(DeclarationBorrowereDemographicsInformationDto input)
        //{
        //    try
        //    {
        //        var model = new DeclarationBorrowereDemographicsInformation
        //        {
        //            Id = input.Id,
        //            IsHispanicOrLatino = input.IsHispanicOrLatino,
        //            IsMexican = input.IsMexican,
        //            IsPuertoRican = input.IsPuertoRican,
        //            IsCuban = input.IsCuban,
        //            IsOtherHispanicOrLatino = input.IsOtherHispanicOrLatino,
        //            Origin = input.Origin,
        //            IsNotHispanicOrLatino = input.IsNotHispanicOrLatino,
        //            IsNotProvideInformation = input.IsNotProvideInformation,
        //            IsAmericanIndianOrAlaskaNative = input.IsAmericanIndianOrAlaskaNative,
        //            NameOfEnrolledOrPrincipalTribe = input.NameOfEnrolledOrPrincipalTribe,
        //            IsAsian = input.IsAsian,
        //            IsAsianIndian = input.IsAsianIndian,
        //            IsChinese = input.IsChinese,
        //            IsFilipino = input.IsFilipino,
        //            IsJapanese = input.IsJapanese,
        //            IsKorean = input.IsKorean,
        //            IsVietnamese = input.IsVietnamese,
        //            IsOtherAsian = input.IsOtherAsian,
        //            EnterRace = input.EnterRace,
        //            IsWhite = input.IsWhite,
        //            IsWishToprovideInformation = input.IsWishToprovideInformation,
        //            IsMale = input.IsMale,
        //            IsFemale = input.IsFemale,
        //            IsDonotProvideSexInformattion = input.IsDonotProvideSexInformattion,
        //        };
        //        await _declarationBorrowerRepository.InsertAsync(model);
        //        await UnitOfWorkManager.Current.SaveChangesAsync();

        //        input.Id = model.Id;
        //        return input;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        public async Task<DeclarationDto> UpdateAsync(DeclarationDto input)
        {
            await _repository.UpdateAsync(input.Id.Value, expense =>
            {
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
