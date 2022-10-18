using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class MortageLoanOnProperty:Entity<int>
    {
        public int? ApplicationFinancialRealEstateId { get; set; }
        public string CreditorName3a9 { get; set; }
        public string AccountNumber3a10 { get; set; }
        public float? MonthlyMortagePayment3a11 { get; set; }
        public float? UnpaidBalance3a12 { get; set; }
        public ulong? PaidOff3a13 { get; set; }
        public int MortageLoanTypesId3a14 { get; set; }
        public float? CreditLimit3a15 { get; set; }
    }
}
