using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using LoanManagement.codeFirstEntities;
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
        private readonly IRepository<Loanapplication,long> _repository;
        private readonly ILoanDetailServices _loanDetailServices;
        private readonly IAdditionalDetailServices _additionalDetailsService;
        private readonly IExpenseService _expensesService;
        private readonly IEConsentService _eConsentService;
        private readonly ICreditAuthAgreementService _creditAuthAgreementService;
        private readonly IEmploymentIncomeService _employmentIncomeService;
        private readonly IPersonalDetailService _personalDetailService;
        private readonly IDeclarationService _declarationService;
        private readonly IManualAssetEntryService _manualAssetEntryService;
        private readonly IBorrowerMonthlyIncomeServices _borrowerMonthlyIncomeRepository;

        private readonly IBorrowerEmploymentInformationAppService _borrowerEmploymentInformationRepository;

        public IAdditionalIncomeService _additionalIncomeService { get; }

        public LoanAppService(
            IRepository<Loanapplication, long> repository,
            ILoanDetailServices loanDetailServices,
            IAdditionalDetailServices additionalDetailsService,
            IExpenseService expensesService,
            IEConsentService eConsentService,
            ICreditAuthAgreementService creditAuthAgreementService,
            IEmploymentIncomeService employmentIncomeService,
            IPersonalDetailService personalDetailService,
            IDeclarationService declarationService,
            IManualAssetEntryService manualAssetEntryService,
            IBorrowerEmploymentInformationAppService borrowerEmploymentInformationRepository,
            IBorrowerMonthlyIncomeServices borrowerMonthlyIncomeRepository,
            IAdditionalIncomeService additionalIncomeService
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
            _borrowerEmploymentInformationRepository = borrowerEmploymentInformationRepository;
            _borrowerMonthlyIncomeRepository = borrowerMonthlyIncomeRepository;
            _additionalIncomeService = additionalIncomeService;
        }

        //[UnitOfWork(isTransactional: false)]
        public async Task<LoanApplicationDto> GetAsync(EntityDto<long?> input)
        {
            //return new LoanApplicationDto();
            try
            {
                var query = _repository.GetAllIncluding(
                    i => i.LoanDetail,
                    i => i.AdditionalDetail,
                    i => i.Additionalincomes,
                    i => i.Borroweremploymentinformations,
                    i => i.Borrowermonthlyincomes,
                    i => i.CreditAuthAgreement,
                    i => i.ConsentDetail,
                    i => i.Declarations,
                    i => i.Declarationborroweredemographicsinformations,
                    i => i.Expense,
                    i => i.Manualassetentries);

                query = query.Include(i => i.PersonalDetail)
                    .ThenInclude(i => i.CoBorrower);

                query = query.Include(i => i.PersonalDetail)
                    .ThenInclude(i => i.Borrower);
                query = query.Include(i => i.PersonalDetail)
                    .ThenInclude(i => i.Addresses);

                var result = await query
                    .Where(i => i.Id == input.Id.Value)
                   .SingleAsync();

                var viewModel = new LoanApplicationDto
                {
                    Id = input.Id.Value,
                    AdditionalDetails = new AdditionalDetailsDto
                    {
                        Id = result.AdditionalDetail?.Id,
                        NameOfIndividualsOnTitle = result.AdditionalDetail?.NameOfIndividualsOnTitle,
                        NameOfIndividualsCoBorrowerOnTitle = result.AdditionalDetail?.NameOfIndividualsCoBorrowerOnTitle,
                    },
                    LoanDetails = new LoanDetailDto
                    {
                        IsWorkingWithOfficer = result.LoanDetail?.IsWorkingWithOfficer,
                        LoanOfficerId = Convert.ToInt32(result.LoanDetail?.LoanOfficerId).ToString(),
                        ReferredBy = result.LoanDetail?.ReferredBy,
                        PurposeOfLoan = result.LoanDetail?.PurposeOfLoan,
                        EstimatedValue = result.LoanDetail?.EstimatedValue,
                        CurrentLoanAmount = result.LoanDetail?.CurrentLoanAmount,
                        RequestedLoanAmount = result.LoanDetail?.RequestedLoanAmount,
                        EstimatedPurchasePrice = result.LoanDetail?.EstimatedPurchasePrice,
                        DownPaymentAmount = result.LoanDetail?.DownPaymentAmount,
                        DownPaymentPercentage = result.LoanDetail?.DownPaymentPercentage,
                        SourceOfDownPayment = result.LoanDetail.SourceOfDownPayment,
                        GiftAmount = result.LoanDetail?.GiftAmount,
                        GiftExplanation = result.LoanDetail?.GiftExplanation,
                        HaveSecondMortgage = result.LoanDetail?.HaveSecondMortgage,
                        SecondMortgageAmount = result.LoanDetail?.SecondMortgageAmount,
                        PayLoanWithNewLoan = result.LoanDetail?.PayLoanWithNewLoan,
                        RefinancingCurrentHome = result.LoanDetail?.RefinancingCurrentHome,
                        YearAcquired = result.LoanDetail?.YearAcquired,
                        OriginalPrice = result.LoanDetail?.OriginalPrice,
                        City = result.LoanDetail?.City,
                        StateId = result.LoanDetail?.StateId,
                        PropertyTypeId = result.LoanDetail?.PropertyTypeId,
                        PropertyUseId = result.LoanDetail?.PropertyUseId,
                        StartedLookingForNewHome = result.LoanDetail?.StartedLookingForNewHome,
                        Id = result.LoanDetailId
                    },
                    Expenses = new ExpensesDto
                    {
                        IsLiveWithFamilySelectRent = result.Expense?.IsLiveWithFamilySelectRent,
                        Rent = result.Expense?.Rent,
                        OtherHousingExpenses = result.Expense?.OtherHousingExpenses,
                        FirstMortgage = result.Expense?.FirstMortgage,
                        SecondMortgage = result.Expense?.SecondMortgage,
                        HazardInsurance = result.Expense?.HazardInsurance,
                        RealEstateTaxes = result.Expense?.RealEstateTaxes,
                        MortgageInsurance = result.Expense?.MortgageInsurance,
                        HomeOwnersAssociation = result.Expense?.HomeOwnersAssociation,
                        Id = result.ExpenseId,
                    },
                    OrderCredit = new CreditAuthAgreementDto
                    {
                        AgreeCreditAuthAgreement = result.CreditAuthAgreement?.AgreeCreditAuthAgreement,
                        Id = result.CreditAuthAgreementId,
                    },
                    EConsent = new EConsentDto
                    {
                        AgreeEConsent = result.ConsentDetail?.AgreeEconsent,
                        FirstName = result.ConsentDetail?.FirstName,
                        LastName = result.ConsentDetail?.LastName,
                        Email = result.ConsentDetail?.Email,
                        CoborrowerEmail = result.ConsentDetail?.CoborrowerEmail,
                        CoborrowerFirstName = result.ConsentDetail?.CoborrowerFirstName,
                        CoborrowerLastName = result.ConsentDetail?.CoborrowerLastName,
                        CoborrowerAgreeEConsent = result.ConsentDetail?.CoborrowerAgreeEconsent,
                        Id = result.ConsentDetailId,
                    },
                    PersonalInformation = new PersonalInformationDto
                    {
                        AgreePrivacyPolicy = result.PersonalDetail?.AgreePrivacyPolicy,
                        CoBorrowerIsMailingAddressSameAsResidential = result.PersonalDetail?.CoBorrowerIsMailingAddressSameAsResidential,
                        CoBorrowerResidentialAddressSameAsBorrowerResidential = result.PersonalDetail?.CoBorrowerResidentialAddressSameAsBorrowerResidential,
                        IsApplyingWithCoBorrower = result.PersonalDetail?.IsApplyingWithCoBorrower,
                        IsMailingAddressSameAsResidential = result.PersonalDetail?.IsMailingAddressSameAsResidential,
                        LoanApplicationId = result.Id,
                        UseIncomeOfPersonOtherThanBorrower = result.PersonalDetail?.UseIncomeOfPersonOtherThanBorrower,
                        Id = result?.PersonalDetailId,
                    },
                };

                if (result.PersonalDetail != null && result.PersonalDetail.Borrower != null)
                    viewModel.PersonalInformation.Borrower = new BorrowerDto
                    {
                        BorrowerTypeId = result.PersonalDetail.Borrower.BorrowerTypeId,
                        CellPhone = result.PersonalDetail.Borrower.CellPhone,
                        DateOfBirth = result.PersonalDetail.Borrower.DateOfBirth,
                        Email = result.PersonalDetail.Borrower.Email,
                        FirstName = result.PersonalDetail.Borrower.FirstName,
                        HomePhone = result.PersonalDetail.Borrower.HomePhone,
                        Id = result.PersonalDetail.Borrower.Id,
                        LastName = result.PersonalDetail.Borrower.LastName,
                        MaritalStatusId = result.PersonalDetail.Borrower.MaritalStatusId,
                        MiddleInitial = result.PersonalDetail.Borrower.MiddleInitial,
                        NumberOfDependents = result.PersonalDetail.Borrower.NumberOfDependents,
                        SocialSecurityNumber = result.PersonalDetail.Borrower.SocialSecurityNumber,
                        Suffix = result.PersonalDetail.Borrower.Suffix
                    };

                if (result.PersonalDetail != null && result.PersonalDetail.CoBorrower != null)
                    viewModel.PersonalInformation.CoBorrower = new BorrowerDto
                    {
                        BorrowerTypeId = result.PersonalDetail.CoBorrower.BorrowerTypeId,
                        CellPhone = result.PersonalDetail.CoBorrower.CellPhone,
                        DateOfBirth = result.PersonalDetail.CoBorrower.DateOfBirth,
                        Email = result.PersonalDetail.CoBorrower.Email,
                        FirstName = result.PersonalDetail.CoBorrower.FirstName,
                        HomePhone = result.PersonalDetail.CoBorrower.HomePhone,
                        Id = result.PersonalDetail.CoBorrower.Id,
                        LastName = result.PersonalDetail.CoBorrower.LastName,
                        MaritalStatusId = result.PersonalDetail.CoBorrower.MaritalStatusId,
                        MiddleInitial = result.PersonalDetail.CoBorrower.MiddleInitial,
                        NumberOfDependents = result.PersonalDetail.CoBorrower.NumberOfDependents,
                        SocialSecurityNumber = result.PersonalDetail.CoBorrower.SocialSecurityNumber,
                        Suffix = result.PersonalDetail.CoBorrower.Suffix
                    };

                if (result.PersonalDetail?.Addresses != null && result.PersonalDetail.Addresses.Any())
                {
                    foreach (var address in result.PersonalDetail.Addresses.Where(i => i.AddressType != Enums.AddressType.Previous.ToString()))
                    {
                        if (address.AddressType == Enums.AddressType.Mailing.ToString())
                        {
                            if (address.BorrowerTypeId == (int)Enums.BorrowerType.Borrower)
                            {
                                viewModel.PersonalInformation.MailingAddress = new AddressDto
                                {
                                    AddressLine1 = address.AddressLine1,
                                    AddressLine2 = address.AddressLine2,
                                    City = address.City,
                                    Id = address.Id,
                                    Months = address.Months,
                                    StateId = address.StateId,
                                    Years = address.Years,
                                    ZipCode = address.ZipCode,
                                };
                            }
                            else if (address.BorrowerTypeId == (int)Enums.BorrowerType.CoBorrower)
                            {
                                viewModel.PersonalInformation.CoBorrowerMailingAddress = new AddressDto
                                {
                                    AddressLine1 = address.AddressLine1,
                                    AddressLine2 = address.AddressLine2,
                                    City = address.City,
                                    Id = address.Id,
                                    Months = address.Months,
                                    StateId = address.StateId,
                                    Years = address.Years,
                                    ZipCode = address.ZipCode,
                                };
                            }
                        }

                        if (address.AddressType == Enums.AddressType.Residential.ToString())
                        {
                            if (address.BorrowerTypeId == (int)Enums.BorrowerType.Borrower)
                            {
                                viewModel.PersonalInformation.ResidentialAddress = new AddressDto
                                {
                                    AddressLine1 = address.AddressLine1,
                                    AddressLine2 = address.AddressLine2,
                                    City = address.City,
                                    Id = address.Id,
                                    Months = address.Months,
                                    StateId = address.StateId,
                                    Years = address.Years,
                                    ZipCode = address.ZipCode,
                                };
                            }
                            else if (address.BorrowerTypeId == (int)Enums.BorrowerType.CoBorrower)
                            {
                                viewModel.PersonalInformation.CoBorrowerResidentialAddress = new AddressDto
                                {
                                    AddressLine1 = address.AddressLine1,
                                    AddressLine2 = address.AddressLine2,
                                    City = address.City,
                                    Id = address.Id,
                                    Months = address.Months,
                                    StateId = address.StateId,
                                    Years = address.Years,
                                    ZipCode = address.ZipCode,
                                };
                            }
                        }
                    }

                }
                if (result.PersonalDetail?.Addresses != null && result.PersonalDetail.Addresses.Any())
                {
                    viewModel.PersonalInformation.PreviousAddresses = new List<AddressDto>();
                    viewModel.PersonalInformation.CoBorrowerPreviousAddresses = new List<AddressDto>();

                    foreach (var address in result.PersonalDetail.Addresses.Where(i => i.AddressType == Enums.AddressType.Previous.ToString()))
                    {
                        if (address.BorrowerTypeId == (int)Enums.BorrowerType.Borrower)
                        {
                            viewModel.PersonalInformation.PreviousAddresses.Add(new AddressDto
                            {

                                AddressLine1 = address.AddressLine1,
                                AddressLine2 = address.AddressLine2,
                                City = address.City,
                                Id = address.Id,
                                Months = address.Months,
                                StateId = address.StateId,
                                Years = address.Years,
                                ZipCode = address.ZipCode,
                            });
                        }
                        else if (address.BorrowerTypeId == (int)Enums.BorrowerType.Borrower)
                        {
                            viewModel.PersonalInformation.CoBorrowerPreviousAddresses.Add(new AddressDto
                            {
                                AddressLine1 = address.AddressLine1,
                                AddressLine2 = address.AddressLine2,
                                City = address.City,
                                Id = address.Id,
                                Months = address.Months,
                                StateId = address.StateId,
                                Years = address.Years,
                                ZipCode = address.ZipCode,
                            });
                        }
                    }
                }



                viewModel.EmploymentIncome = new EmploymentIncomeDto
                {
                    LoanApplicationId = result.Id
                };

                if (result.Additionalincomes != null && result.Additionalincomes.Any())
                {
                    viewModel.EmploymentIncome.AdditionalIncomes = new List<AdditionalIncomeDto>();
                    foreach (var additionalIncome in result.Additionalincomes)
                    {
                        viewModel.EmploymentIncome.AdditionalIncomes.Add(new AdditionalIncomeDto
                        {
                            Amount = additionalIncome.Amount,
                            IncomeSourceId = additionalIncome.IncomeSourceId,
                            LoanApplicationId = additionalIncome.LoanApplicationId,
                            BorrowerTypeId = additionalIncome.BorrowerTypeId,
                            Id = additionalIncome.Id,
                        });
                    }
                }

                if (result.Borroweremploymentinformations != null && result.Borroweremploymentinformations.Any())
                {
                    viewModel.EmploymentIncome.BorrowerEmploymentInfo = new List<BorrowerEmploymentInformationDto>();
                    viewModel.EmploymentIncome.CoBorrowerEmploymentInfo = new List<BorrowerEmploymentInformationDto>();

                    foreach (var employmentInfo in result.Borroweremploymentinformations)
                    {
                        if (employmentInfo.BorrowerTypeId == (int)Enums.BorrowerType.Borrower)
                            viewModel.EmploymentIncome.BorrowerEmploymentInfo.Add(new BorrowerEmploymentInformationDto
                            {
                                EmployerName = employmentInfo.EmployersName,
                                Address1 = employmentInfo.EmployersAddress1,
                                Address2 = employmentInfo.EmployersAddress2,
                                IsSelfEmployed = employmentInfo.IsSelfEmployed,
                                BorrowerTypeId = employmentInfo.BorrowerTypeId,
                                City = employmentInfo.City,
                                StartDate = employmentInfo.StartDate,
                                EndDate = employmentInfo.EndDate,
                                LoanApplicationId = employmentInfo.LoanApplicationId,
                                Position = employmentInfo.Position,
                                StateId = employmentInfo.StateId,
                                ZipCode = employmentInfo.ZipCode,
                                Id = employmentInfo.Id
                            });
                        else if (employmentInfo.BorrowerTypeId == (int)Enums.BorrowerType.CoBorrower)
                            viewModel.EmploymentIncome.CoBorrowerEmploymentInfo.Add(new BorrowerEmploymentInformationDto
                            {
                                EmployerName = employmentInfo.EmployersName,
                                Address1 = employmentInfo.EmployersAddress1,
                                Address2 = employmentInfo.EmployersAddress2,
                                IsSelfEmployed = employmentInfo.IsSelfEmployed,
                                BorrowerTypeId = employmentInfo.BorrowerTypeId,
                                City = employmentInfo.City,
                                StartDate = employmentInfo.StartDate,
                                EndDate = employmentInfo.EndDate,
                                LoanApplicationId = employmentInfo.LoanApplicationId,
                                Position = employmentInfo.Position,
                                StateId = employmentInfo.StateId,
                                ZipCode = employmentInfo.ZipCode,
                                Id = employmentInfo.Id
                            });
                        else
                            throw new InvalidOperationException("Invalid borrower type id");
                    }
                }

                if (result.Borrowermonthlyincomes != null && result.Borrowermonthlyincomes.Any())
                {
                    foreach (var monthlyIncome in result.Borrowermonthlyincomes)
                    {
                        if (monthlyIncome.BorrowerTypeId == (int)Enums.BorrowerType.Borrower)
                            viewModel.EmploymentIncome.BorrowerMonthlyIncome = new BorrowerMonthlyIncomeDto
                            {
                                Base = monthlyIncome.Base,
                                Bonuses = monthlyIncome.Bonuses,
                                BorrowerTypeId = monthlyIncome.BorrowerTypeId,
                                Commissions = monthlyIncome.Commissions,
                                Dividends = monthlyIncome.Dividends,
                                Id = monthlyIncome.Id,
                                LoanApplicationId = monthlyIncome.LoanApplicationId,
                                Overtime = monthlyIncome.Overtime,
                            };
                        else if (monthlyIncome.BorrowerTypeId == (int)Enums.BorrowerType.CoBorrower)
                            viewModel.EmploymentIncome.CoBorrowerMonthlyIncome = new BorrowerMonthlyIncomeDto
                            {

                                Base = monthlyIncome.Base,
                                Bonuses = monthlyIncome.Bonuses,
                                BorrowerTypeId = monthlyIncome.BorrowerTypeId,
                                Commissions = monthlyIncome.Commissions,
                                Dividends = monthlyIncome.Dividends,
                                Id = monthlyIncome.BorrowerTypeId,
                                LoanApplicationId = monthlyIncome.LoanApplicationId,
                                Overtime = monthlyIncome.Overtime,
                            };
                        else
                            throw new InvalidOperationException("Invalid borrower type id");
                    }
                }


                if (result.Manualassetentries != null && result.Manualassetentries.Any())
                {
                    viewModel.ManualAssetEntries = new List<ManualAssetEntryDto>();
                    foreach (var manualAssetEntries in result.Manualassetentries)
                    {
                        viewModel.ManualAssetEntries.Add(new ManualAssetEntryDto
                        {

                            AssetTypeId = manualAssetEntries.AssetTypeId,
                            AccountNumber = manualAssetEntries.AccountNumber,
                            Address = manualAssetEntries.Address,
                            Address2 = manualAssetEntries.Address2,
                            BankName = manualAssetEntries.BankName,
                            BorrowerTypeId = manualAssetEntries.BorrowerTypeId,
                            CashValue = manualAssetEntries.CashValue,
                            City = manualAssetEntries.City,
                            Description = manualAssetEntries.Description,
                            GrossRentalIncome = manualAssetEntries.GrossRentalIncome,
                            Id = manualAssetEntries.Id,
                            LoanApplicationId = manualAssetEntries.LoanApplicationId,
                            MonthlyMortgagePayment = manualAssetEntries.MonthlyMortgagePayment,
                            Name = manualAssetEntries.Name,
                            OutstandingMortgageBalance = manualAssetEntries.OutstandingMortgageBalance,
                            PresentMarketValue = manualAssetEntries.PresentMarketValue,
                            PropertyIsUsedAs = manualAssetEntries.PropertyIsUsedAs,
                            PropertyStatus = manualAssetEntries.PropertyStatus,
                            PropertyType = manualAssetEntries.PropertyType,
                            PurchasePrice = manualAssetEntries.PurchasePrice,
                            StateId = manualAssetEntries.StateId,
                            TaxesInsuranceAndOther = manualAssetEntries.TaxesInsuranceAndOther,
                            ZipCode = manualAssetEntries.ZipCode
                        });
                        if (result.Manualassetentries != null && manualAssetEntries.Stockandbonds.Any())
                        {
                            manualAssetEntries.Stockandbonds = manualAssetEntries.Stockandbonds.Select(i =>
                            new Stockandbond
                            {
                                AccountNumber = i.AccountNumber,
                                CompanyName = i.CompanyName,
                                ManualAssetEntryId = i.ManualAssetEntryId,
                                Value = i.Value
                            })
                            .ToList();
                        }
                    }
                }

                viewModel.Declaration = new DeclarationDto();
                if (result.Declarations != null && result.Declarations.Any())
                {
                    foreach (var declaration in result.Declarations)
                    {
                        if (declaration.BorrowerTypeId == (int)Enums.BorrowerType.Borrower)
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
                                IsUSCitizen = declaration.IsUscitizen,
                                IsPermanentResidentSlien = declaration.IsPermanentResidentSlien,
                                IsIntendToOccupyThePropertyAsYourPrimary = declaration.IsIntendToOccupyThePropertyAsYourPrimary,
                                IsOwnershipInterestInPropertyInTheLastThreeYears = declaration.IsOwnershipInterestInPropertyInTheLastThreeYears,
                                Id = declaration.Id
                            };
                        else if (declaration.BorrowerTypeId == (int)Enums.BorrowerType.CoBorrower)
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
                                IsUSCitizen = declaration.IsUscitizen,
                                IsPermanentResidentSlien = declaration.IsPermanentResidentSlien,
                                IsIntendToOccupyThePropertyAsYourPrimary = declaration.IsIntendToOccupyThePropertyAsYourPrimary,
                                IsOwnershipInterestInPropertyInTheLastThreeYears = declaration.IsOwnershipInterestInPropertyInTheLastThreeYears,
                                Id = declaration.Id
                            };
                        else
                            throw new InvalidOperationException("Invalid borrower type id");
                    }
                    viewModel.Declaration.LoanApplicationId = result.Id;
                }

                if (result.Declarationborroweredemographicsinformations != null && result.Declarationborroweredemographicsinformations.Any())
                {
                    foreach (var demographicsInformation in result.Declarationborroweredemographicsinformations)
                    {
                        if (demographicsInformation.BorrowerTypeId == (int)Enums.BorrowerType.Borrower)
                        {
                            viewModel.Declaration.BorrowerDemographic = new DemographicDto
                            {
                                Ethnicity = new List<DemographicTypeDto>(),
                                Id = demographicsInformation.Id,
                            };

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
                        else if (demographicsInformation.BorrowerTypeId == (int)Enums.BorrowerType.CoBorrower)
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
                        else
                            throw new InvalidOperationException("Invalid borrower type id");
                    }
                }

                return viewModel;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<PagedResultDto<LoanApplicationDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<LoanListDto>> GetAllCustomAsync(PagedLoanApplicationResultRequestDto input)
        {
            var data = await _repository.GetAll()
                .AsNoTracking()
                .OrderBy(i => i.UpdatedOn)
                .Select(i => new LoanListDto
                {
                    Id = i.Id,
                    Borrower = i.PersonalDetail.Borrower.FirstName + " " + i.PersonalDetail.Borrower.LastName,
                    Contact = i.PersonalDetail.Borrower.CellPhone,
                })
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToListAsync();

            var count = await _repository.CountAsync();

            return new PagedResultDto<LoanListDto>(count, data);
        }

        public async Task<LoanApplicationDto> CreateAsync(LoanApplicationDto input)
        {
            try
            {
                var loanApplication = new Loanapplication
                {
                    UpdatedOn = DateTime.UtcNow
                };
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
                loanApplication.UpdatedOn = DateTime.UtcNow;

                #region Loadn App
                if (input.Id == 0)
                {
                    var loanApplicationOb = new Loanapplication();
                    await _repository.InsertAsync(loanApplicationOb);
                    await UnitOfWorkManager.Current.SaveChangesAsync();
                    input.Id = loanApplication.Id;
                }
                #endregion

                #region Loan Detail
                if (input.LoanDetails != null)
                {
                    if (!input.LoanDetails.Id.HasValue)
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
                        loanApplication.AdditionalDetailId = input.AdditionalDetails.Id;
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

                if (input.ManualAssetEntries != null && input.ManualAssetEntries.Any())
                {
                    foreach (var manualAssetEntries in input.ManualAssetEntries)
                    {
                        manualAssetEntries.LoanApplicationId = input.Id.Value;

                        if (!manualAssetEntries.Id.HasValue || manualAssetEntries.Id.Value == default)
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
                    input.Declaration.LoanApplicationId = input.Id.Value;
                    input.Declaration = await _declarationService.CreateAsync(input.Declaration);
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
