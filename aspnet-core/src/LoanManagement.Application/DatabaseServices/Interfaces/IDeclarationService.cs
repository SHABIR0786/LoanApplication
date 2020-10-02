using Abp.Application.Services;
using LoanManagement.ViewModels;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IDeclarationService : IAsyncCrudAppService<DeclarationDto, long, PagedLoanApplicationResultRequestDto, DeclarationDto, DeclarationDto>
    {
        Task<DeclarationBorrowereDemographicsInformationDto> CreateDeclarationBorrowereDemographicsInformation(DeclarationBorrowereDemographicsInformationDto input);
    }
}
