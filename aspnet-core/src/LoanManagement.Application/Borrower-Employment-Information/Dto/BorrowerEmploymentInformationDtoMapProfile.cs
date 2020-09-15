using System.Linq;
using AutoMapper;
using Abp.Authorization;
using Abp.Authorization.Roles;
using LoanManagement.Authorization.Roles;
using LoanManagement.LoanApplications.Dto;
using LoanManagement.Property_Information;
using LoanManagement.BorrowerInformations;
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
