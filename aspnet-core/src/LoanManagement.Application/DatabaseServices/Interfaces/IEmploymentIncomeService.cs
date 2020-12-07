using System.Threading.Tasks;
using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IEmploymentIncomeService : IAsyncCrudAppService<EmploymentIncomeDto, long?, PagedLoanApplicationResultRequestDto, EmploymentIncomeDto, EmploymentIncomeDto>
    {
    }
}
