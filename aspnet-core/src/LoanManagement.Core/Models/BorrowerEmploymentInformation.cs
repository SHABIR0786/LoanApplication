using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoanManagement.Models
{
    public class BorrowerEmploymentInformation : FullAuditedEntity<long>, IMayHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string EmployersName1 { get; set; }

        [StringLength(100)]
        public string EmployersAddress1 { get; set; }
        public bool IsSelfEmployer1 { get; set; }
        public int? YearOnThisJob1 { get; set; }
        public int? YearInThisLineOfWork1 { get; set; }
        public string Position1 { get; set; }
        public string BusinessPhone1 { get; set; }


        //Employer 2
        public string EmployersName2 { get; set; }

        [StringLength(100)] public string EmployersAddress2 { get; set; }
        public bool IsSelfEmployer2 { get; set; }
        public DateTime DateFromTo2 { get; set; }
        public decimal? MonthlyIncome2 { get; set; }
        public string Position2 { get; set; }
        public string BusinessPhone2 { get; set; }

        //Employer 3
        public string EmployersName3 { get; set; }

        [StringLength(100)]
        public string EmployersAddress3 { get; set; }
        public bool IsSelfEmployer3 { get; set; }
        public DateTime DateFromTo3 { get; set; }
        public decimal? MonthlyIncome3 { get; set; }
        public string Position3 { get; set; }
        public string BusinessPhone3 { get; set; }
        public string BorrowerType { get; set; }

        public int? TenantId { get; set; }
        public virtual ICollection<LoanApplication> BorrowerLoanApplication { get; set; }
        public virtual ICollection<LoanApplication> CoBorrowerLoanApplication { get; set; }

    }
}