using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IAssetAndLiablityService : IAsyncCrudAppService<AssetAndLiabilityDto, long, PagedLoanApplicationResultRequestDto, AssetAndLiabilityDto, AssetAndLiabilityDto>
    {
    }
}
