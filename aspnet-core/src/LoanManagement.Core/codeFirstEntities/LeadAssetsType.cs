using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LeadAssetsType:Entity<int>
    {
       
        public string AssetsType { get; set; }
    }
}
