using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Assettype: FullAuditedEntity<long>
    {
        public Assettype()
        {
            Manualassetentries = new HashSet<Manualassetentry>();
        }

        public string Name { get; set; }

        public virtual ICollection<Manualassetentry> Manualassetentries { get; set; }
    }
}
