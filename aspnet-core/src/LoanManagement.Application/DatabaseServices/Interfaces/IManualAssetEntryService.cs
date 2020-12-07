using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using LoanManagement.Models;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IManualAssetEntryService : IAsyncCrudAppService<ManualAssetEntryDto, long?, PagedLoanApplicationResultRequestDto, ManualAssetEntryDto, ManualAssetEntryDto>
    {
        Task<List<ManualAssetEntry>> GetAllAsync(long loanApplicationId);
    }
}
