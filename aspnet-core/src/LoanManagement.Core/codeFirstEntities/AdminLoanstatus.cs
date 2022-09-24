using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class AdminLoanstatus
    {
        public AdminLoanstatus()
        {
            AdminLoansummarystatuses = new HashSet<AdminLoansummarystatus>();
        }

        public int Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<AdminLoansummarystatus> AdminLoansummarystatuses { get; set; }
    }
}
