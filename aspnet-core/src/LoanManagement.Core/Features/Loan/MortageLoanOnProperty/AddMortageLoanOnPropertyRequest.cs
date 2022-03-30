using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Loan.MortageLoanOnProperty
{
    public class AddMortageLoanOnPropertyRequest
    {
        public int? ApplicationFinancialRealEstateId { get; set; }
        public string CreditorName3a9 { get; set; } = null!;
        public string AccountNumber3a10 { get; set; } = null!;
        public float? MonthlyMortagePayment3a11 { get; set; }
        public float? UnpaidBalance3a12 { get; set; }
        public ulong? PaidOff3a13 { get; set; }
        public int MortageLoanTypesId3a14 { get; set; }
        public float? CreditLimit3a15 { get; set; }
    }
}
