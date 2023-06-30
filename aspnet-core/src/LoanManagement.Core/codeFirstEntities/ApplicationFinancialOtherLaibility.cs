using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class ApplicationFinancialOtherLaibility: FullAuditedEntity<int>
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public int FinancialOtherLaibilitiesTypeId2d1 { get; set; }
        public float? MonthlyPayment2d2 { get; set; }

        public virtual ApplicationPersonalInformation ApplicationPersonalInformation { get; set; }
        public virtual FinancialOtherLaibilitiesType FinancialOtherLaibilitiesTypeId2d1Navigation { get; set; }
    }
}
