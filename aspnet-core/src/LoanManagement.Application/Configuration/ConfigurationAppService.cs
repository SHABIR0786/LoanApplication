using Abp.Authorization;
using Abp.Runtime.Session;
using LoanManagement.Configuration.Dto;
using System.Threading.Tasks;

namespace LoanManagement.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LoanManagementAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
