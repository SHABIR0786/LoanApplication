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
        public string name { get; set; }
        public string phone { get; set; }
        public string street { get; set; }
        public string unit { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public string ownershipShare { get; set; }
        public string monthlyIncome { get; set; }
        public int? workingYears { get; set; }
        public int? workingMonths { get; set; }
        public string position { get; set; }
        public string startDate { get; set; }
        public bool isEmployedBySomeone { get; set; }
        public bool isSelfEmployed { get; set; }
        public bool isOwnershipLessThan25 { get; set; }
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
