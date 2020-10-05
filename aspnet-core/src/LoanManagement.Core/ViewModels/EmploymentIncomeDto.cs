using Abp.Application.Services.Dto;
using LoanManagement.Models;

namespace LoanManagement.ViewModels
{
    public class EmploymentIncomeDto : EntityDto<long>
    {
        public long LoanApplicationId { get; set; }
        public BorrowerEmploymentInformationDto BorrowerEmploymentInformations { get; set; }
        public BorrowerEmploymentInformationDto CoBorrowerEmploymentInformations { get; set; }
        public BorrowerMonthlyIncomeDto BorrowerMonthlyIncome { get; set; }
        public BorrowerMonthlyIncomeDto CoBorrowerMonthlyIncome { get; set; }


    }
}