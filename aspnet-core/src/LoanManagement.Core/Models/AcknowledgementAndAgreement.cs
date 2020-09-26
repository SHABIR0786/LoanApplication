using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.Models
{
    public class AcknowledgementAndAgreement : FullAuditedEntity<long>, IMayHaveTenant
    {
        public string Signature { get; set; }
        public DateTime Date { get; set; }
        public int BorrowerTypeId { get; set; }

        [ForeignKey("BorrowerTypeId")]
        public BorrowerType BorrowerType { get; set; }
        public int? TenantId { get; set; }
    }
}
