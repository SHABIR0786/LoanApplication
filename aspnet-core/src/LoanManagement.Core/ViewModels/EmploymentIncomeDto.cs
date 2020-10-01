using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace LoanManagement.ViewModels
{
    public class EmploymentIncomeDto : EntityDto<long>
    {
        public string NameOfIndividualsOnTitle { get; set; }


    }
}