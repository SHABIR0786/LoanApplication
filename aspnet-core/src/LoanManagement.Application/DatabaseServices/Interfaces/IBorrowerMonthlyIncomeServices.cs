using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using LoanManagement.codeFirstEntities;
using LoanManagement.Models;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IBorrowerMonthlyIncomeServices : IAsyncCrudAppService<BorrowerMonthlyIncomeDto, long?, PagedLoanApplicationResultRequestDto, BorrowerMonthlyIncomeDto, BorrowerMonthlyIncomeDto>
    {
        Task<List<Borrowermonthlyincome>> GetAllByLoanApplicationIdAsync(long loanApplicationId);
    }
}
