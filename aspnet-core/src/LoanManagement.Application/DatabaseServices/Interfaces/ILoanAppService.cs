using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface ILoanAppService : IAsyncCrudAppService<LoanApplicationDto, long, PagedLoanApplicationResultRequestDto, LoanApplicationDto, LoanApplicationDto>
    {
    }
}
