using System.Threading.Tasks;
using Abp.Application.Services;
using LoanManagement.Models;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IPersonalDetailService : IAsyncCrudAppService<PersonalInformationDto, long?, PagedLoanApplicationResultRequestDto, PersonalInformationDto, PersonalInformationDto>
    {
    }
}