using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class ApplicationFinancialRealEstate : FullAuditedEntity<int>
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public string Street3a21 { get; set; }
        public string UnitNo3a22 { get; set; }
        public string Zip3a25 { get; set; }
        public int CountryId3a26 { get; set; }
        public int StateId3a24 { get; set; }
        public int CityId3a23 { get; set; }
        public float? PropertyValue3a3 { get; set; }
        public int FinancialPropertyStatusId3a4 { get; set; }
        public int FinancialPropertyIntendedOccupancyId3a5 { get; set; }
        public float? MonthlyMortagePayment3a6 { get; set; }
        public float? MonthlyRentalIncome3a7 { get; set; }
        public float? NetMonthlyRentalIncome3a8 { get; set; }

        public virtual ApplicationPersonalInformation ApplicationPersonalInformation { get; set; }
        public virtual City CityId3a23Navigation { get; set; }
        public virtual Country CountryId3a26Navigation { get; set; }
        public virtual FinancialPropertyIntendedOccupancy FinancialPropertyIntendedOccupancyId3a5Navigation { get; set; }
        public virtual FinancialPropertyStatus FinancialPropertyStatusId3a4Navigation { get; set; }
        public virtual CountryState StateId3a24Navigation { get; set; }
    }
}
