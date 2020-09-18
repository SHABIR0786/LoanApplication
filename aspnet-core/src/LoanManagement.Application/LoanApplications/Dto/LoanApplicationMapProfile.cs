using AutoMapper;

namespace LoanManagement.LoanApplications.Dto
{
    public class LoanApplicationMapProfile : Profile
    {
        public LoanApplicationMapProfile()
        {
            CreateMap<LoanApplicationDto, LoanApplication>();
            CreateMap<MortgageTypeDto, MortgageType>();
            CreateMap<PropertyInformationDto, PropertyInformation>();
            CreateMap<BorrowerInformationDto, BorrowerInformation>();
            CreateMap<BorrowerEmploymentInformationDto, BorrowerEmploymentInformation>();
        }
    }
}
