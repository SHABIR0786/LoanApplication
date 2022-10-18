using LoanManagement.Features.AdminUserNotification;
using System.Collections.Generic;

namespace LoanManagement.Services.Implementation
{
    public interface IAdminUserNotificationService
    {
        string Add(AddAdminUserNotification request);
        string Delete(int id);
        List<UpdateAdminUserNotification> GetAll();
        UpdateAdminUserNotification GetById(int id);
        string Update(UpdateAdminUserNotification request);
    }
}