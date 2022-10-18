using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LoanAndPropertyInformationOtherMortageLoan:Entity<int>
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public string CreditorName4b1 { get; set; }
        public string LienType4b2 { get; set; }
        public float? MonthlyPayment4b3 { get; set; }
        public float? LoanAmount4b4 { get; set; }
        public float? CreditAmount4b5 { get; set; }
    }
}
