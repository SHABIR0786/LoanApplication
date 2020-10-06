using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IExpenseService : IAsyncCrudAppService<ExpensesDto, long?, PagedLoanApplicationResultRequestDto, ExpensesDto, ExpensesDto>
    {
    }
}
