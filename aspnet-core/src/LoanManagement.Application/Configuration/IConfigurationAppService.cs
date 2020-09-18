using LoanManagement.Configuration.Dto;
using System.Threading.Tasks;

namespace LoanManagement.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
