using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class ApplicationFinancialLaibility: FullAuditedEntity<int>
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public int FinancialLaibilitiesType2c1 { get; set; }
        public string CompanyName2c2 { get; set; }
        public string AccountNumber2c3 { get; set; }
        public float? UnpaidBalance2c4 { get; set; }
        public ulong? PaidOff2c5 { get; set; }
        public float? MonthlyValue2c6 { get; set; }

        public virtual ApplicationPersonalInformation ApplicationPersonalInformation { get; set; }
        public virtual FinancialLaibilitiesType FinancialLaibilitiesType2c1Navigation { get; set; }
    }
}
