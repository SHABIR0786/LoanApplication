using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class DemographicInformation: FullAuditedEntity<int>
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public string Ethnicity81 { get; set; }
        public string Gender82 { get; set; }
        public string Race83 { get; set; }
        public ulong? IsEthnicityByObservation84 { get; set; }
        public ulong? IsGenderByObservation85 { get; set; }
        public ulong? IsRaceByObservation86 { get; set; }
        public int? DemographicInfoSourceId87 { get; set; }

        public virtual ApplicationPersonalInformation ApplicationPersonalInformation { get; set; }
        public virtual DemographicInfoSource DemographicInfoSourceId87Navigation { get; set; }
    }
}
