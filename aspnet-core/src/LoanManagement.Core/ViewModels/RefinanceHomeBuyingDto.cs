using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.ViewModels
{
   public class RefinanceHomeBuyingDto : EntityDto<long?>
    {
        public string propertyLocated { get; set; }
        public string propertyType { get; set; }
        public string PropertyUse { get; set; }
        public string WantRefinance { get; set; }
        public decimal HomePrice { get; set; }
        public decimal Owe { get; set; }
        public decimal CashBorrow { get; set; }
        public string FHALoan { get; set; }
        public bool militarySevice { get; set; }
        public bool foreclosurePastTwoYears { get; set; }
        public bool bankruptcyPastThreeYears { get; set; }
        public string LateMortgagePayments { get; set; }
        public string currentEmployed { get; set; }
        public string houseHoldIncome { get; set; }
        public bool proofOfincome { get; set; }
        public string rateCredit { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }
        public string refferedBy { get; set; }
    }
}
