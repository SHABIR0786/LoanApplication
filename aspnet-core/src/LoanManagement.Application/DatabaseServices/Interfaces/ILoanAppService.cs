using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LoanManagement.ViewModels;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface ILoanAppService : IAsyncCrudAppService<LoanApplicationDto, long?, PagedLoanApplicationResultRequestDto, LoanApplicationDto, LoanApplicationDto>
    {
        Task<PagedResultDto<LoanListDto>> GetAllCustomAsync(PagedLoanApplicationResultRequestDto input);
    }
}
