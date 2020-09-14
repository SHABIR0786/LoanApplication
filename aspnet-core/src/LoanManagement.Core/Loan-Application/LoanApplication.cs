using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LoanManagement.Borrower_Information;
using LoanManagement.Property_Information;

namespace LoanManagement
{
    public class LoanApplication : FullAuditedEntity<long>, IMayHaveTenant
    {
        public long MortgageTypeId { get; set; }
        public virtual MortgageType MortgageType { get; set; }

        public long PropertyInfoId { get; set; }
        public virtual PropertyInformation PropertyInfo { get; set; }

        public long BorrowerInfoId { get; set; }
        public virtual BorrowerInformation BorrowerInfo { get; set; }

        public long CoBorrowerInfoId { get; set; }
        public virtual BorrowerInformation CoBorrowerInfo { get; set; }

        public long BorrowerEmploymentInfoId { get; set; }
        public virtual BorrowerEmploymentInformation BorrowerEmploymentInfo { get; set; }

        public long CoBorrowerEmploymentInfoId { get; set; }
        public virtual BorrowerEmploymentInformation CoBorrowerEmploymentInfo { get; set; }

        public int? TenantId { get; set; }
    }
}