using LoanManagement.Features.AdminNotificationType;
using System.Collections.Generic;

namespace LoanManagement.Services.Implementation
{
    public interface IAdminNotificationTypeService
    {
        string Add(AddAdminNotificationType request);
        string Delete(int id);
        List<UpdateAdminNotificationType> GetAll();
        UpdateAdminNotificationType GetById(int id);
        string Update(UpdateAdminNotificationType request);
    }
}