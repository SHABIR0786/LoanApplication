using LoanManagement.Features.AdminUserEnabledDevice;
using System.Collections.Generic;

namespace LoanManagement.Services.Implementation
{
    public interface IAdminUserEnabledDeviceService
    {
        string Add(AddAdminUserEnabledDevice request);
        string Delete(int id);
        List<UpdateAdminUserEnabledDevice> GetAll();
        UpdateAdminUserEnabledDevice GetById(int id);
        string Update(UpdateAdminUserEnabledDevice request);
    }
}