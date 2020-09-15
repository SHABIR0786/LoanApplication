using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LoanManagement.Borrower_Information;
using LoanManagement.BorrowerEmploymentInformations.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanManagement.BorrowerEmploymentInformations
{
    public interface IBorrowerEmploymentInformationAppService : IApplicationService
    {

        Task<BorrowerEmploymentInformationDto> GetAsync(EntityDto<long> input);

        Task<PagedResultDto<BorrowerEmploymentInformationDto>> GetPaginatedAllAsync(PagedBorrowerEmploymentInformationDtoResultRequestDto input);

        Task<ResponseMessagesDto> CreateOrUpdateAsync(CreateOrUpdateBorrowerEmploymentInformationDto input);

        Task<ResponseMessagesDto> DeleteAsync(EntityDto<long> input);

        Task<List<BorrowerEmploymentInformation>> GetAllAsync(long? tenantId);

    }
}
