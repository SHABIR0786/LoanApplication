using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LoanManagement.codeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationEmploymentDetail:FullAuditedEntity<int>
    {
        //type: current, additional, former
        public string EmploymentType { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string Unit { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }
        public int? StateId { get; set; }
        public virtual CountryState State { get; set; }
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
        public string Zip { get; set; }
        public decimal OwnershipShare { get; set; }
        public decimal MonthlyIncome { get; set; }
        public int? WorkingYears { get; set; }
        public int? WorkingMonths { get; set; }
        public string Position { get; set; }
        public string StartDate { get; set; }
        public bool IsEmployedBySomeone { get; set; }
        public bool IsSelfEmployed { get; set; }
        public bool IsOwnershipLessThan25 { get; set; }
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
