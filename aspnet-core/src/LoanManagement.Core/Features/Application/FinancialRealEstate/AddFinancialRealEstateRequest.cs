using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.FinancialRealEstate
{
    public class AddFinancialRealEstateRequest
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public string Street3a21 { get; set; } = null!;
        public string UnitNo3a22 { get; set; } = null!;
        public string Zip3a25 { get; set; } = null!;
        public int CountryId3a26{ get; set; }
        public int StateId3a24{ get; set; }
        public int CityId3a23{ get; set; }
        public float? PropertyValue3a3 { get; set; }
        public int FinancialPropertyStatusId3a4 { get; set; }
        public int FinancialPropertyIntendedOccupancyId3a5 { get; set; }
        public float? MonthlyMortagePayment3a6 { get; set; }
        public float? MonthlyRentalIncome3a7 { get; set; }
        public float? NetMonthlyRentalIncome3a8 { get; set; }
    }
}
