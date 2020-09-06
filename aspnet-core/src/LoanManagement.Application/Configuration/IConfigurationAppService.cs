using System.Threading.Tasks;
using LoanManagement.Configuration.Dto;

namespace LoanManagement.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
