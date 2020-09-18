﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement
{
    public class BorrowerEmploymentInformation : FullAuditedEntity<long>, IMayHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string EmployersName { get; set; }
        public string EmployersAddress { get; set; }
        public Boolean IsSelfEmployer { get; set; }
        public int? YearOnThisJob { get; set; }
        public int? YearInThisLineOfWork { get; set; }
        public string Position { get; set; }
        public string BusinessPhone { get; set; }
        public Decimal? MonthlyIncome { get; set; }
        public DateTime DateFromTo { get; set; }
        public int? TenantId { get; set; }
        public virtual ICollection<LoanApplication> BorrowerLoanApplication1 { get; set; }
        public virtual ICollection<LoanApplication> BorrowerLoanApplication2 { get; set; }
        public virtual ICollection<LoanApplication> BorrowerLoanApplication3 { get; set; }
        public virtual ICollection<LoanApplication> CoBorrowerLoanApplication1 { get; set; }
        public virtual ICollection<LoanApplication> CoBorrowerLoanApplication2 { get; set; }
        public virtual ICollection<LoanApplication> CoBorrowerLoanApplication3 { get; set; }

    }
}