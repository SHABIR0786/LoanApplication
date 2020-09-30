using Abp.Application.Services;
using LoanManagement.Models;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IPersonalInformationService : IAsyncCrudAppService<PersonalInformationDto, long, PagedLoanApplicationResultRequestDto, PersonalInformationDto, PersonalInformationDto>
    {
    }
}