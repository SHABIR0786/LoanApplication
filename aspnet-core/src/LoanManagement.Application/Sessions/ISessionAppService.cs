using Abp.Application.Services;
using LoanManagement.Sessions.Dto;
using System.Threading.Tasks;

namespace LoanManagement.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
