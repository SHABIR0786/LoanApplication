using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanManagement.Borrower_Information
{
    public class CoBorrowerEmploymentInformation : FullAuditedEntity<long>, IMayHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string CoEmployersName1 { get; set; }

        [StringLength(100)]
        public string CoEmployersAddress1 { get; set; }
        public Boolean CoIsSelfEmployer1 { get; set; }
        public int? CoYearOnThisJob1 { get; set; }
        public int? CoYearInThisLineOfWork1 { get; set; }
        public string CoPosition1 { get; set; }
        public string CoBusinessPhone1 { get; set; }


        //Employer 2
        public string CoEmployersName2 { get; set; }

        [StringLength(100)]
        public string CoEmployersAddress2 { get; set; }
        public Boolean CoIsSelfEmployer2 { get; set; }
        public DateTime CoDateFromTo2 { get; set; }
        public Decimal? CoMonthlyIncome2 { get; set; }
        public string CoPosition2 { get; set; }
        public string CoBusinessPhone2 { get; set; }

        //Employer 3
        public string CoEmployersName3 { get; set; }

        [StringLength(100)]
        public string CoEmployersAddress3 { get; set; }
        public Boolean CoIsSelfEmployer3 { get; set; }
        public DateTime CoDateFromTo3 { get; set; }
        public Decimal? CoMonthlyIncome3 { get; set; }
        public string CoPosition3 { get; set; }
        public string CoBusinessPhone3 { get; set; }

        public int? TenantId { get; set; }
    }
}
