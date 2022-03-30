using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class ApplicationAdditionalEmployementDetail
    {
        public ApplicationAdditionalEmployementDetail()
        {
            ApplicationAdditionalEmployementIncomeDetails = new HashSet<ApplicationAdditionalEmployementIncomeDetail>();
        }

        public int Id { get; set; }
        public int? ApplicationPersonalInformationId { get; set; }
        public string EmployerBusinessName { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string Unit { get; set; }
        public string Zip { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string PositionTitle { get; set; }
        public DateTime? StartDate { get; set; }
        public int? WorkingYears { get; set; }
        public int? WorkingMonths { get; set; }
        public ulong? IsEmployedBySomeone { get; set; }
        public ulong? IsSelfEmployed { get; set; }
        public ulong? IsOwnershipLessThan25 { get; set; }
        public float? MonthlyIncome { get; set; }

        public virtual ApplicationPersonalInformation? ApplicationPersonalInformation { get; set; }
        public virtual City City { get; set; } = null!;
        public virtual Country Country { get; set; } = null!;
        public virtual State State { get; set; } = null!;
        public virtual ICollection<ApplicationAdditionalEmployementIncomeDetail> ApplicationAdditionalEmployementIncomeDetails { get; set; }
    }
}
