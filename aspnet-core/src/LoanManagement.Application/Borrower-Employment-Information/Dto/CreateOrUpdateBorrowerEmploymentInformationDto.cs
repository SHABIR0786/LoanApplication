using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace LoanManagement.BorrowerEmploymentInformations.Dto
{
    public class CreateOrUpdateBorrowerEmploymentInformationDto : EntityDto<long>
    {
        public string EmployersName1 { get; set; }

        public string EmployersAddress1 { get; set; }
        public Boolean IsSelfEmployer1 { get; set; }
        public int? YearOnThisJob1 { get; set; }
        public int? YearInThisLineOfWork1 { get; set; }
        public string Position1 { get; set; }
        public string BusinessPhone1 { get; set; }


        //Employer 2
        public string EmployersName2 { get; set; }

        public string EmployersAddress2 { get; set; }
        public Boolean IsSelfEmployer2 { get; set; }
        public DateTime DateFromTo2 { get; set; }
        public Decimal? MonthlyIncome2 { get; set; }
        public string Position2 { get; set; }
        public string BusinessPhone2 { get; set; }

        //Employer 3
        public string EmployersName3 { get; set; }
        public string EmployersAddress3 { get; set; }
        public Boolean IsSelfEmployer3 { get; set; }
        public DateTime DateFromTo3 { get; set; }
        public Decimal? MonthlyIncome3 { get; set; }
        public string Position3 { get; set; }
        public string BusinessPhone3 { get; set; }
        public long? BorrowerTypeId { get; set; }
    }
}