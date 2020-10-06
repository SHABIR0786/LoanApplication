using Abp.Application.Services.Dto;
using LoanManagement.Models;
using Newtonsoft.Json;

namespace LoanManagement.ViewModels
{
    public class EmploymentIncomeDto : EntityDto<long>
    {
        [JsonIgnore]
        public new long Id { get; set; }
        public long? LoanApplicationId { get; set; }
        public BorrowerEmploymentInformationDto BorrowerEmploymentInformations { get; set; }
        public BorrowerEmploymentInformationDto CoBorrowerEmploymentInformations { get; set; }
        public BorrowerMonthlyIncomeDto BorrowerMonthlyIncome { get; set; }
        public BorrowerMonthlyIncomeDto CoBorrowerMonthlyIncome { get; set; }
    }
}