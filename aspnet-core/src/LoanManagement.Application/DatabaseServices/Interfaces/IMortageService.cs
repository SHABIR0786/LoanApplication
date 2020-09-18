using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IMortageService : IAsyncCrudAppService<MortgageTypeDto, int, PagedLoanApplicationResultRequestDto, MortgageTypeDto, MortgageTypeDto>
    {
    }
}
