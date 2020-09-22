using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IMortageService : IAsyncCrudAppService<MortgageTypeDto, long, PagedLoanApplicationResultRequestDto, MortgageTypeDto, MortgageTypeDto>
    {
    }
}
