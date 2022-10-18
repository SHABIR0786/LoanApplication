using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LeadTaxesType: FullAuditedEntity<int>
    {
        public string TaxesType { get; set; }
    }
}
