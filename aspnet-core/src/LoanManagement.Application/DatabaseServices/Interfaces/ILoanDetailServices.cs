using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface ILoanDetailServices : IAsyncCrudAppService<LoanDetailDto, long?, PagedLoanApplicationResultRequestDto, LoanDetailDto, LoanDetailDto>
    {
        Task<LoanDetail> GetCustomAsync(EntityDto<long?> input);
    }
}
