using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.Models
{
    public class InformationForGovermentMonitoringPurposeBorrowerAndCo : FullAuditedEntity<long>, IMayHaveTenant
    {
        public string LoanOriginatorsSignature { get; set; }
        public DateTime? Date { get; set; }
        public string LoanOriginatorsName { get; set; }
        public string LoanOriginatorIdentifier { get; set; }
        public string LoanOriginatorsPhoneNumber  { get; set; }
        public string LoanOriginationCompanysName { get; set; }
        public string LoanOriginationCompanyIdentifier { get; set; }
        public string LoanOriginationCompanysAddress { get; set; }
        public string Name { get; set; }
        public int? TenantId { get; set; }

        [ForeignKey("BorrowerTypeId")]

        public int BorrowerTypeId { get; set; }
        public BorrowerType BorrowerType { get; set; }
    }
}
