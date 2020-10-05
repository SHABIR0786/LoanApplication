using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace LoanManagement.ViewModels
{
    public class MortgageTypeDto : EntityDto<long>
    {
        [Required]
        public string Type { get; set; }
        public string TypeExplain { get; set; }
        public string AppliedFor { get; set; }
        public string AgencyCaseNumber { get; set; }
        public string LenderCaseNumber { get; set; }
        public double? Amount { get; set; }
        public double? InterestRate { get; set; }
        public int? NumberOfMonths { get; set; }
        public string AmortizationType { get; set; }
        public string AmortizationTypeExplain { get; set; }
    }
}
