using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IPersonalDetailService : IAsyncCrudAppService<PersonalInformationDto, long?, PagedLoanApplicationResultRequestDto, PersonalInformationDto, PersonalInformationDto>
    {
        string GetStateId(int stateId);
    }
}