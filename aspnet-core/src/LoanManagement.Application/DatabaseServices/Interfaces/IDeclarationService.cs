using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using LoanManagement.codeFirstEntities;
using LoanManagement.Models;
using LoanManagement.ViewModels;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IDeclarationService : IAsyncCrudAppService<DeclarationDto, long?, PagedLoanApplicationResultRequestDto, DeclarationDto, DeclarationDto>
    {
        Task<List<Declaration>> GetAllDeclrationByLoanApplicationIdAsync(long loanApplicationId);
         Task<List<Declarationborroweredemographicsinformation>> GetAllDemographicInformationByLoanApplicationIdAsync(long loanApplicationId);
        //Task<DeclarationBorrowereDemographicsInformationDto> CreateDeclarationBorrowereDemographicsInformation(DeclarationBorrowereDemographicsInformationDto input);
    }
}
