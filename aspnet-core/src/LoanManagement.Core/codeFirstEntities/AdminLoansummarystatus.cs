using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class AdminLoansummarystatus
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public int StatusId { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual AdminLoandetail Loan { get; set; }
        public virtual AdminLoanstatus Status { get; set; }
    }
}
