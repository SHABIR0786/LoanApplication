using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace LoanManagement.Models
{
    public class RefinanceLoanOption : Entity<long?>
    {
        public string important_to_you { get; set; }
        public string PropertyUse { get; set; }
        public string propertyType { get; set; }
        public string zipCode { get; set; }
        public decimal estimatePrice { get; set; }
        public decimal remainingBalalnce { get; set; }
        public bool haveAnyOtherLoanForThisProperty { get; set; }
        public bool loanHomeEquity { get; set; }
        public bool payThatOff { get; set; }
        public decimal balanceOfHomeEquity { get; set; }
        public bool homeEquityPurchase { get; set; }
        public decimal borrowAdditionalCash { get; set; }
        public string howLongPlan { get; set; }
        public bool militarySevice { get; set; }
        public string rateCredit { get; set; }
        public bool workingWithLoanOfficer { get; set; }
        public string officerName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }

    }
}

