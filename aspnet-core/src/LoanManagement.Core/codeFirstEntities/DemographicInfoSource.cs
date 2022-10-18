using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class DemographicInfoSource:Entity<int>
    {
        public DemographicInfoSource()
        {
            DemographicInformations = new HashSet<DemographicInformation>();
        }

        
        public string Value { get; set; }

        public virtual ICollection<DemographicInformation> DemographicInformations { get; set; }
    }
}
