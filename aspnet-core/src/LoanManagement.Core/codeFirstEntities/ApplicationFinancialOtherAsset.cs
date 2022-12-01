using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class ApplicationFinancialOtherAsset:  FullAuditedEntity<int>
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public int FinancialAssetsTypesId2b1 { get; set; }
        public float? Value2b2 { get; set; }

        public virtual ApplicationPersonalInformation ApplicationPersonalInformation { get; set; }
        public virtual FinancialAssetsType FinancialAssetsTypesId2b1Navigation { get; set; }
    }
}
