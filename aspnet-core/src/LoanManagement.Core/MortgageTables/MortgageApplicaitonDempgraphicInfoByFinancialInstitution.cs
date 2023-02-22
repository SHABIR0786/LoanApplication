using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicaitonDempgraphicInfoByFinancialInstitution:FullAuditedEntity<int>
    {
        public bool? IsEthnicityByObservation { get; set; }
        public bool? IsGenderByObservation { get; set; }
        public bool? IsRaceByObservation { get; set; }
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
