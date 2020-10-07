using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IManualAssetEntryService : IAsyncCrudAppService<ManualAssetEntryDto, long?, PagedLoanApplicationResultRequestDto, ManualAssetEntryDto, ManualAssetEntryDto>
    {   
    }
}
