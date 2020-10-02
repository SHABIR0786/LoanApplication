using Abp.Application.Services;
using LoanManagement.ViewModels;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface ILoanDetailServices : IAsyncCrudAppService<LoanDetailDto, long, PagedLoanApplicationResultRequestDto, LoanDetailDto, LoanDetailDto>
    {

        Task<LoanDetailDto> CreateAsync(LoanDetailDto input);
    }
}
