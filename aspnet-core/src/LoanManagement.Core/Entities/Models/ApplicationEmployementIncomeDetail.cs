using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class ApplicationEmployementIncomeDetail
    {
        public int Id { get; set; }
        public int ApplicationEmployementDetailsId { get; set; }
        public int IncomeTypeId1b101 { get; set; }
        public float? Amount1b10 { get; set; }

        public virtual ApplicationEmployementDetail ApplicationEmployementDetails { get; set; } = null!;
        public virtual IncomeType IncomeTypeId1b101Navigation { get; set; } = null!;
    }
}
