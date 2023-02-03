using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationPreviousEmploymentDetail:FullAuditedEntity<int>
    {
        public string name { get; set; }
        public string street { get; set; }
        public string unit { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public string monthlyIncome { get; set; }
        public string position { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public bool isSelfEmployed { get; set; }
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
