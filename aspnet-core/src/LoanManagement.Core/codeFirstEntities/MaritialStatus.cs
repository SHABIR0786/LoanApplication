using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class MaritialStatus: FullAuditedEntity<int>
    {
        public MaritialStatus()
        {
            ApplicationPersonalInformations = new HashSet<ApplicationPersonalInformation>();
        }

        
        public string MaritialStatus1 { get; set; }

        public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformations { get; set; }
    }
}
