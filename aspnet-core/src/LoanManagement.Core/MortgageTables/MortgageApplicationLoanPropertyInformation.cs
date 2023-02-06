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
        public decimal loanAmount { get; set; }
        public string loanPurpose { get; set; }
        public string occupancy { get; set; }
        public bool isManufacturedHome { get; set; }
        public bool isMixedUseProperty  { get; set; }
    }
}
