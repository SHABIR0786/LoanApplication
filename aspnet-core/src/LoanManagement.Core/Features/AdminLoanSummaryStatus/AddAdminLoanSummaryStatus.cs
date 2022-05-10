using System;
using System.Collections.Generic;

namespace  LoanManagement.Features.AdminLoanSummaryStatus
{
    public partial class AddAdminLoanSummaryStatus
    {
        public int LoanId { get; set; }
        public int StatusId { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
