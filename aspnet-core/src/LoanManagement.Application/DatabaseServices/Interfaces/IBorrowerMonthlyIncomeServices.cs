using Abp.Application.Services;
using LoanManagement.Models;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IBorrowerMonthlyIncomeServices : IAsyncCrudAppService<BorrowerMonthlyIncomeDto, long?, PagedLoanApplicationResultRequestDto, BorrowerMonthlyIncomeDto, BorrowerMonthlyIncomeDto>
    {
    }
}
