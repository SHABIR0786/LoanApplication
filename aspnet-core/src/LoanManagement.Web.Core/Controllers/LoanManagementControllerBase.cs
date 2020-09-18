using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace LoanManagement.Controllers
{
    public abstract class LoanManagementControllerBase : AbpController
    {
        protected LoanManagementControllerBase()
        {
            LocalizationSourceName = LoanManagementConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
