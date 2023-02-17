using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationAdditionalEmploymentDetail : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
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
