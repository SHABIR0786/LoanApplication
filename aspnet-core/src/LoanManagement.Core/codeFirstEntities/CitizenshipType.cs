using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class CitizenshipType
    {
        public CitizenshipType()
        {
            ApplicationPersonalInformations = new HashSet<ApplicationPersonalInformation>();
        }

        public int Id { get; set; }
        public string CitizenshipType1 { get; set; }

        public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformations { get; set; }
    }
}
