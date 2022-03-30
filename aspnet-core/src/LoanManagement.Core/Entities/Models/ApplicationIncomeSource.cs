using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class ApplicationIncomeSource
    {
        public int Id { get; set; }
        public int? ApplicationPersonalInformationId { get; set; }
        public int IncomeSourceId1e1 { get; set; }
        public float? Amount1e2 { get; set; }

        public virtual ApplicationPersonalInformation? ApplicationPersonalInformation { get; set; }
        public virtual IncomeSource IncomeSourceId1e1Navigation { get; set; } = null!;
    }
}
