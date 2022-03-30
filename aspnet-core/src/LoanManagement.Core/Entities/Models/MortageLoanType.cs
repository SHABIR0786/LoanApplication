using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class MortageLoanType
    {
        public MortageLoanType()
        {
            MortageLoanOnProperties = new HashSet<MortageLoanOnProperty>();
        }

        public int Id { get; set; }
        public string MortageLoanTypesId { get; set; } = null!;

        public virtual ICollection<MortageLoanOnProperty> MortageLoanOnProperties { get; set; }
    }
}
