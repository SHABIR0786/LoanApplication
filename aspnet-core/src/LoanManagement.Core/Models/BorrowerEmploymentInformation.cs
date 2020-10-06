﻿using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;

namespace LoanManagement.Models
{
    public class BorrowerEmploymentInformation : FullAuditedEntity<long>
    {
        [StringLength(100)]
        public string EmployersName { get; set; }
        public string EmployersAddress1 { get; set; }
        public string EmployersAddress2 { get; set; }
        public bool? IsSelfEmployed { get; set; }

        public string Position { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        public decimal? ZipCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public BorrowerType BorrowerType { get; set; }
        public int? BorrowerTypeId { get; set; }

        public LoanApplication LoanApplication { get; set; }
        public long LoanApplicationId { get; set; }
    }
}