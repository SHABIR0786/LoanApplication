using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;

namespace LoanManagement.LoanApplications.Dto
{
    public class MortgageTypeDto : EntityDto<int>
    {
        [Required] public string Type { get; set; }
        public string TypeExplain { get; set; }
        public string AppliedFor { get; set; }
        public string AgencyCaseNumber { get; set; }
        public string LenderCaseNumber { get; set; }
        public double Amount { get; set; }
        public double InterestRate { get; set; }
        public int? NumberOfMonths { get; set; }
        public string AmortizationType { get; set; }
        public string AmortizationTypeExplain { get; set; }
    }
}
