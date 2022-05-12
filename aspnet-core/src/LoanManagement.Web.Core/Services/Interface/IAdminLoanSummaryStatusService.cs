using LoanManagement.Features.AdminLoanSummaryStatus;
using System.Collections.Generic;

namespace LoanManagement.Services.Implementation
{
    public interface IAdminLoanSummaryStatusService
    {
        string Add(AddAdminLoanSummaryStatus request);
        string Delete(int id);
        List<UpdateAAdminLoanSummaryStatus> GetAll();
        UpdateAAdminLoanSummaryStatus GetById(int id);
        string Update(UpdateAAdminLoanSummaryStatus request);
       
    }
}