using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LoanAndPropertyInformationGift: FullAuditedEntity<int>
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public int? LoanPropertyGiftTypeId4d1 { get; set; }
        public ulong? Deposited4d2 { get; set; }
        public string Source4d3 { get; set; }
        public float? Value4d4 { get; set; }
    }
}
