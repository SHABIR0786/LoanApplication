using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class IncomeSource
    {
        public IncomeSource()
        {
            ApplicationIncomeSources = new HashSet<ApplicationIncomeSource>();
        }

        public int Id { get; set; }
        public string IncomeSource1 { get; set; }

        public virtual ICollection<ApplicationIncomeSource> ApplicationIncomeSources { get; set; }
    }
}
