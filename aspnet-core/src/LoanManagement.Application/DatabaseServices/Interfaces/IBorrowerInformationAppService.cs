using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IBorrowerInformationAppService : IAsyncCrudAppService<BorrowerInformationDto, long, PagedLoanApplicationResultRequestDto, BorrowerInformationDto, BorrowerInformationDto>
    {
    }
}
