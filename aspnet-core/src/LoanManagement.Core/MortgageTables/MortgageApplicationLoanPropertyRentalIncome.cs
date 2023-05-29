using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationLoanPropertyRentalIncome:FullAuditedEntity<int>
    {
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        public decimal MonthlyRentalIncome{ get; set; }
        public decimal NetMonthlyRentalIncome{ get; set; }
    }
}
