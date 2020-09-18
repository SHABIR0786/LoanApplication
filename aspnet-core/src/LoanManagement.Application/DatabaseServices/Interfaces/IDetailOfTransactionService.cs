using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IDetailOfTransactionService : IAsyncCrudAppService<CreateOrUpdateDetailsOfTransactionDto, long, PagedLoanApplicationResultRequestDto, CreateOrUpdateDetailsOfTransactionDto, CreateOrUpdateDetailsOfTransactionDto>
    {
    }
}
