using AutoMapper;
using LoanManagement.Property_Information;

namespace LoanManagement.LoanApplications.Dto
{
    public class LoanApplicationMapProfile : Profile
    {
        public LoanApplicationMapProfile()
        {
            CreateMap<LoanApplicationDto, LoanApplication>();
            CreateMap<MortgageTypeDto, MortgageType>();
            CreateMap<PropertyInformationDto, PropertyInformation>();
        }
    }
}
