using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Sitesetting: FullAuditedEntity<int>
    {
        public string PageIdentifier { get; set; }
        public string PageName { get; set; }
        public string PageSetting { get; set; }
    }
}
