using LoanManagement.Features.Application.FinancialRealEstate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.PdfData
{
    public class FinancialRealEstateDetail
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public string Street3a21 { get; set; } = null!;
        public string UnitNo3a22 { get; set; } = null!;
        public string Zip3a25 { get; set; } = null!;
        public string Country3a26 { get; set; }
        public string State3a24 { get; set; }
        public string City3a23 { get; set; }
        public float? PropertyValue3a3 { get; set; }
        public string FinancialPropertyStatus3a4 { get; set; }
        public string FinancialPropertyIntendedOccupancy3a5 { get; set; }
        public float? MonthlyMortagePayment3a6 { get; set; }
        public float? MonthlyRentalIncome3a7 { get; set; }
        public float? NetMonthlyRentalIncome3a8 { get; set; }
        public List<MortageLoanOnPropertyDetail> MortageLoanOnPropertyDetails { get; set; }
    }
    public class MortageLoanOnPropertyDetail
    {
        public int Id { get; set; }
        public int? ApplicationFinancialRealEstateId { get; set; }
        public string CreditorName3a9 { get; set; } = null!;
        public string AccountNumber3a10 { get; set; } = null!;
        public float? MonthlyMortagePayment3a11 { get; set; }
        public float? UnpaidBalance3a12 { get; set; }
        public ulong? PaidOff3a13 { get; set; }
        public string MortageLoanType3a14 { get; set; }
        public float? CreditLimit3a15 { get; set; }

    }
}
