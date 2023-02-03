using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationPersonalInformation : FullAuditedEntity<int>
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string suffix { get; set; }
        public int socialSecurityNumber { get; set; }
        public DateTime dob { get; set; }
        public string citizenship { get; set; }
        public string marritalStatus { get; set; }
        public string dependents { get; set; }
        public int MortgageApplication { get; set; }
        public virtual MortgageApplications MortgageApplicationId { get; set; }
    }
}
