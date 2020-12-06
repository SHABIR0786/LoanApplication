using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface ISiteSettingServices : IAsyncCrudAppService<SiteSettingDto, int, PagedLoanApplicationResultRequestDto, SiteSettingDto, SiteSettingDto>
    {
    }
}
