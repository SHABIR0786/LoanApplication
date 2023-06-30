using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Enums;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class DeclarationService : AbpServiceBase, IDeclarationService
    {
        private readonly IRepository<Declaration, long> _repository;
        private readonly IRepository<Declarationborroweredemographicsinformation, long> _declarationBorrowerRepository;

        public DeclarationService(
            IRepository<Declaration, long> repository,
            IRepository<Declarationborroweredemographicsinformation, long> declarationBorrowerRepository)
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
        public async Task<List<Declaration>> GetAllDeclrationByLoanApplicationIdAsync(long loanApplicationId)
        {
            return await _repository.GetAll()
                .Where(i => i.LoanApplicationId == loanApplicationId)
                .Select(i => new Declaration
                {
                    IsOutstandingJudgmentsAgainstYou = i.IsOutstandingJudgmentsAgainstYou,
                    IsDeclaredBankrupt = i.IsDeclaredBankrupt,
                    IsPropertyForeClosedUponOrGivenTitle = i.IsPropertyForeClosedUponOrGivenTitle,
                    IsPartyToLawsuit = i.IsPartyToLawsuit,
                    IsObligatedOnAnyLoanWhichResultedForeclosure = i.IsObligatedOnAnyLoanWhichResultedForeclosure,
                    IsPresentlyDelinquent = i.IsPresentlyDelinquent,
                    IsObligatedToPayAlimonyChildSupport = i.IsObligatedToPayAlimonyChildSupport,
                    IsAnyPartOfTheDownPayment = i.IsAnyPartOfTheDownPayment,
                    IsCoMakerOrEndorser = i.IsCoMakerOrEndorser,
                    IsUscitizen = i.IsUscitizen,
                    IsPermanentResidentSlien = i.IsPermanentResidentSlien,
                    IsIntendToOccupyThePropertyAsYourPrimary = i.IsIntendToOccupyThePropertyAsYourPrimary,
                    IsOwnershipInterestInPropertyInTheLastThreeYears = i.IsOwnershipInterestInPropertyInTheLastThreeYears,
                    DeclarationsSection = i.DeclarationsSection,
                    LoanApplicationId = i.LoanApplicationId,
                    BorrowerTypeId = i.BorrowerTypeId,
                    Id = i.Id
                })
                .ToListAsync();
        }
        public async Task<List<Declarationborroweredemographicsinformation>> GetAllDemographicInformationByLoanApplicationIdAsync(long loanApplicationId)
        {
            return await _repository.GetAll()
                .Where(i => i.LoanApplicationId == loanApplicationId)
                .Select(i => new Declarationborroweredemographicsinformation
                {
                    BorrowerTypeId = i.BorrowerTypeId,
                    LoanApplicationId = i.LoanApplicationId,
                    Id = i.Id
                })
                .ToListAsync();
        }
        public async Task<DeclarationDto> CreateAsync(DeclarationDto input)
        {
            try
            {
                Declaration borrowerDeclaration = null;
                Declaration coBorrowerDeclaration = null;
                Declarationborroweredemographicsinformation borrowerDemographic = null;
                Declarationborroweredemographicsinformation coBorrowerDemographic = null;

                if (input.BorrowerDeclaration != null)
                {
                    if (!input.BorrowerDeclaration.Id.HasValue || input.BorrowerDeclaration.Id.Value == default)
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
                            IsUscitizen = input.BorrowerDeclaration.IsUSCitizen,
                            IsPermanentResidentSlien = input.BorrowerDeclaration.IsPermanentResidentSlien,
                            IsIntendToOccupyThePropertyAsYourPrimary = input.BorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary,
                            IsOwnershipInterestInPropertyInTheLastThreeYears = input.BorrowerDeclaration.IsOwnershipInterestInPropertyInTheLastThreeYears,
                            DeclarationsSection = input.BorrowerDeclaration.DeclarationsSection,
                            LoanApplicationId = input.LoanApplicationId,
                            BorrowerTypeId = (int)Enums.BorrowerType.Borrower
                        };
                        await _repository.InsertAsync(borrowerDeclaration);
                    }
                    else
                    {
                        await _repository.UpdateAsync(input.BorrowerDeclaration.Id.Value, declaration =>
                        {
                            declaration.IsOutstandingJudgmentsAgainstYou = input.BorrowerDeclaration.IsOutstandingJudgmentsAgainstYou;
                            declaration.IsDeclaredBankrupt = input.BorrowerDeclaration.IsDeclaredBankrupt;
                            declaration.IsPropertyForeClosedUponOrGivenTitle = input.BorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle;
                            declaration.IsPartyToLawsuit = input.BorrowerDeclaration.IsPartyToLawsuit;
                            declaration.IsObligatedOnAnyLoanWhichResultedForeclosure = input.BorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure;
                            declaration.IsPresentlyDelinquent = input.BorrowerDeclaration.IsPresentlyDelinquent;
                            declaration.IsObligatedToPayAlimonyChildSupport = input.BorrowerDeclaration.IsObligatedToPayAlimonyChildSupport;
                            declaration.IsAnyPartOfTheDownPayment = input.BorrowerDeclaration.IsAnyPartOfTheDownPayment;
                            declaration.IsCoMakerOrEndorser = input.BorrowerDeclaration.IsCoMakerOrEndorser;
                            declaration.IsUscitizen = input.BorrowerDeclaration.IsUSCitizen;
                            declaration.IsPermanentResidentSlien = input.BorrowerDeclaration.IsPermanentResidentSlien;
                            declaration.IsIntendToOccupyThePropertyAsYourPrimary = input.BorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary;
                            declaration.IsOwnershipInterestInPropertyInTheLastThreeYears = input.BorrowerDeclaration.IsOwnershipInterestInPropertyInTheLastThreeYears;
                            declaration.DeclarationsSection = input.BorrowerDeclaration.DeclarationsSection;
                            declaration.LoanApplicationId = input.LoanApplicationId;
                            declaration.BorrowerTypeId = (int)Enums.BorrowerType.Borrower;

                            return Task.CompletedTask;
                        });
                    }
                }

                if (input.CoBorrowerDeclaration != null)
                {
                    if (!input.CoBorrowerDeclaration.Id.HasValue || input.CoBorrowerDeclaration.Id.Value == default)
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
                            IsUscitizen = input.CoBorrowerDeclaration.IsUSCitizen,
                            IsPermanentResidentSlien = input.CoBorrowerDeclaration.IsPermanentResidentSlien,
                            IsIntendToOccupyThePropertyAsYourPrimary = input.CoBorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary,
                            IsOwnershipInterestInPropertyInTheLastThreeYears = input.CoBorrowerDeclaration.IsOwnershipInterestInPropertyInTheLastThreeYears,
                            DeclarationsSection = input.CoBorrowerDeclaration.DeclarationsSection,
                            LoanApplicationId = input.LoanApplicationId,
                            BorrowerTypeId = (int)Enums.BorrowerType.CoBorrower
                        };
                        await _repository.InsertAsync(coBorrowerDeclaration);
                    }
                    else
                    {
                        await _repository.UpdateAsync(input.CoBorrowerDeclaration.Id.Value, declaration =>
                        {
                            declaration.IsOutstandingJudgmentsAgainstYou = input.CoBorrowerDeclaration.IsOutstandingJudgmentsAgainstYou;
                            declaration.IsDeclaredBankrupt = input.CoBorrowerDeclaration.IsDeclaredBankrupt;
                            declaration.IsPropertyForeClosedUponOrGivenTitle = input.CoBorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle;
                            declaration.IsPartyToLawsuit = input.CoBorrowerDeclaration.IsPartyToLawsuit;
                            declaration.IsObligatedOnAnyLoanWhichResultedForeclosure = input.CoBorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure;
                            declaration.IsPresentlyDelinquent = input.CoBorrowerDeclaration.IsPresentlyDelinquent;
                            declaration.IsObligatedToPayAlimonyChildSupport = input.CoBorrowerDeclaration.IsObligatedToPayAlimonyChildSupport;
                            declaration.IsAnyPartOfTheDownPayment = input.CoBorrowerDeclaration.IsAnyPartOfTheDownPayment;
                            declaration.IsCoMakerOrEndorser = input.CoBorrowerDeclaration.IsCoMakerOrEndorser;
                            declaration.IsUscitizen = input.CoBorrowerDeclaration.IsUSCitizen;
                            declaration.IsPermanentResidentSlien = input.CoBorrowerDeclaration.IsPermanentResidentSlien;
                            declaration.IsIntendToOccupyThePropertyAsYourPrimary = input.CoBorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary;
                            declaration.IsOwnershipInterestInPropertyInTheLastThreeYears = input.CoBorrowerDeclaration.IsOwnershipInterestInPropertyInTheLastThreeYears;
                            declaration.DeclarationsSection = input.CoBorrowerDeclaration.DeclarationsSection;
                            declaration.LoanApplicationId = input.LoanApplicationId;
                            declaration.BorrowerTypeId = (int)Enums.BorrowerType.CoBorrower;

                            return Task.CompletedTask;
                        });
                    }
                }

                if (input.BorrowerDemographic != null)
                {
                    if (!input.BorrowerDemographic.Id.HasValue || input.BorrowerDemographic.Id == default)
                    {
                        borrowerDemographic = new Declarationborroweredemographicsinformation
                        {
                            BorrowerTypeId = (int)Enums.BorrowerType.Borrower,
                            LoanApplicationId = input.LoanApplicationId
                        };

                        FillDemographicData(input.BorrowerDemographic, borrowerDemographic);

                        await _declarationBorrowerRepository.InsertAsync(borrowerDemographic);
                    }
                    else
                    {
                        await _declarationBorrowerRepository.UpdateAsync(input.BorrowerDemographic.Id.Value, borrowerDemographic =>
                        {
                            FillDemographicData(input.BorrowerDemographic, borrowerDemographic);

                            return Task.CompletedTask;
                        });
                    }
                }

                if (input.CoBorrowerDemographic != null)
                {
                    if (!input.CoBorrowerDemographic.Id.HasValue || input.BorrowerDemographic.Id == default)
                    {
                        coBorrowerDemographic = new Declarationborroweredemographicsinformation
                        {
                            BorrowerTypeId = (int)Enums.BorrowerType.CoBorrower,
                            LoanApplicationId = input.LoanApplicationId
                        };
                        FillDemographicData(input.CoBorrowerDemographic, coBorrowerDemographic);
                        await _declarationBorrowerRepository.InsertAsync(coBorrowerDemographic);
                    }
                    else
                    {
                        await _declarationBorrowerRepository.UpdateAsync(input.CoBorrowerDemographic.Id.Value, borrowerDemographic =>
                        {
                            FillDemographicData(input.CoBorrowerDemographic, borrowerDemographic);

                            return Task.CompletedTask;
                        });
                    }
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

        private void FillDemographicData(DemographicDto demographic,Declarationborroweredemographicsinformation borrowerDemographic)
        {
            borrowerDemographic.IsAmericanIndianOrAlaskaNative = false;
            borrowerDemographic.IsAsian = false;
            borrowerDemographic.IsAsianIndian = false;
            borrowerDemographic.IsBlackOrAfricanAmerican = false;
            borrowerDemographic.IsChinese = false;
            borrowerDemographic.IsCuban = false;
            borrowerDemographic.IsFilipino = false;
            borrowerDemographic.IsGuamanianOrChamorro = false;
            borrowerDemographic.IsHispanicOrLatino = false;
            borrowerDemographic.IsJapanese = false;
            borrowerDemographic.IsKorean = false;
            borrowerDemographic.IsMexican = false;
            borrowerDemographic.IsNativeHawaiianOrOtherPacificIslander = false;
            borrowerDemographic.IsNotHispanicOrLatino = false;
            borrowerDemographic.IsOtherAsian = false;
            borrowerDemographic.IsOtherHispanicOrLatino = false;
            borrowerDemographic.IsOtherPacificIslander = false;
            borrowerDemographic.IsPuertoRican = false;
            borrowerDemographic.IsSamoan = false;
            borrowerDemographic.IsVietnamese = false;
            borrowerDemographic.IsWhite = false;
            borrowerDemographic.Origin = "";
            borrowerDemographic.NameOfEnrolledOrPrincipalTribe = "";
            borrowerDemographic.EnterRace = "";

            if (demographic.Ethnicity != null && demographic.Ethnicity.Any())
                foreach (var ethnic in demographic.Ethnicity)
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

            if (demographic.Race != null && demographic.Race.Any())
                foreach (var race in demographic.Race)
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

            if (demographic.Sex != null && demographic.Sex.Any())
                foreach (var sex in demographic.Sex)
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
        }
    }
}
