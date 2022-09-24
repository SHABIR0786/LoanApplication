using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class ApplicationFinancialAsset
    {
        public int Id { get; set; }
        public int? ApplicationPersonalInformationId { get; set; }
        public int FinancialAccountTypeId2a1 { get; set; }
        public string FinancialInstitution2a2 { get; set; }
        public string AccountNumber2a3 { get; set; }
        public float? Value2a4 { get; set; }

        public virtual ApplicationPersonalInformation ApplicationPersonalInformation { get; set; }
        public virtual FinancialAccountType FinancialAccountTypeId2a1Navigation { get; set; }
    }
}
