using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IBorrowerEmploymentInformationAppService : IAsyncCrudAppService<BorrowerEmploymentInformationDto, long?, PagedLoanApplicationResultRequestDto, BorrowerEmploymentInformationDto, BorrowerEmploymentInformationDto>
    {
    }
}
