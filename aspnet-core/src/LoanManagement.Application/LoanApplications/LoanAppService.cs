using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AutoMapper;
using LoanManagement.Authorization.Users;
using LoanManagement.LoanApplications.Dto;
using LoanManagement.Roles.Dto;

namespace LoanManagement.LoanApplications
{
    public class LoanAppService : ILoanAppService
    {
        public Task<LoanApplicationDto> GetAsync(EntityDto<int> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<LoanApplicationDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<LoanApplicationDto> CreateAsync(LoanApplicationDto input)
        {
            throw new NotImplementedException();
        }

        public Task<LoanApplicationDto> UpdateAsync(LoanApplicationDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(EntityDto<int> input)
        {
            throw new NotImplementedException();
        }
    }
}
