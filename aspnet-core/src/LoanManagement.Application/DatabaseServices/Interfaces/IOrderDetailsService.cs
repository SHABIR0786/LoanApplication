using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IOrderDetailsService : IAsyncCrudAppService<OrderCreditsDto, long, PagedLoanApplicationResultRequestDto, OrderCreditsDto, OrderCreditsDto>
    {
    }
}
