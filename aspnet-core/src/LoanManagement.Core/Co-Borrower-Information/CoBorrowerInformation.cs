using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanManagement.Borrower_Information
{
    public class CoBorrowerInformation : FullAuditedEntity<long>, IMayHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string CoBorrowersName { get; set; }

        [StringLength(100)]
        public string CoSocialSecurityNumber { get; set; }
        public string CoHomePhone { get; set; }
        public DateTime CoDOB { get; set; }
        public int? CoYearsSchool { get; set; }
        public string CoMarital { get; set; }
        public string CoPresentAddress { get; set; }
        public string CoPresentAddressType { get; set; }
        public int? CoPresentAddressNoOfYears { get; set; }
        public string CoMailingAddress { get; set; }
        public string CoFormerAddress { get; set; }

        public string CoFormerAddressType { get; set; }
        public int? CoFormerAddressNoOfYears { get; set; }

        public int? TenantId { get; set; }
    }
}
