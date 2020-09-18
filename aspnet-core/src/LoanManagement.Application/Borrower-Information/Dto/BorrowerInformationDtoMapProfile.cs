using AutoMapper;
using LoanManagement.BorrowerInformations;
using LoanManagement.Property_Information;

namespace LoanManagement.LoanApplications.Dto
{
    public class BorrowerInformationDtoMapProfile : Profile
    {
        public BorrowerInformationDtoMapProfile()
        {
            CreateMap<BorrowerInformationDto, BorrowerInformation>();
            CreateMap<PropertyInformationDto, PropertyInformation>();
        }
    }
}
