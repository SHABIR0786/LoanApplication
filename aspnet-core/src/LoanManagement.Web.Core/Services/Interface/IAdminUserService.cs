using LoanManagement.Features.AdminUser;
using System.Collections.Generic;

namespace LoanManagement.Services.Implementation
{
    public interface IAdminUserService
    {
        string Add(AddAdminUser request);
        string Delete(int id);
        List<UpdateAdminUser> GetAll();
        UpdateAdminUser GetById(int id);
        string Update(UpdateAdminUser request);
    }
}