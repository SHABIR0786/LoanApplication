using AutoMapper;
using LoanManagement.Models;

namespace LoanManagement.ViewModels
{
    public class BorrowerEmploymentInformationDtoMapProfile : Profile
    {
        public BorrowerEmploymentInformationDtoMapProfile()
        {
            CreateMap<BorrowerEmploymentInformationDto, BorrowerEmploymentInformation>();
        }
    }
}
