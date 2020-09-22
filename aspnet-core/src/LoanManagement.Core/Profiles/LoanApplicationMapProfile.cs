using AutoMapper;
using LoanManagement.LoanApplications.Dto;
using LoanManagement.Models;
using LoanManagement.ViewModels;

namespace LoanManagement.Profiles
{
    public class LoanApplicationMapProfile : Profile
    {
        public LoanApplicationMapProfile()
        {
            CreateMap<LoanApplicationDto, LoanApplication>().ReverseMap();
            CreateMap<MortgageTypeDto, MortgageType>().ReverseMap();
            CreateMap<PropertyInformationDto, PropertyInformation>().ReverseMap();
            CreateMap<BorrowerInformationDto, BorrowerInformation>().ReverseMap();
            CreateMap<BorrowerEmploymentInformationDto, BorrowerEmploymentInformation>().ReverseMap();
        }
    }
}
