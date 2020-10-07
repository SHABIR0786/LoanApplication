using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class LoanAppService : AbpServiceBase, ILoanAppService
    {
        private readonly IRepository<LoanApplication, long> _repository;
        private readonly ILoanDetailServices _loanDetailServices;
        private readonly IAdditionalDetailService _additionalDetailsService;
        private readonly IExpenseService _expensesService;
        private readonly IEConsentService _eConsentService;
        private readonly ICreditAuthAgreementService _creditAuthAgreementService;
        private readonly IEmploymentIncomeService _employmentIncomeService;
        private readonly IPersonalDetailService _personalDetailService;
        private readonly IDeclarationService _declarationService;
        private readonly IManualAssetEntryService _manualAssetEntryService;

        public LoanAppService(
            IRepository<LoanApplication, long> repository,
            ILoanDetailServices loanDetailServices,
            IAdditionalDetailService additionalDetailsService,
            IExpenseService expensesService,
            IEConsentService eConsentService,
            ICreditAuthAgreementService creditAuthAgreementService,
            IEmploymentIncomeService employmentIncomeService,
            IPersonalDetailService personalDetailService,
            IDeclarationService declarationService,
            IManualAssetEntryService manualAssetEntryService
            )
        {
            _repository = repository;
            _loanDetailServices = loanDetailServices;
            _additionalDetailsService = additionalDetailsService;
            _expensesService = expensesService;
            _eConsentService = eConsentService;
            _creditAuthAgreementService = creditAuthAgreementService;
            _employmentIncomeService = employmentIncomeService;
            _personalDetailService = personalDetailService;
            _declarationService = declarationService;
            _manualAssetEntryService = manualAssetEntryService;
        }

        public async Task<LoanApplicationDto> GetAsync(EntityDto<long?> input)
        {
            try
            {
                var result = await _repository.GetAllIncluding(i =>
                    i.LoanDetail,
                    i => i.AdditionalDetail,
                    i => i.PersonalDetail,
                    i => i.AdditionalIncomes,
                    i => i.CreditAuthAgreement,
                    i => i.ConsentDetail,
                    i => i.Expense
                    )
                   .SingleAsync(i => i.Id == input.Id);

                var viewModel = new LoanApplicationDto
                {
                    AdditionalDetails = new AdditionalDetailsDto
                    {
                        Id = result.AdditionalDetail.Id,
                        NameOfIndividualsOnTitle = result.AdditionalDetail.NameOfIndividualsOnTitle,
                    },
                    LoanDetails = new LoanDetailDto
                    {
                        IsWorkingWithOfficer = result.LoanDetail.IsWorkingWithOfficer,
                        LoanOfficerId = result.LoanDetail.LoanOfficerId,
                        ReferredBy = result.LoanDetail.ReferredBy,
                        PurposeOfLoan = result.LoanDetail.PurposeOfLoan,
                        EstimatedValue = result.LoanDetail.EstimatedValue,
                        CurrentLoanAmount = result.LoanDetail.CurrentLoanAmount,
                        RequestedLoanAmount = result.LoanDetail.RequestedLoanAmount,
                        EstimatedPurchasePrice = result.LoanDetail.EstimatedPurchasePrice,
                        DownPaymentAmount = result.LoanDetail.DownPaymentAmount,
                        DownPaymentPercentage = result.LoanDetail.DownPaymentPercentage,
                        SourceOfDownPayment = result.LoanDetail.SourceOfDownPayment,
                        GiftAmount = result.LoanDetail.GiftAmount,
                        GiftExplanation = result.LoanDetail.GiftExplanation,
                        HaveSecondMortgage = result.LoanDetail.HaveSecondMortgage,
                        SecondMortgageAmount = result.LoanDetail.SecondMortgageAmount,
                        PayLoanWithNewLoan = result.LoanDetail.PayLoanWithNewLoan,
                        RefinancingCurrentHome = result.LoanDetail.RefinancingCurrentHome,
                        YearAcquired = result.LoanDetail.YearAcquired,
                        OriginalPrice = result.LoanDetail.OriginalPrice,
                        City = result.LoanDetail.City,
                        StateId = result.LoanDetail.StateId,
                        PropertyTypeId = result.LoanDetail.PropertyTypeId,
                        PropertyUseId = result.LoanDetail.PropertyUseId
                    },

                    Expenses = new ExpensesDto
                    {
                        IsLiveWithFamilySelectRent = result.Expense.IsLiveWithFamilySelectRent,
                        Rent = result.Expense.Rent,
                        OtherHousingExpenses = result.Expense.OtherHousingExpenses,
                        FirstMortgage = result.Expense.FirstMortgage,
                        SecondMortgage = result.Expense.SecondMortgage,
                        HazardInsurance = result.Expense.HazardInsurance,
                        RealEstateTaxes = result.Expense.RealEstateTaxes,
                        MortgageInsurance = result.Expense.MortgageInsurance,
                        HomeOwnersAssociation = result.Expense.HomeOwnersAssociation
                    },

                    OrderCredit = new CreditAuthAgreementDto
                    {
                        AgreeCreditAuthAgreement = result.CreditAuthAgreement.AgreeCreditAuthAgreement,
                    },

                    EConsent = new EConsentDto
                    {
                        AgreeEConsent = result.ConsentDetail.AgreeEConsent,
                        FirstName = result.ConsentDetail.FirstName,
                        LastName = result.ConsentDetail.LastName,
                        Email = result.ConsentDetail.Email
                    },

                };



                if (result.Declarations != null && result.Declarations.Any())
                {
                    viewModel.Declaration = new DeclarationDto();
                    foreach (var declaration in result.Declarations)
                    {
                        if (declaration.BorrowerTypeId == (int)Enums.BorrowerType.Borrower)
                        {
                            viewModel.Declaration.BorrowerDeclaration = new DeclarationDetailDto
                            {
                                DeclarationsSection = declaration.DeclarationsSection,
                                IsOutstandingJudgmentsAgainstYou = declaration.IsOutstandingJudgmentsAgainstYou,
                                IsDeclaredBankrupt = declaration.IsDeclaredBankrupt,
                                IsPropertyForeClosedUponOrGivenTitle = declaration.IsPropertyForeClosedUponOrGivenTitle,
                                IsPartyToLawsuit = declaration.IsPartyToLawsuit,
                                IsObligatedOnAnyLoanWhichResultedForeclosure = declaration.IsObligatedOnAnyLoanWhichResultedForeclosure,
                                IsPresentlyDelinquent = declaration.IsPresentlyDelinquent,
                                IsObligatedToPayAlimonyChildSupport = declaration.IsObligatedToPayAlimonyChildSupport,
                                IsAnyPartOfTheDownPayment = declaration.IsAnyPartOfTheDownPayment,
                                IsCoMakerOrEndorser = declaration.IsCoMakerOrEndorser,
                                IsUSCitizen = declaration.IsUSCitizen,
                                IsPermanentResidentSlien = declaration.IsPermanentResidentSlien,
                                IsIntendToOccupyThePropertyAsYourPrimary = declaration.IsIntendToOccupyThePropertyAsYourPrimary,
                                IsOwnershipInterestInPropertyInTheLastThreeYears = declaration.IsOwnershipInterestInPropertyInTheLastThreeYears
                            };
                        }

                        if (declaration.BorrowerTypeId == (int)Enums.BorrowerType.CoBorrower)
                        {
                            viewModel.Declaration.CoBorrowerDeclaration = new DeclarationDetailDto
                            {
                                DeclarationsSection = declaration.DeclarationsSection,
                                IsOutstandingJudgmentsAgainstYou = declaration.IsOutstandingJudgmentsAgainstYou,
                                IsDeclaredBankrupt = declaration.IsDeclaredBankrupt,
                                IsPropertyForeClosedUponOrGivenTitle = declaration.IsPropertyForeClosedUponOrGivenTitle,
                                IsPartyToLawsuit = declaration.IsPartyToLawsuit,
                                IsObligatedOnAnyLoanWhichResultedForeclosure = declaration.IsObligatedOnAnyLoanWhichResultedForeclosure,
                                IsPresentlyDelinquent = declaration.IsPresentlyDelinquent,
                                IsObligatedToPayAlimonyChildSupport = declaration.IsObligatedToPayAlimonyChildSupport,
                                IsAnyPartOfTheDownPayment = declaration.IsAnyPartOfTheDownPayment,
                                IsCoMakerOrEndorser = declaration.IsCoMakerOrEndorser,
                                IsUSCitizen = declaration.IsUSCitizen,
                                IsPermanentResidentSlien = declaration.IsPermanentResidentSlien,
                                IsIntendToOccupyThePropertyAsYourPrimary = declaration.IsIntendToOccupyThePropertyAsYourPrimary,
                                IsOwnershipInterestInPropertyInTheLastThreeYears = declaration.IsOwnershipInterestInPropertyInTheLastThreeYears

                            };
                        }
                    }
                }

                if (result.DemographicsInformations != null && result.DemographicsInformations.Any())
                {

                    viewModel.Declaration = new DeclarationDto();
                    foreach (var demographicsInformation in result.DemographicsInformations)
                    {

                        if (demographicsInformation.BorrowerTypeId == (int)Enums.BorrowerType.Borrower)
                        {
                            viewModel.Declaration.BorrowerDemographic = new DemographicDto();
                            viewModel.Declaration.BorrowerDemographic.Ethnicity = new List<DemographicTypeDto>();

                            if (demographicsInformation.IsHispanicOrLatino.HasValue &&
                                demographicsInformation.IsHispanicOrLatino.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Ethnicity.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Ethnic.HispanicOrLatino
                                });
                            }

                            if (demographicsInformation.IsMexican.HasValue &&
                               demographicsInformation.IsMexican.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Ethnicity.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Ethnic.Mexican
                                });
                            }

                            if (demographicsInformation.IsPuertoRican.HasValue &&
                               demographicsInformation.IsPuertoRican.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Ethnicity.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Ethnic.PuertoRican
                                });
                            }

                            if (demographicsInformation.IsCuban.HasValue &&
                                demographicsInformation.IsCuban.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Ethnicity.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Ethnic.Cuban
                                });
                            }

                            if (demographicsInformation.IsOtherHispanicOrLatino.HasValue &&
                               demographicsInformation.IsOtherHispanicOrLatino.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Ethnicity.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Ethnic.OtherHispanicOrLatino,
                                    OtherValue = demographicsInformation.Origin
                                });
                            }

                            if (demographicsInformation.IsNotHispanicOrLatino.HasValue &&
                               demographicsInformation.IsNotHispanicOrLatino.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Ethnicity.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Ethnic.NotHispanicOrLatino,

                                });
                            }
                            if (demographicsInformation.CanNotProvideEthnic.HasValue &&
                               demographicsInformation.CanNotProvideEthnic.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Ethnicity.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Ethnic.CanNotProvideEthnic,

                                });
                            }

                            viewModel.Declaration.BorrowerDemographic.Race = new List<DemographicTypeDto>();

                            if (demographicsInformation.IsAmericanIndianOrAlaskaNative.HasValue &&
                               demographicsInformation.IsAmericanIndianOrAlaskaNative.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.AmericanIndianOrAlaskaNative,

                                });
                            }
                            if (demographicsInformation.IsAsian.HasValue &&
                               demographicsInformation.IsAsian.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.Asian,

                                });
                            }

                            if (demographicsInformation.IsAsianIndian.HasValue &&
                                demographicsInformation.IsAsianIndian.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.AsianIndian,

                                });
                            }

                            if (demographicsInformation.IsChinese.HasValue &&
                               demographicsInformation.IsChinese.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.Chinese,

                                });
                            }

                            if (demographicsInformation.IsFilipino.HasValue &&
                               demographicsInformation.IsFilipino.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.Filipino,

                                });
                            }
                            if (demographicsInformation.IsJapanese.HasValue &&
                               demographicsInformation.IsJapanese.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.Japanese,

                                });
                            }
                            if (demographicsInformation.IsKorean.HasValue &&
                               demographicsInformation.IsKorean.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.Korean,

                                });
                            }

                            if (demographicsInformation.IsVietnamese.HasValue &&
                               demographicsInformation.IsVietnamese.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.Vietnamese,

                                });
                            }

                            if (demographicsInformation.IsOtherAsian.HasValue &&
                               demographicsInformation.IsOtherAsian.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.OtherAsian,

                                });
                            }
                            if (demographicsInformation.IsBlackOrAfricanAmerican.HasValue &&
                               demographicsInformation.IsBlackOrAfricanAmerican.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.BlackOrAfricanAmerican,

                                });
                            }
                            if (demographicsInformation.IsNativeHawaiianOrOtherPacificIslander.HasValue &&
                               demographicsInformation.IsNativeHawaiianOrOtherPacificIslander.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.NativeHawaiianOrOtherPacificIslander,

                                });
                            }
                            if (demographicsInformation.IsNativeHawaiian.HasValue &&
                               demographicsInformation.IsNativeHawaiian.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.NativeHawaiian,

                                });
                            }
                            if (demographicsInformation.IsGuamanianOrChamorro.HasValue &&
                                demographicsInformation.IsGuamanianOrChamorro.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.GuamanianOrChamorro,

                                });
                            }
                            if (demographicsInformation.IsSamoan.HasValue &&
                                demographicsInformation.IsSamoan.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.Samoan,

                                });
                            }
                            if (demographicsInformation.IsOtherPacificIslander.HasValue &&
                               demographicsInformation.IsOtherPacificIslander.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.OtherPacificIslander,
                                    OtherValue = demographicsInformation.Origin

                                });
                            }
                            if (demographicsInformation.IsWhite.HasValue &&
                               demographicsInformation.IsWhite.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.White,

                                });
                            }
                            if (demographicsInformation.CanNotProvideRace.HasValue &&
                                demographicsInformation.CanNotProvideRace.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.CanNotProvideRace,

                                });
                            }

                            viewModel.Declaration.BorrowerDemographic.Sex = new List<DemographicTypeDto>();

                            if (demographicsInformation.IsFemale.HasValue &&
                              demographicsInformation.IsFemale.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Sex.Female,

                                });
                            }
                            if (demographicsInformation.IsMale.HasValue &&
                                demographicsInformation.IsMale.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Sex.Male,

                                });
                            }

                            if (demographicsInformation.CanNotProvideSex.HasValue &&
                               demographicsInformation.CanNotProvideSex.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Sex.CanNotProvideSex,

                                });
                            }

                        }
                        if (demographicsInformation.BorrowerTypeId == (int)Enums.BorrowerType.CoBorrower)
                        {
                            viewModel.Declaration.BorrowerDemographic = new DemographicDto();
                            viewModel.Declaration.BorrowerDemographic.Ethnicity = new List<DemographicTypeDto>();

                            if (demographicsInformation.IsHispanicOrLatino.HasValue &&
                                demographicsInformation.IsHispanicOrLatino.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Ethnicity.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Ethnic.HispanicOrLatino
                                });
                            }

                            if (demographicsInformation.IsMexican.HasValue &&
                               demographicsInformation.IsMexican.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Ethnicity.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Ethnic.Mexican
                                });
                            }

                            if (demographicsInformation.IsPuertoRican.HasValue &&
                               demographicsInformation.IsPuertoRican.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Ethnicity.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Ethnic.PuertoRican
                                });
                            }

                            if (demographicsInformation.IsCuban.HasValue &&
                                demographicsInformation.IsCuban.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Ethnicity.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Ethnic.Cuban
                                });
                            }

                            if (demographicsInformation.IsOtherHispanicOrLatino.HasValue &&
                               demographicsInformation.IsOtherHispanicOrLatino.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Ethnicity.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Ethnic.OtherHispanicOrLatino,
                                    OtherValue = demographicsInformation.Origin
                                });
                            }

                            if (demographicsInformation.IsNotHispanicOrLatino.HasValue &&
                               demographicsInformation.IsNotHispanicOrLatino.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Ethnicity.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Ethnic.NotHispanicOrLatino,

                                });
                            }
                            if (demographicsInformation.CanNotProvideEthnic.HasValue &&
                               demographicsInformation.CanNotProvideEthnic.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Ethnicity.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Ethnic.CanNotProvideEthnic,

                                });
                            }

                            viewModel.Declaration.BorrowerDemographic.Race = new List<DemographicTypeDto>();

                            if (demographicsInformation.IsAmericanIndianOrAlaskaNative.HasValue &&
                               demographicsInformation.IsAmericanIndianOrAlaskaNative.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.AmericanIndianOrAlaskaNative,

                                });
                            }
                            if (demographicsInformation.IsAsian.HasValue &&
                               demographicsInformation.IsAsian.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.Asian,

                                });
                            }

                            if (demographicsInformation.IsAsianIndian.HasValue &&
                                demographicsInformation.IsAsianIndian.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.AsianIndian,

                                });
                            }

                            if (demographicsInformation.IsChinese.HasValue &&
                               demographicsInformation.IsChinese.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.Chinese,

                                });
                            }

                            if (demographicsInformation.IsFilipino.HasValue &&
                               demographicsInformation.IsFilipino.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.Filipino,

                                });
                            }
                            if (demographicsInformation.IsJapanese.HasValue &&
                               demographicsInformation.IsJapanese.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.Japanese,

                                });
                            }
                            if (demographicsInformation.IsKorean.HasValue &&
                               demographicsInformation.IsKorean.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.Korean,

                                });
                            }

                            if (demographicsInformation.IsVietnamese.HasValue &&
                               demographicsInformation.IsVietnamese.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.Vietnamese,

                                });
                            }

                            if (demographicsInformation.IsOtherAsian.HasValue &&
                               demographicsInformation.IsOtherAsian.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.OtherAsian,

                                });
                            }
                            if (demographicsInformation.IsBlackOrAfricanAmerican.HasValue &&
                               demographicsInformation.IsBlackOrAfricanAmerican.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.BlackOrAfricanAmerican,

                                });
                            }
                            if (demographicsInformation.IsNativeHawaiianOrOtherPacificIslander.HasValue &&
                               demographicsInformation.IsNativeHawaiianOrOtherPacificIslander.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.NativeHawaiianOrOtherPacificIslander,

                                });
                            }
                            if (demographicsInformation.IsNativeHawaiian.HasValue &&
                               demographicsInformation.IsNativeHawaiian.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.NativeHawaiian,

                                });
                            }
                            if (demographicsInformation.IsGuamanianOrChamorro.HasValue &&
                                demographicsInformation.IsGuamanianOrChamorro.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.GuamanianOrChamorro,

                                });
                            }
                            if (demographicsInformation.IsSamoan.HasValue &&
                                demographicsInformation.IsSamoan.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.Samoan,

                                });
                            }
                            if (demographicsInformation.IsOtherPacificIslander.HasValue &&
                               demographicsInformation.IsOtherPacificIslander.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.OtherPacificIslander,
                                    OtherValue = demographicsInformation.Origin

                                });
                            }
                            if (demographicsInformation.IsWhite.HasValue &&
                               demographicsInformation.IsWhite.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.White,

                                });
                            }
                            if (demographicsInformation.CanNotProvideRace.HasValue &&
                                demographicsInformation.CanNotProvideRace.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Race.CanNotProvideRace,

                                });
                            }

                            viewModel.Declaration.BorrowerDemographic.Sex = new List<DemographicTypeDto>();

                            if (demographicsInformation.IsFemale.HasValue &&
                              demographicsInformation.IsFemale.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Sex.Female,

                                });
                            }
                            if (demographicsInformation.IsMale.HasValue &&
                                demographicsInformation.IsMale.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Sex.Male,

                                });
                            }

                            if (demographicsInformation.CanNotProvideSex.HasValue &&
                               demographicsInformation.CanNotProvideSex.Value)
                            {
                                viewModel.Declaration.BorrowerDemographic.Race.Add(new DemographicTypeDto
                                {
                                    Id = (int)Enums.Sex.CanNotProvideSex,

                                });
                            }

                        }

                    }

                }

                return viewModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<PagedResultDto<LoanApplicationDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<LoanApplicationDto> CreateAsync(LoanApplicationDto input)
        {
            try
            {
                var loanApplication = new LoanApplication();
                await _repository.InsertAsync(loanApplication);
                await UnitOfWorkManager.Current.SaveChangesAsync();
                input.Id = loanApplication.Id;
                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<LoanApplicationDto> UpdateAsync(LoanApplicationDto input)
        {
            await _repository.UpdateAsync(input.Id.Value, async loanApplication =>
            {
                #region Loadn App
                if (input.Id == 0)
                {
                    var loanApplicationOb = new LoanApplication();
                    await _repository.InsertAsync(loanApplicationOb);
                    await UnitOfWorkManager.Current.SaveChangesAsync();
                    input.Id = loanApplication.Id;
                }
                #endregion

                #region Loan Detail
                if (input.LoanDetails != null)
                {
                    if (!input.LoanDetails.Id.HasValue || input.LoanDetails.Id.Value == default)
                    {
                        input.LoanDetails = await _loanDetailServices.CreateAsync(input.LoanDetails);
                        loanApplication.LoanDetailId = input.LoanDetails.Id;
                    }
                    else
                        await _loanDetailServices.UpdateAsync(input.LoanDetails);
                }
                #endregion

                #region Personal Information
                if (input.PersonalInformation != null)
                {
                    if (!input.PersonalInformation.Id.HasValue || input.PersonalInformation.Id.Value == default)
                    {
                        input.PersonalInformation = await _personalDetailService.CreateAsync(input.PersonalInformation);
                        loanApplication.PersonalDetailId = input.PersonalInformation.Id;
                    }
                    else
                        await _personalDetailService.UpdateAsync(input.PersonalInformation);
                }
                #endregion

                #region Additional Details
                if (input.AdditionalDetails != null)
                {
                    if (!input.AdditionalDetails.Id.HasValue || input.AdditionalDetails.Id.Value == default)
                    {
                        input.AdditionalDetails = await _additionalDetailsService.CreateAsync(input.AdditionalDetails);
                        loanApplication.AdditionalDetailsId = input.AdditionalDetails.Id;
                    }
                    else
                        await _additionalDetailsService.UpdateAsync(input.AdditionalDetails);
                }
                #endregion

                #region Expenses
                if (input.Expenses != null)
                {
                    if (!input.Expenses.Id.HasValue || input.Expenses.Id.Value == default)
                    {
                        input.Expenses = await _expensesService.CreateAsync(input.Expenses);
                        loanApplication.ExpenseId = input.Expenses.Id;
                    }
                    else
                        await _expensesService.UpdateAsync(input.Expenses);
                }
                #endregion

                #region Manual Asset Entry

                if(input.ManualAssetEntries != null && input.ManualAssetEntries.Any())
                {
                    foreach (var manualAssetEntries in input.ManualAssetEntries)
                    {
                        manualAssetEntries.LoanApplicationId = input.Id.Value;

                        if (manualAssetEntries.Id.HasValue || manualAssetEntries.Id.Value == default)
                            await _manualAssetEntryService.CreateAsync(manualAssetEntries);
                        else
                            await _manualAssetEntryService.UpdateAsync(manualAssetEntries);
                    }
                }

                #endregion

                #region EConsent
                if (input.EConsent != null)
                {
                    if (!input.EConsent.Id.HasValue || input.EConsent.Id.Value == default)
                    {
                        input.EConsent = await _eConsentService.CreateAsync(input.EConsent);
                        loanApplication.ConsentDetailId = input.EConsent.Id;
                    }
                    else
                        await _eConsentService.UpdateAsync(input.EConsent);
                }
                #endregion

                #region Credit AuthAgreement
                if (input.OrderCredit != null)
                {
                    if (!input.OrderCredit.Id.HasValue || input.OrderCredit.Id.Value == default)
                    {
                        input.OrderCredit = await _creditAuthAgreementService.CreateAsync(input.OrderCredit);
                        loanApplication.CreditAuthAgreementId = input.OrderCredit.Id;
                    }
                    else
                        await _creditAuthAgreementService.UpdateAsync(input.OrderCredit);
                }
                #endregion

                #region Declaration
                if (input.Declaration != null)
                {
                    if (!input.Declaration.Id.HasValue || input.Declaration.Id.Value == default)
                    {
                        input.Declaration.LoanApplicationId = input.Id.Value;
                        input.Declaration = await _declarationService.CreateAsync(input.Declaration);
                    }
                    else
                        await _declarationService.UpdateAsync(input.Declaration);
                }
                #endregion

                #region Employment Income
                if (input.EmploymentIncome != null)
                {
                    input.EmploymentIncome.LoanApplicationId = input.Id;
                    input.EmploymentIncome = await _employmentIncomeService.CreateAsync(input.EmploymentIncome);
                }
                #endregion
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
