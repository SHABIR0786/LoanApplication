using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Stockandbond : Entity<long>
    {
        public string CompanyName { get; set; }
        public string AccountNumber { get; set; }
        public decimal Value { get; set; }
        public long ManualAssetEntryId { get; set; }

        public virtual Manualassetentry ManualAssetEntry { get; set; }
    }
}
