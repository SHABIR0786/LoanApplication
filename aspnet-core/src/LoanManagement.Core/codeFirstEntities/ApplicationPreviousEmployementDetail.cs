using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class ApplicationPreviousEmployementDetail : FullAuditedEntity<int>
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public string EmployerBusinessName1d2 { get; set; }
        public string Street1d31 { get; set; }
        public string Unit1d32 { get; set; }
        public string Zip1d35 { get; set; }
        public int CountryId1d36 { get; set; }
        public int StateId1d34 { get; set; }
        public int CityId1d33 { get; set; }
        public string PositionTitle1d4 { get; set; }
        public DateTime? StartDate1d5 { get; set; }
        public DateTime? EndDate1d6 { get; set; }
        public ulong? IsSelfEmployed1d7 { get; set; }
        public float? GrossMonthlyIncome1d8 { get; set; }

        public virtual ApplicationPersonalInformation ApplicationPersonalInformation { get; set; }
        public virtual City CityId1d33Navigation { get; set; }
        public virtual Country CountryId1d36Navigation { get; set; }
        public virtual CountryState StateId1d34Navigation { get; set; }
    }
}
