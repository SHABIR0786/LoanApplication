using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LoanAndPropertyInformationRentalIncome: FullAuditedEntity<int>
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public float? ExpectedMonthlyIncome4c1 { get; set; }
        public float? LenderExpectedMonthlyIncome4c2 { get; set; }
    }
}
