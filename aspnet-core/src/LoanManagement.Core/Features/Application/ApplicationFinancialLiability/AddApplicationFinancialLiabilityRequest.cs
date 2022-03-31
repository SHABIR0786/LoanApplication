using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.ApplicationFinancialLiability
{
    public class AddApplicationFinancialLiabilityRequest
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public int FinancialLaibilitiesType2c1 { get; set; }
        public string CompanyName2c2 { get; set; }
        public string AccountNumber2c3 { get; set; }
        public float? UnpaidBalance2c4 { get; set; }
        public ulong? PaidOff2c5 { get; set; }
        public float? MonthlyValue2c6 { get; set; }
    }
}
