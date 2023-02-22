using AutoMapper;
using LoanManagement.codeFirstEntities;
using LoanManagement.Models;
using LoanManagement.ViewModels;

namespace LoanManagement.Profiles
{
    public class LoanApplicationMapProfile : Profile
    {
        public LoanApplicationMapProfile()
        {
            CreateMap<LoanApplicationDto, Loanapplication>().ReverseMap();
            CreateMap<BorrowerEmploymentInformationDto, Borroweremploymentinformation>().ReverseMap();
        }
    }
}
