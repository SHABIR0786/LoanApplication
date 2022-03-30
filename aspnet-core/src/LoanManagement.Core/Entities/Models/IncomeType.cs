using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class IncomeType
    {
        public IncomeType()
        {
            ApplicationAdditionalEmployementIncomeDetails = new HashSet<ApplicationAdditionalEmployementIncomeDetail>();
            ApplicationEmployementIncomeDetails = new HashSet<ApplicationEmployementIncomeDetail>();
        }

        public int Id { get; set; }
        public string IncomeType1 { get; set; } = null!;

        public virtual ICollection<ApplicationAdditionalEmployementIncomeDetail> ApplicationAdditionalEmployementIncomeDetails { get; set; }
        public virtual ICollection<ApplicationEmployementIncomeDetail> ApplicationEmployementIncomeDetails { get; set; }
    }
}
