using LoanManagement.Features.Application.ApplicationFinancialLiability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.PdfData
{
    public class ApplicationFinancialLiabilityDetail : AddApplicationFinancialLiabilityRequest
    {
        new public string FinancialLaibilitiesType2c1 { get; set; }
    }
}
