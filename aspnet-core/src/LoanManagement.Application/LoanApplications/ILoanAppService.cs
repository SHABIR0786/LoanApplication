using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using LoanManagement.LoanApplications.Dto;
using LoanManagement.Roles.Dto;

namespace LoanManagement.LoanApplications
{
    public interface ILoanAppService : IAsyncCrudAppService<LoanApplicationDto, int, PagedLoanApplicationResultRequestDto, LoanApplicationDto, LoanApplicationDto>
    {
    }
}
