using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class DemographicInfoSource: FullAuditedEntity<int>
    {
        public DemographicInfoSource()
        {
            DemographicInformations = new HashSet<DemographicInformation>();
        }

        
        public string Value { get; set; }

        public virtual ICollection<DemographicInformation> DemographicInformations { get; set; }
    }
}
