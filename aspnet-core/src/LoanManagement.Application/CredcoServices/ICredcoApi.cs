using Abp.Dependency;
using LoanManagement.ViewModels;
using System.Threading.Tasks;

namespace LoanManagement.CredcoServices
{
    public interface ICredcoApi : ISingletonDependency
    {
        Task<CoreLogicModels.JointResponse.ResponseGroup> GetCreditDataAsync(PersonalInformationDto input);
    }
}
