using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.ApplicationFinancialOtherLaibility
{
    public class AddApplicationFinancialOtherLaibilityRequest
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public int FinancialOtherLaibilitiesTypeId2d1 { get; set; }
        public float? MonthlyPayment2d2 { get; set; }
    }
}
