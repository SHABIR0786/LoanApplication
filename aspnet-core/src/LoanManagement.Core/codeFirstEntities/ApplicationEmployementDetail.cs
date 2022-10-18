using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class ApplicationEmployementDetail : FullAuditedEntity<int>
    {
        public ApplicationEmployementDetail()
        {
            ApplicationEmployementIncomeDetails = new HashSet<ApplicationEmployementIncomeDetail>();
        }

        public int Id { get; set; }
        public int? ApplicationPersonalInformationId { get; set; }
        public string EmployerBusinessName1b2 { get; set; }
        public string Phone1b3 { get; set; }
        public string Street1b41 { get; set; }
        public string Unit1b42 { get; set; }
        public string Zip1b45 { get; set; }
        public int CountryId1b46 { get; set; }
        public int StateId1b44 { get; set; }
        public int CityId1b43 { get; set; }
        public string PositionTitle1b5 { get; set; }
        public DateTime? StartDate1b6 { get; set; }
        public int? WorkingYears1b7 { get; set; }
        public int? WorkingMonths { get; set; }
        public ulong? IsEmployedBySomeone1b8 { get; set; }
        public ulong? IsSelfEmployed1b9 { get; set; }
        public ulong? IsOwnershipLessThan251b91 { get; set; }
        public float? MonthlyIncome1b92 { get; set; }

        public virtual ApplicationPersonalInformation ApplicationPersonalInformation { get; set; }
        public virtual City CityId1b43Navigation { get; set; }
        public virtual Country CountryId1b46Navigation { get; set; }
        public virtual CountryState StateId1b44Navigation { get; set; }
        public virtual ICollection<ApplicationEmployementIncomeDetail> ApplicationEmployementIncomeDetails { get; set; }
    }
}
