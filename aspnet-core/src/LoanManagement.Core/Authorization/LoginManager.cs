using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Zero.Configuration;
using LoanManagement.Authorization.Roles;
using LoanManagement.Authorization.Users;
using LoanManagement.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace LoanManagement.Authorization
{
    public class LogInManager : AbpLogInManager<Tenant, Role, User>
    {
        public LogInManager(
            UserManager userManager,
            IMultiTenancyConfig multiTenancyConfig,
            IRepository<Tenant> tenantRepository,
            IUnitOfWorkManager unitOfWorkManager,
            ISettingManager settingManager,
            IRepository<UserLoginAttempt, long> userLoginAttemptRepository,
            IUserManagementConfig userManagementConfig,
            IIocResolver iocResolver,
            IPasswordHasher<User> passwordHasher,
            RoleManager roleManager,
            UserClaimsPrincipalFactory claimsPrincipalFactory)
            : base(
                  userManager,
                  multiTenancyConfig,
                  tenantRepository,
                  unitOfWorkManager,
                  settingManager,
                  userLoginAttemptRepository,
                  userManagementConfig,
                  iocResolver,
                  passwordHasher,
                  roleManager,
                  claimsPrincipalFactory)
        {
        }
        public override Task<AbpLoginResult<Tenant, User>> LoginAsync(UserLoginInfo login, string tenancyName = null)
        {
            return base.LoginAsync(login, tenancyName);
        }
        public override Task<AbpLoginResult<Tenant, User>> LoginAsync(string userNameOrEmailAddress, string plainPassword, string tenancyName = null, bool shouldLockout = true)
        {
            return base.LoginAsync(userNameOrEmailAddress, plainPassword, tenancyName, shouldLockout);
        }
    }
}
