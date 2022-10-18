using LoanManagement.Features.AdminLoanStatus;
using System.Collections.Generic;

namespace LoanManagement.Services.Implementation
{
    public interface IAdminLoanStatusService
    {
        string Add(AddAdminLoanStatus request);
        string Delete(int id);
        List<UpdateAdminLoanStatus> GetAll();
        UpdateAdminLoanStatus GetById(int id);
        string Update(UpdateAdminLoanStatus request);
    }
}