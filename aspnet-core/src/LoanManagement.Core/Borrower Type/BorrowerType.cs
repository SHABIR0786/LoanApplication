using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.BorrowerTypes
{
    public class BorrowerType : FullAuditedEntity<long>, IMayHaveTenant
    {
        public string Type { get; set; }
        public int? TenantId { get; set; }
    }
}
