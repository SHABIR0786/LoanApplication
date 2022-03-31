using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Loan.MortageLoanOnProperty
{
    public class UpdateMortageLoanOnPropertyRequest: AddMortageLoanOnPropertyRequest
    {
        public int Id { get; set; }
    }
}
