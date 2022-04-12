using LoanManagement.Features.Application.ApplicationFinancialOtherLaibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.PdfData
{
    public class ApplicationFinancialOtherLaibilityDetail 
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public string FinancialOtherLaibilityType2d1 { get; set; }
        public float? MonthlyPayment2d2 { get; set; }
    }
}
