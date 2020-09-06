using System.Threading.Tasks;
using Abp.Application.Services;
using LoanManagement.Authorization.Accounts.Dto;

namespace LoanManagement.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
