using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LoanManagement.Models;
using System.Collections.Generic;

namespace LoanManagement.ViewModels
{
    public class EmploymentIncomeDto : EntityDto<long>
    {
        public List<BorrowerEmploymentInformationDto> BorrowerEmploymentInformations { get; set; }
        public List<BorrowerEmploymentInformationDto> CoBorrowerEmploymentInformations { get; set; }
        public List<BorrowerMonthlyIncomeDto> BorrowerMonthlyIncome { get; set; }
        public List<BorrowerMonthlyIncomeDto> CoBorrowerMonthlyIncome { get; set; }


    }
}