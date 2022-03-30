using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.CreditType
{
    public class UpdateCreditTypeRequest: AddCreditTypeRequest
    {
        public int Id { get; set; }
    }
}
