using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LoanManagement.Models;
using System.Collections.Generic;

namespace LoanManagement.ViewModels
{
    public class EmploymentIncomeDto : EntityDto<long>
    {
        public BorrowerEmploymentInformationDto BorrowerEmploymentInformations { get; set; }
        public BorrowerEmploymentInformationDto CoBorrowerEmploymentInformations { get; set; }
        public BorrowerMonthlyIncomeDto BorrowerMonthlyIncome { get; set; }
        public BorrowerMonthlyIncomeDto CoBorrowerMonthlyIncome { get; set; }


    }
}