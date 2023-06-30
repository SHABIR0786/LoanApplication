using AutoMapper;
using LoanManagement.MortgageServices.DemographicInformation.Dto;
using LoanManagement.MortgageServices.MortgageApplication.Dto;
using LoanManagement.MortgageServices.MortgageApplicationFinancialAssetService.Dto;
using LoanManagement.MortgageServices.MortgageApplicationLoanProperty.Dto;
using LoanManagement.MortgageServices.MortgageFinancialInformation.Dto;
using LoanManagement.MortgageTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageMappingProfile
{
    public class MortgageMappingProfile:Profile
    {
        public MortgageMappingProfile()
        {
            CreateMap<MortgageApplications, MortgageApplicationDto>().ReverseMap();
            CreateMap<MortgageApplicationAdditionalEmploymentDetail, MortgageApplicationAdditionalEmploymentDetailDto>().ReverseMap();
            CreateMap<MortgageApplicationContactInformation, MortgageApplicationContactInformationDto>().ReverseMap();
            CreateMap<MortgageApplicationAdditionalEmploymentIncomeDetail, MortgageApplicationAdditionalEmploymentIncomeDetailDto>().ReverseMap();
            CreateMap<MortgageApplicationCurrentAddress, MortgageApplicationCurrentAddressDto>().ReverseMap();
            CreateMap<MortgageApplicationAlternateName, MortgageApplicationAlternateNameDto>().ReverseMap();
            CreateMap<MortgageApplicationEmploymentDetail, MortgageApplicationEmploymentDetailDto>().ReverseMap();
            CreateMap<MortgageApplicationEmploymentIncomeDetail, MortgageApplicationEmploymentIncomeDetailDto>().ReverseMap();
            CreateMap<MortgageApplicationFormerAddress, MortgageApplicationFormerAddressDto>().ReverseMap();
            CreateMap<MortgageApplicationIncomeSource, MortgageApplicationIncomeSourceDto>().ReverseMap();
            CreateMap<MortgageApplicationMailingAddress, MortgageApplicationMailingAddressDto>().ReverseMap();
            CreateMap<MortgageApplicationOtherBorrower, MortgageApplicationOtherBorrowerDto>().ReverseMap();
            CreateMap<MortgageApplicationPersonalInformation, MortgageApplicationPersonalInformationDto>().ReverseMap();
            CreateMap<MortgageApplicationPreviousEmploymentDetail, MortgageApplicationPreviousEmploymentDetailDto>().ReverseMap();
            CreateMap<MortgageApplicationSource, MortgageApplicationSourceDto>().ReverseMap();
            CreateMap<MortgageApplicationTypeOfCredit, MortgageApplicationTypeOfCreditDto>().ReverseMap();
            //LoanProperty
            CreateMap<MortgageApplicationLoanPropertyInformation, MortgageApplicationLoanPropertyInformationDto>().ReverseMap();
            CreateMap<MortgageApplicationLoanPropertyAddress, MortgageApplicationLoanPropertyAddressDto>().ReverseMap();
            CreateMap<MortgageApplicationLoanPropertyGiftsOrGrants, MortgageApplicationLoanPropertyGiftsOrGrantsDto>().ReverseMap();
            CreateMap<MortgageApplicationLoanPropertyRentalIncome, MortgageApplicationLoanPropertyRentalIncomeDto>().ReverseMap();
            CreateMap<MortgageApplicationLoanPropertyOtherNewMortgageLoans, MortgageApplicationLoanPropertyOtherNewMortgageLoansDto>().ReverseMap();
            CreateMap<MortgageApplicationLoanOriginatorInformation, MortgageApplicationLoanOriginatorInformationDto>().ReverseMap();
            CreateMap<MortgageApplicationMilitaryService, MortgageApplicationMilitaryServiceDto>().ReverseMap();
            //Financila Information
            CreateMap<MortgagePropertyFinancialInformation, MortgagePropertyFinancialInformationDto>().ReverseMap();
            CreateMap<MortgageLoanOnProperyFinancialInformation, MortgageLoanOnProperyFinancialInformationDto>().ReverseMap();
            CreateMap<MortgagePropertyAdditionalFinancialInformation, MortgagePropertyAdditionalFinancialInformationDto>().ReverseMap();
            CreateMap<MortgageLoanOnAdditionalPropertyFinancialInformation, MortgageLoanOnAdditionalPropertyFinancialInformationDto>().ReverseMap();
            //Financial Info- Assets & Liabilities
            CreateMap<MortgageAppliactionFinancialAccount, MortgageAppliactionFinancialAccountDto>().ReverseMap();
            CreateMap<MortgageAppliactionFinancialCredit, MortgageAppliactionFinancialCreditDto>().ReverseMap();
            CreateMap<MortgageAppliactionFinancialLiability, MortgageApplicationFinancialLiabilityDto>().ReverseMap();
            CreateMap<MortgageAppliactionFinancialOtherLiability, MortgageApplicationFinancialOtherLiabilityDto>().ReverseMap();
            CreateMap<MortgageFinancialAccountType, MortgageFinancialAccountTypeDto>().ReverseMap();
            CreateMap<MortgageFinancialCreditType, MortgageFinancialAssetsTypeDto>().ReverseMap();
            CreateMap<MortgageFinancialLaibilitiesType, MortgageFinancialLaibilitiesTypeDto>().ReverseMap();
            CreateMap<MortgageFinancialOtherLaibilitiesType, MortgageFinancialOtherLaibilitiesTypeDto>().ReverseMap();
            //Demographic Information
            CreateMap<MortgageApplicationDemographicInformation, MortgageApplicationDemographicInformationDto>().ReverseMap();
            CreateMap<MortgageApplicaitonDempgraphicInfoByFinancialInstitution, MortgageApplicaitonDempgraphicInfoByFinancialInstitutionDto>().ReverseMap();
            //Agreement
            CreateMap<MortgageApplicationAgreement, MortgageApplicationAgreementDto>().ReverseMap();
            //Question
            CreateMap<MortgageApplicationQuestions, MortgageApplicationQuestionsDto>().ReverseMap();

        }
    }
}
