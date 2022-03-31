using LoanManagement.Features.MaritalStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
    public interface IMaritalStatusService
    {
        string AddMaritalStatus(AddMaritalStatusRequest request);
        string UpdateMaritalStatus(UpdateMaritalStatusRequest request);
        string DeleteMaritalStatus(int id);
        List<UpdateMaritalStatusRequest> GetMaritalStatuses();
        UpdateMaritalStatusRequest GetMaritalStatusById(int id);
    }
}
