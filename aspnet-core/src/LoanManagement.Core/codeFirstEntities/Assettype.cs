using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Assettype
    {
        public Assettype()
        {
            Manualassetentries = new HashSet<Manualassetentry>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Manualassetentry> Manualassetentries { get; set; }
    }
}
