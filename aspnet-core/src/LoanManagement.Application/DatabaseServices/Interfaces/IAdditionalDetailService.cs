using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IAdditionalDetailServices : IAsyncCrudAppService<AdditionalDetailsDto, long?, PagedLoanApplicationResultRequestDto, AdditionalDetailsDto, AdditionalDetailsDto>
    {
    }
}
