using LoanManagement.Features.AdminLoanSummaryStatus;
using System.Collections.Generic;

namespace LoanManagement.Services.Implementation
{
    public interface IAdminLoanSummaryStatusService
    {
        string Add(AddAdminLoanSummaryStatus request);
        string Delete(int id);
        List<UpdateAdminLoanSummaryStatus> GetAll();
        UpdateAdminLoanSummaryStatus GetById(int id);
        string Update(UpdateAdminLoanSummaryStatus request);
       
    }
}