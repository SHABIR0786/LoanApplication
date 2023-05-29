using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Incomesource1
    {
        public Incomesource1()
        {
            Additionalincomes = new HashSet<Additionalincome>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Additionalincome> Additionalincomes { get; set; }
    }
}
