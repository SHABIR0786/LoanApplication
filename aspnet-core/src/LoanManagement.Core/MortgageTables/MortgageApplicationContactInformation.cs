using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationContactInformation:FullAuditedEntity<int>
    {
        public string homePhone { get; set; }
        public string cellPhone { get; set; }
        public string workPhone { get; set; }
        public string ext { get; set; }
        public string email { get; set; }
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
