using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IAdditionalIncomeService : IAsyncCrudAppService<AdditionalIncomeDto, long?, PagedLoanApplicationResultRequestDto, AdditionalIncomeDto, AdditionalIncomeDto>
    {
        
    }
}
