using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface ILoanDetailServices : IAsyncCrudAppService<LoanDetailDto, long?, PagedLoanApplicationResultRequestDto, LoanDetailDto, LoanDetailDto>
    {
    }
}
