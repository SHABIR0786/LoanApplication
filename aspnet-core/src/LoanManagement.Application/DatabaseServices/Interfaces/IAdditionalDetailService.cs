using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IAdditionalDetailService : IAsyncCrudAppService<AdditionalDetailsDto, long, PagedLoanApplicationResultRequestDto, AdditionalDetailsDto, AdditionalDetailsDto>
    {
    }
}
