using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class AdminLoanstatus:Entity<int>
    {
        public AdminLoanstatus()
        {
            AdminLoansummarystatuses = new HashSet<AdminLoansummarystatus>();
        }

        public string Status { get; set; }

        public virtual ICollection<AdminLoansummarystatus> AdminLoansummarystatuses { get; set; }
    }
}
