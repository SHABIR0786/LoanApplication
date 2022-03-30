using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class CreditType
    {
        public CreditType()
        {
            Applications = new HashSet<Application>();
        }

        public int Id { get; set; }
        public string CreditType1 { get; set; } = null!;

        public virtual ICollection<Application> Applications { get; set; }
    }
}
