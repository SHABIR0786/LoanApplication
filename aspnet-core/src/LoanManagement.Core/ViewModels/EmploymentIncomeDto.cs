using Abp.Application.Services.Dto;
using LoanManagement.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LoanManagement.ViewModels
{
    public class EmploymentIncomeDto : EntityDto<long?>
    {
        [JsonIgnore]
        public new long? Id { get; set; }
        public long? LoanApplicationId { get; set; }
        public List<AdditionalIncomeDto> AdditionalIncomes { get; set; }
        public List<BorrowerEmploymentInformationDto> BorrowerEmploymentInfo { get; set; }
        public List<BorrowerEmploymentInformationDto> CoBorrowerEmploymentInfo { get; set; }
        public BorrowerMonthlyIncomeDto BorrowerMonthlyIncome { get; set; }
        public BorrowerMonthlyIncomeDto CoBorrowerMonthlyIncome { get; set; }
    }
}