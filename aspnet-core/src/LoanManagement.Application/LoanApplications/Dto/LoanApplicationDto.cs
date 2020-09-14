using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using Abp.AutoMapper;
using LoanManagement.Authorization.Roles;

namespace LoanManagement.LoanApplications.Dto
{
    public class LoanApplicationDto : EntityDto<int>
    {
        [Required]
        public MortgageTypeDto MortgageType { get; set; }
        
        [Required]
        public PropertyInformationDto PropertyInformation { get; set; }
    }
}