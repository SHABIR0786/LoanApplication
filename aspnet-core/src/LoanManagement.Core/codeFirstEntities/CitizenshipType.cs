using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class CitizenshipType: FullAuditedEntity<int>
    {
        public CitizenshipType()
        {
            ApplicationPersonalInformations = new HashSet<ApplicationPersonalInformation>();
        }

        
        public string CitizenshipType1 { get; set; }

        public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformations { get; set; }
    }
}
