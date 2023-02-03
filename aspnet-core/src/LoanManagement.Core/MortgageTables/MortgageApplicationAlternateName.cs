using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationAlternateName : FullAuditedEntity<int>
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string suffix { get; set; }
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
