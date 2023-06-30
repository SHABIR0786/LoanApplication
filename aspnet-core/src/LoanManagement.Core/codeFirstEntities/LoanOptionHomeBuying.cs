using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.codeFirstEntities
{
    public class LoanOptionHomeBuying : FullAuditedEntity<long?>
    {
        public string PropertyUse { get; set; }
        public string propertyType { get; set; }
        public string zipCode { get; set; }
        public string howLongPlan { get; set; }
        public decimal estimatePrice { get; set; }
        public decimal downPayment { get; set; }
        public decimal downPaymentPercent { get; set; }
        public bool FirstTimeHomeBuying { get; set; }
        public bool militarySevice { get; set; }
        public string important_to_you { get; set; }
        public string rateCredit { get; set; }
        public bool workingWithLoanOfficer { get; set; }
        public string plan_page11 { get; set; }
        public string plan_page12 { get; set; }
        public string page_13 { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }
    }
}
