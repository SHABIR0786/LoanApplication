using AutoMapper;
using LoanManagement.Borrower_Information;

namespace LoanManagement.BorrowerEmploymentInformations.Dto
{
    public class BorrowerEmploymentInformationDtoMapProfile : Profile
    {
        public BorrowerEmploymentInformationDtoMapProfile()
        {
            CreateMap<BorrowerEmploymentInformationDto, BorrowerEmploymentInformation>();
        }
    }
}
