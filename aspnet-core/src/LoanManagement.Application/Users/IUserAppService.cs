using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LoanManagement.Roles.Dto;
using LoanManagement.Users.Dto;
using System.Threading.Tasks;

namespace LoanManagement.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
