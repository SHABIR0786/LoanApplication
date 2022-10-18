using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class AdminDisclosure : Entity<int>
    {
        public AdminDisclosure()
        {
            AdminLoanapplicationdocuments = new HashSet<AdminLoanapplicationdocument>();
        }

        public string Title { get; set; }

        public virtual ICollection<AdminLoanapplicationdocument> AdminLoanapplicationdocuments { get; set; }
    }
}
