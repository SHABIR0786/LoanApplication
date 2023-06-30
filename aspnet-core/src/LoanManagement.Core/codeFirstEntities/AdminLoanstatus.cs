using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class AdminLoanstatus : FullAuditedEntity<int>
    {
        public AdminLoanstatus()
        {
            AdminLoansummarystatuses = new HashSet<AdminLoansummarystatus>();
        }

        public string Status { get; set; }

        public virtual ICollection<AdminLoansummarystatus> AdminLoansummarystatuses { get; set; }
    }
}
