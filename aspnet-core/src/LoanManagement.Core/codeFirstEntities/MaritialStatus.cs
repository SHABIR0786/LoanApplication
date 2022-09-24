using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class MaritialStatus
    {
        public MaritialStatus()
        {
            ApplicationPersonalInformations = new HashSet<ApplicationPersonalInformation>();
        }

        public int Id { get; set; }
        public string MaritialStatus1 { get; set; }

        public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformations { get; set; }
    }
}
