using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class CreditType
    {
        public CreditType()
        {
            Applications = new HashSet<Application>();
        }

        public int Id { get; set; }
        public string CreditType1 { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}
