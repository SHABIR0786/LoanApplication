using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class State
    {
        public State()
        {
            Addresses = new HashSet<Address>();
            Manualassetentries = new HashSet<Manualassetentry>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Manualassetentry> Manualassetentries { get; set; }
    }
}
