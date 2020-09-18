using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Interfaces
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
