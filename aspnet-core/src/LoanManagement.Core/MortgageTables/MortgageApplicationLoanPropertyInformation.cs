using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationLoanPropertyInformation:FullAuditedEntity<int>
    {
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        public decimal LoanAmount { get; set; }
        public string LoanPurpose { get; set; }
        public string Occupancy { get; set; }
        public bool IsManufacturedHome { get; set; }
        public bool IsMixedUseProperty  { get; set; }
    }
}
