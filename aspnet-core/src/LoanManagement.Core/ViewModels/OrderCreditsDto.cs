using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace LoanManagement.ViewModels
{
    public class OrderCreditsDto : EntityDto<long>
    {
        public bool AgreeCreditAuthAgreement { get; set; }

    }
}