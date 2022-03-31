using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class LoanPropertyOccupancy
    {
        public LoanPropertyOccupancy()
        {
            LoanAndPropertyInformations = new HashSet<LoanAndPropertyInformation>();
        }

        public int Id { get; set; }
        public string LoanPropertyOccupancy1 { get; set; } = null!;

        public virtual ICollection<LoanAndPropertyInformation> LoanAndPropertyInformations { get; set; }
    }
}
