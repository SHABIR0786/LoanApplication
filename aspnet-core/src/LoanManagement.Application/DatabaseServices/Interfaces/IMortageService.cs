using Abp.Application.Services;
using LoanManagement.LoanApplications.Dto;
using LoanManagement.Roles.Dto;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IMortageService : IAsyncCrudAppService<MortgageTypeDto, int, PagedLoanApplicationResultRequestDto, MortgageTypeDto, MortgageTypeDto>
    {
    }
}
