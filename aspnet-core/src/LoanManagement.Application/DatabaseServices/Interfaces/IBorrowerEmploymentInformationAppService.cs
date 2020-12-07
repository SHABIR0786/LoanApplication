using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using LoanManagement.Models;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IBorrowerEmploymentInformationAppService : IAsyncCrudAppService<BorrowerEmploymentInformationDto, long?, PagedLoanApplicationResultRequestDto, BorrowerEmploymentInformationDto, BorrowerEmploymentInformationDto>
    {
        Task<List<BorrowerEmploymentInformation>> GetAllAsync(long loanApplicationId);
    }
}
