using AutoMapper;
using LoanManagement.MortgageServices.MortgageFinancialInformationService.Dto;
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
            CreateMap<MortgagePropertyFinancialInformation, MortgagePropertyFinancialInformationDto>().ReverseMap();
            CreateMap<MortgageLoanOnProperyFinancialInformation, MortgageLoanOnProperyFinancialInformationDto>().ReverseMap();
            CreateMap<MortgagePropertyAdditionalFinancialInformation, MortgagePropertyAdditionalFinancialInformationDto>().ReverseMap();
            CreateMap<MortgageLoanOnAdditionalPropertyFinancialInformation, MortgageLoanOnAdditionalPropertyFinancialInformationDto>().ReverseMap();
        }
    }
}
