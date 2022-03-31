using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class MaritialStatus
    {
        public MaritialStatus()
        {
            ApplicationPersonalInformations = new HashSet<ApplicationPersonalInformation>();
        }

        public int Id { get; set; }
        public string MaritialStatus1 { get; set; } = null!;

        public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformations { get; set; }
    }
}
