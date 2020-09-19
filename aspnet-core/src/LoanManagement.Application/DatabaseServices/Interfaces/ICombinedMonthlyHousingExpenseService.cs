using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface ICombinedMonthlyHousingExpenseService : IAsyncCrudAppService<CombinedMonthlyHousingExpenseDto, long, PagedLoanApplicationResultRequestDto, CombinedMonthlyHousingExpenseDto, CombinedMonthlyHousingExpenseDto>
    {
    }
}
