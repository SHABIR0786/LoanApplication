using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IEConsentService : IAsyncCrudAppService<EConsentDto, long?, PagedLoanApplicationResultRequestDto, EConsentDto, EConsentDto>
    {
    }
}
