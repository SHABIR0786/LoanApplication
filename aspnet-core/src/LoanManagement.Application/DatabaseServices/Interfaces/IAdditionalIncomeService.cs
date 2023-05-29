using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using LoanManagement.codeFirstEntities;
using LoanManagement.Models;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IAdditionalIncomeService : IAsyncCrudAppService<AdditionalIncomeDto, long?, PagedLoanApplicationResultRequestDto, AdditionalIncomeDto, AdditionalIncomeDto>
    {
        Task<List<Additionalincome>> GetAllByLoanApplicationIdAsync(long loanApplicationId);
    }
}
