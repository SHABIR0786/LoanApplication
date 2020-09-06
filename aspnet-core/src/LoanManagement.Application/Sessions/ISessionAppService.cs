using System.Threading.Tasks;
using Abp.Application.Services;
using LoanManagement.Sessions.Dto;

namespace LoanManagement.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
