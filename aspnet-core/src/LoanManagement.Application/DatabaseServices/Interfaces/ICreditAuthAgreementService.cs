using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface ICreditAuthAgreementService : IAsyncCrudAppService<CreditAuthAgreementDto, long?, PagedLoanApplicationResultRequestDto, CreditAuthAgreementDto, CreditAuthAgreementDto>
    {
    }
}
