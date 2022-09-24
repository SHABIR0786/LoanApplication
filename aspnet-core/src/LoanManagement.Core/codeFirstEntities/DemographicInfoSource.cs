using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class DemographicInfoSource
    {
        public DemographicInfoSource()
        {
            DemographicInformations = new HashSet<DemographicInformation>();
        }

        public int Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<DemographicInformation> DemographicInformations { get; set; }
    }
}
