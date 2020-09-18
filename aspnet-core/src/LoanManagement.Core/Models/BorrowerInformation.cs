using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoanManagement.Models
{
    public class BorrowerInformation : FullAuditedEntity<long>, IMayHaveTenant
    {
        [Required]
        [StringLength(100)] public string BorrowersName { get; set; }

        [StringLength(100)] public string SocialSecurityNumber { get; set; }
        public string HomePhone { get; set; }
        public DateTime DOB { get; set; }
        public int? YearsSchool { get; set; }
        public string Marital { get; set; }
        public string PresentAddress { get; set; }
        public string PresentAddressType { get; set; }
        public int? PresentAddressNoOfYears { get; set; }

        public string MailingAddress { get; set; }
        public string FormerAddressModel { get; set; }

        public string FormerAddressType { get; set; }
        public int? FormerAddressNoOfYears { get; set; }

        public string BorrowerType { get; set; }

        public int? TenantId { get; set; }
        public virtual ICollection<LoanApplication> BorrowerLoanApplication { get; set; }
        public virtual ICollection<LoanApplication> CoBorrowerLoanApplication { get; set; }
    }
}