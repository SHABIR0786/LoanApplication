using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class LoanAndPropertyInformationRentalIncome
    {
        public int Id { get; set; }
        public int? ApplicationPersonalInformationId { get; set; }
        public float? ExpectedMonthlyIncome4c1 { get; set; }
        public float? LenderExpectedMonthlyIncome4c2 { get; set; }

        public virtual ApplicationPersonalInformation? ApplicationPersonalInformation { get; set; }
    }
}
