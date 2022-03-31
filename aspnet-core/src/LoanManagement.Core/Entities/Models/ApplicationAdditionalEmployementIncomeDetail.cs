using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class ApplicationAdditionalEmployementIncomeDetail
    {
        public int Id { get; set; }
        public int ApplicationAdditionalEmployementDetails { get; set; }
        public int IncomeTypeId { get; set; }
        public float? Amount { get; set; }

        public virtual ApplicationAdditionalEmployementDetail ApplicationAdditionalEmployementDetailsNavigation { get; set; } = null!;
        public virtual IncomeType IncomeType { get; set; } = null!;
    }
}
