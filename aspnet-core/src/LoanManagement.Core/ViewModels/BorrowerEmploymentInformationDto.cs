using Abp.Application.Services.Dto;
using System;

namespace LoanManagement.ViewModels
{
    public class BorrowerEmploymentInformationDto : EntityDto<long>
    {
        public string EmployersName1 { get; set; }

        public string EmployersAddress1 { get; set; }
        public bool IsSelfEmployer1 { get; set; }
        public int? YearOnThisJob1 { get; set; }
        public int? YearInThisLineOfWork1 { get; set; }
        public string Position1 { get; set; }
        public string BusinessPhone1 { get; set; }


        //Employer 2
        public string EmployersName2 { get; set; }

        public string EmployersAddress2 { get; set; }
        public bool IsSelfEmployer2 { get; set; }
        public DateTime DateFromTo2 { get; set; }
        public decimal? MonthlyIncome2 { get; set; }
        public string Position2 { get; set; }
        public string BusinessPhone2 { get; set; }

        //Employer 3
        public string EmployersName3 { get; set; }
        public string EmployersAddress3 { get; set; }
        public bool IsSelfEmployer3 { get; set; }
        public DateTime DateFromTo3 { get; set; }
        public decimal? MonthlyIncome3 { get; set; }
        public string Position3 { get; set; }
        public string BusinessPhone3 { get; set; }
        public string BorrowerType { get; set; }
    }
}