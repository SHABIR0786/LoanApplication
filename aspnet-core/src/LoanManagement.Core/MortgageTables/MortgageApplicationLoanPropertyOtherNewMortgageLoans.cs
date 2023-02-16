using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationLoanPropertyOtherNewMortgageLoans:FullAuditedEntity<int>
    {
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        public string CreditorName { get; set; }
        public string LienType { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal CreditLimit { get; set; }
    }
}
