using AutoMapper;
using LoanManagement.LoanApplications.Dto;
using LoanManagement.Models;
using LoanManagement.ViewModels;

namespace LoanManagement.Profiles
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
