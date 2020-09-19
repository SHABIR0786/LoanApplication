using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IGrossMonthlyIncomeService : IAsyncCrudAppService<GrossMonthlyIncomeDto, long, PagedLoanApplicationResultRequestDto, GrossMonthlyIncomeDto, GrossMonthlyIncomeDto>
    {
    }
}
