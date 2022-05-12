using LoanManagement.Features.AdminLoanDetail;
using System.Collections.Generic;

namespace LoanManagement.Services.Implementation
{
    public interface IAdminLoanDetailService
    {
        string Add(AddAdminLoanDetail request);
        string Delete(int id);
        List<UpdateAdminLoanDetail> GetAll();
        UpdateAdminLoanDetail GetById(int id);
        string Update(UpdateAdminLoanDetail request);
    }
}