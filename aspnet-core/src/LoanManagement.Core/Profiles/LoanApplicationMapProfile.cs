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
            CreateMap<BorrowerEmploymentInformationDto, BorrowerEmploymentInformation>().ReverseMap();
        }
    }
}
