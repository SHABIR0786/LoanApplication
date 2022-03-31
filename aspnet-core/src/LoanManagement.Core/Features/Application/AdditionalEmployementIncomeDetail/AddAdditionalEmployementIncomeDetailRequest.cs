using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.AdditionalEmployementIncomeDetail
{
    public class AddAdditionalEmployementIncomeDetailRequest
    {
        public int ApplicationAdditionalEmployementDetails { get; set; }
        public int IncomeTypeId { get; set; }
        public float? Amount { get; set; }

    }
}
