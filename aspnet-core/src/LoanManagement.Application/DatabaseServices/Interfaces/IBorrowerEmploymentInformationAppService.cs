using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IBorrowerEmploymentInformationAppService : IAsyncCrudAppService<BorrowerEmploymentInformationDto, long, PagedLoanApplicationResultRequestDto, BorrowerEmploymentInformationDto, BorrowerEmploymentInformationDto>
    {
    }
}
