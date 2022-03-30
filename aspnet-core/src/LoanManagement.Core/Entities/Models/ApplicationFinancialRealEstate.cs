using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class ApplicationFinancialRealEstate
    {
        public ApplicationFinancialRealEstate()
        {
            MortageLoanOnProperties = new HashSet<MortageLoanOnProperty>();
        }

        public int Id { get; set; }
        public int? ApplicationPersonalInformationId { get; set; }
        public string Street3a21 { get; set; } = null!;
        public string UnitNo3a22 { get; set; } = null!;
        public string Zip3a25 { get; set; } = null!;
        public int CountryId3a26 { get; set; }
        public int StateId3a24 { get; set; }
        public int CityId3a23 { get; set; }
        public float? PropertyValue3a3 { get; set; }
        public int FinancialPropertyStatusId3a4 { get; set; }
        public int FinancialPropertyIntendedOccupancyId3a5 { get; set; }
        public float? MonthlyMortagePayment3a6 { get; set; }
        public float? MonthlyRentalIncome3a7 { get; set; }
        public float? NetMonthlyRentalIncome3a8 { get; set; }

        public virtual ApplicationPersonalInformation? ApplicationPersonalInformation { get; set; }
        public virtual City CityId3a23Navigation { get; set; } = null!;
        public virtual Country CountryId3a26Navigation { get; set; } = null!;
        public virtual FinancialPropertyIntendedOccupancy FinancialPropertyIntendedOccupancyId3a5Navigation { get; set; } = null!;
        public virtual FinancialPropertyStatus FinancialPropertyStatusId3a4Navigation { get; set; } = null!;
        public virtual State StateId3a24Navigation { get; set; } = null!;
        public virtual ICollection<MortageLoanOnProperty> MortageLoanOnProperties { get; set; }
    }
}
