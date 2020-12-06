using Abp.Dependency;
using LoanManagement.CoreLogicModels.JointResponse;
using LoanManagement.ViewModels;
using System.Threading.Tasks;

namespace LoanManagement.CredcoServices
{
    public interface ICredcoApi : ISingletonDependency
    {
        Task<ResponseGroup> GetCreditDataAsync(LoanApplicationDto input);
    }
}
