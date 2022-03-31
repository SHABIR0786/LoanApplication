using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Loan.MortageLoanType
{
    public class UpdateMortageLoanTypeRequest: AddMortageLoanTypeRequest
    {
        public int Id { get; set; }
    }
}
