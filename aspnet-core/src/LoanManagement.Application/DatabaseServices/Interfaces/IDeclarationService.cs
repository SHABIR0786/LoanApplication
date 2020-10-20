using Abp.Application.Services;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IDeclarationService : IAsyncCrudAppService<DeclarationDto, long?, PagedLoanApplicationResultRequestDto, DeclarationDto, DeclarationDto>
    {
        //Task<DeclarationBorrowereDemographicsInformationDto> CreateDeclarationBorrowereDemographicsInformation(DeclarationBorrowereDemographicsInformationDto input);
    }
}
