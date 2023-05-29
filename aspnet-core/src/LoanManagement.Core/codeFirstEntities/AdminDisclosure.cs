using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class AdminDisclosure : FullAuditedEntity<int>
    {
        public AdminDisclosure()
        {
            AdminLoanapplicationdocuments = new HashSet<AdminLoanapplicationdocument>();
        }

        public string Title { get; set; }

        public virtual ICollection<AdminLoanapplicationdocument> AdminLoanapplicationdocuments { get; set; }
    }
}
