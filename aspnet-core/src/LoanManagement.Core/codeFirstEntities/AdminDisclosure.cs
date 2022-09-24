using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class AdminDisclosure
    {
        public AdminDisclosure()
        {
            AdminLoanapplicationdocuments = new HashSet<AdminLoanapplicationdocument>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<AdminLoanapplicationdocument> AdminLoanapplicationdocuments { get; set; }
    }
}
