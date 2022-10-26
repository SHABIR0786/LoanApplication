using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class AdminLoanapplicationdocument : FullAuditedEntity<int>
    {
        public int LoanId { get; set; }
        public int DisclosureId { get; set; }
        //public int UserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string DocumentPath { get; set; }

        public virtual AdminDisclosure Disclosure { get; set; }
        public virtual AdminLoandetail Loan { get; set; }
        //public virtual AdminUser User { get; set; }
    }
}
