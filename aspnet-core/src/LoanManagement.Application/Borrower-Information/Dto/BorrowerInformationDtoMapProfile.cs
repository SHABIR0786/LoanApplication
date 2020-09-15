using System.Linq;
using AutoMapper;
using Abp.Authorization;
using Abp.Authorization.Roles;
using LoanManagement.Authorization.Roles;
using LoanManagement.LoanApplications.Dto;
using LoanManagement.Property_Information;
using LoanManagement.BorrowerInformations;

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
