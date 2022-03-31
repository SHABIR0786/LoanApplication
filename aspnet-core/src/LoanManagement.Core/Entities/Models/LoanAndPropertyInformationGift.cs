using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class LoanAndPropertyInformationGift
    {
        public int Id { get; set; }
        public int? ApplicationPersonalInformationId { get; set; }
        public int? LoanPropertyGiftTypeId4d1 { get; set; }
        public ulong? Deposited4d2 { get; set; }
        public string Source4d3 { get; set; }
        public float? Value4d4 { get; set; }

        public virtual ApplicationPersonalInformation? ApplicationPersonalInformation { get; set; }
        public virtual LoanPropertyGiftType? LoanPropertyGiftTypeId4d1Navigation { get; set; }
    }
}
