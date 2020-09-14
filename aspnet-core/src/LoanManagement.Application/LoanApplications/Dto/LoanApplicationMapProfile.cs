using System.Linq;
using AutoMapper;
using Abp.Authorization;
using Abp.Authorization.Roles;
using LoanManagement.Authorization.Roles;
using LoanManagement.LoanApplications.Dto;
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
