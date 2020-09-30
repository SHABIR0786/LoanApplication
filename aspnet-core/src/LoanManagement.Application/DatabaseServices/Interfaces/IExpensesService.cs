using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IExpensesService : IAsyncCrudAppService<ExpensesDto, long, PagedLoanApplicationResultRequestDto, ExpensesDto, ExpensesDto>
    {
    }
}
