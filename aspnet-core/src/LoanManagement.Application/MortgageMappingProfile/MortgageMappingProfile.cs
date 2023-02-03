using AutoMapper;
using LoanManagement.MortgageServices.MortgageApplication.Dto;
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
        }
    }
}
