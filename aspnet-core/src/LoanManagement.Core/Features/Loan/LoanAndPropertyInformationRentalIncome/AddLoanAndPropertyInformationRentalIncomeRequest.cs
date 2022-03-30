using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Loan.LoanAndPropertyInformationRentalIncome
{
    public class AddLoanAndPropertyInformationRentalIncomeRequest
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public float? ExpectedMonthlyIncome4c1 { get; set; }
        public float? LenderExpectedMonthlyIncome4c2 { get; set; }

    }
}
