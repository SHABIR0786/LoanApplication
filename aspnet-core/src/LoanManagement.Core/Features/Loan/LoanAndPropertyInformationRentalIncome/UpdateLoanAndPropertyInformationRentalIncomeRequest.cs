using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Loan.LoanAndPropertyInformationRentalIncome
{
    public class UpdateLoanAndPropertyInformationRentalIncomeRequest: AddLoanAndPropertyInformationRentalIncomeRequest
    {
        public int Id { get; set; }
    }
}
