using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class State: FullAuditedEntity<int>
    {
        public State()
        {
            Addresses = new HashSet<Address>();
            Manualassetentries = new HashSet<Manualassetentry>();
        }


        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Manualassetentry> Manualassetentries { get; set; }
    }
}
