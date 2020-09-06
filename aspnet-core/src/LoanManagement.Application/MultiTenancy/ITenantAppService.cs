using Abp.Application.Services;
using LoanManagement.MultiTenancy.Dto;

namespace LoanManagement.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

