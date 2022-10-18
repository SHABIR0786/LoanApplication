using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class MaritialStatus:Entity<int>
    {
        public MaritialStatus()
        {
            ApplicationPersonalInformations = new HashSet<ApplicationPersonalInformation>();
        }

        
        public string MaritialStatus1 { get; set; }

        public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformations { get; set; }
    }
}
