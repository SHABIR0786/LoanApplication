using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class ApplicationFinancialOtherAsset
    {
        public int Id { get; set; }
        public int? ApplicationPersonalInformationId { get; set; }
        public int FinancialAssetsTypesId2b1 { get; set; }
        public float? Value2b2 { get; set; }

        public virtual ApplicationPersonalInformation ApplicationPersonalInformation { get; set; }
        public virtual FinancialAssetsType FinancialAssetsTypesId2b1Navigation { get; set; }
    }
}
