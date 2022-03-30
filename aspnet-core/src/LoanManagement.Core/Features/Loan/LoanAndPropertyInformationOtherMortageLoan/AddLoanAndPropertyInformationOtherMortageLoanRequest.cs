using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Loan.LoanAndPropertyInformationOtherMortageLoan
{
    public class AddLoanAndPropertyInformationOtherMortageLoanRequest
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public string CreditorName4b1 { get; set; }
        public string LienType4b2 { get; set; }
        public float? MonthlyPayment4b3 { get; set; }
        public float? LoanAmount4b4 { get; set; }
        public float? CreditAmount4b5 { get; set; }
    }
}
