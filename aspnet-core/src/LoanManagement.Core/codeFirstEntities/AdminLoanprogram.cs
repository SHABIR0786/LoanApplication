using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class AdminLoanprogram:Entity<int>
    {
        public AdminLoanprogram()
        {
            AdminLoandetails = new HashSet<AdminLoandetail>();
        }

        
        public string LoanProgram { get; set; }

        public virtual ICollection<AdminLoandetail> AdminLoandetails { get; set; }
    }
}
