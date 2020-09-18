using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IAssetAndLiablityService : IAsyncCrudAppService<CreateOrUpdateAssetAndLiablityDto, long, PagedLoanApplicationResultRequestDto, CreateOrUpdateAssetAndLiablityDto, CreateOrUpdateAssetAndLiablityDto>
    {
    }
}
