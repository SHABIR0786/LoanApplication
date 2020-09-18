using Abp.Application.Services.Dto;
using System;

namespace LoanManagement.ViewModels
{
    public class BorrowerEmploymentInformationDto : EntityDto<long>
    {
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
    }
}
