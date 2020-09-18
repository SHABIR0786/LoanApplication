using Abp.Application.Services;
using LoanManagement.LoanApplications.Dto;
using LoanManagement.Roles.Dto;

namespace LoanManagement.LoanApplications
{
    public interface ILoanAppService : IAsyncCrudAppService<LoanApplicationDto, long, PagedLoanApplicationResultRequestDto, LoanApplicationDto, LoanApplicationDto>
    {
    }
}
