using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LeadTaxesType:Entity<int>
    {
        public string TaxesType { get; set; }
    }
}
