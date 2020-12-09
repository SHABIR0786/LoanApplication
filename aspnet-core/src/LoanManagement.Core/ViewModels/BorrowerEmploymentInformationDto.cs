using Abp.Application.Services.Dto;
using System;

namespace LoanManagement.ViewModels
{
    public class BorrowerEmploymentInformationDto : EntityDto<long?>
    {
        public string EmployerName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public bool? IsSelfEmployed { get; set; }
        // public int? YearOnThisJob { get; set; }
        // public int? YearInThisLineOfWork { get; set; }
        public string Position { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        public int? ZipCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        // public decimal? MonthlyIncome { get; set; }
        // public DateTime? DateFromTo { get; set; }
        public int BorrowerTypeId { get; set; }
        public long? LoanApplicationId { get; set; }

        public bool IsNull()
        {
            return string.IsNullOrWhiteSpace(EmployerName) && string.IsNullOrWhiteSpace(Address1) &&
                   string.IsNullOrWhiteSpace(Address2) && !IsSelfEmployed.HasValue &&
                   string.IsNullOrWhiteSpace(Position) && string.IsNullOrWhiteSpace(City) &&
                   !StateId.HasValue && !ZipCode.HasValue &&
                   !StartDate.HasValue && !EndDate.HasValue;
        }
    }
}
