using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.EmployementIncomeDetail
{
    public class AddEmployementIncomeDetailRequest
    {
        public int ApplicationEmployementDetailsId { get; set; }
        public int IncomeTypeId1b101 { get; set; }
        public float? Amount1b10 { get; set; }
    }
}
