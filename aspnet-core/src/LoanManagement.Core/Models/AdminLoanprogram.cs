using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class AdminLoanprogram
    {
        public AdminLoanprogram()
        {
            AdminLoandetails = new HashSet<AdminLoandetail>();
        }

        public int Id { get; set; }
        public string LoanProgram { get; set; }

        public virtual ICollection<AdminLoandetail> AdminLoandetails { get; set; }
    }
}
