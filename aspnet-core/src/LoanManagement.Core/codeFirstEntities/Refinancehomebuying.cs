using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Refinancehomebuying : FullAuditedEntity<long?>
    {
        public string PropertyLocated { get; set; }
        public string PropertyType { get; set; }
        public string PropertyUse { get; set; }
        public string WantRefinance { get; set; }
        public decimal? HomePrice { get; set; }
        public decimal? Owe { get; set; }
        public decimal? CashBorrow { get; set; }
        public string Fhaloan { get; set; }
        public bool? MilitarySevice { get; set; }
        public bool? ProofOfincome { get; set; }
        public string CurrentlyEmployed { get; set; }
        public bool? BankruptcyPastThreeYears { get; set; }
        public bool? ForeclosurePastTwoYears { get; set; }
        public string LateMortgagePayments { get; set; }
        public string CurrentEmployed { get; set; }
        public string HouseHoldIncome { get; set; }
        public string RateCredit { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string RefferedBy { get; set; }
    }
}
