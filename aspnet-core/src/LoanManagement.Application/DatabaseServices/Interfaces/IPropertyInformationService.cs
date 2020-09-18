using Abp.Application.Services;
using LoanManagement.LoanApplications.Dto;
using LoanManagement.Roles.Dto;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IPropertyInformationService : IAsyncCrudAppService<PropertyInformationDto, long, PagedLoanApplicationResultRequestDto, PropertyInformationDto, PropertyInformationDto>
    {
    }
}
