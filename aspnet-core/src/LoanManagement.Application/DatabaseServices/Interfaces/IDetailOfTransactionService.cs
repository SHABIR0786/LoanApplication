using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IDetailOfTransactionService : IAsyncCrudAppService<DetailsOfTransactionDto, long, PagedLoanApplicationResultRequestDto, DetailsOfTransactionDto, DetailsOfTransactionDto>
    {
    }
}
