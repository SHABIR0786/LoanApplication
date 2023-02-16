using Abp.Domain.Entities;
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
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public int? SocialSecurityNumber { get; set; }
        public string Dob { get; set; }
        public string Citizenship { get; set; }
        public string MarritalStatus { get; set; }
        public string Dependents { get; set; }
        public int? MortgageApplicationId { get; set; }
        public virtual MortgageApplications MortgageApplication { get; set; }
    }
}
