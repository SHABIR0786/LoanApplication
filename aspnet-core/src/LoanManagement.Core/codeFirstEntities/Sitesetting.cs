using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Sitesetting:Entity<int>
    {
        public string PageIdentifier { get; set; }
        public string PageName { get; set; }
        public string PageSetting { get; set; }
    }
}
