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
        public string creditorName { get; set; }
        public string lienType { get; set; }
        public decimal monthlyPayment { get; set; }
        public decimal loanAmount { get; set; }
        public decimal creditLimit { get; set; }
    }
}
