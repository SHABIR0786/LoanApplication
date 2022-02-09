using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.ViewModels
{
   public class BuyingHomeDto : EntityDto<long?>
    {
        public string propertyType { get; set; }
        public string propertyUse { get; set; }
        public bool FirstTimeHomeBuying { get; set; }
        public string planToPurchase { get; set; }
        public string propertyLocated { get; set; }
        public string purchasePrice { get; set; }
        public decimal downPayment { get; set; }
        public string currentEmployed { get; set; }
        public string houseHoldIncome { get; set; }
        public bool proofOfincome { get; set; }
        public bool militarySevice { get; set; }
        public bool bankruptcyPastThreeYears { get; set; }
        public bool foreclosurePastTwoYears { get; set; }
        public string LateMortgagePayments { get; set; }
        public string rateCredit { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }
        public string refferedBy { get; set; }
    }
}
