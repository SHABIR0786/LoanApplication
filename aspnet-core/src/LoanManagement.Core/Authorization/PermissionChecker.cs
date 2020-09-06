using Abp.Authorization;
using LoanManagement.Authorization.Roles;
using LoanManagement.Authorization.Users;

namespace LoanManagement.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
