using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IBorrowerInformationAppService : IApplicationService
    {

        Task<BorrowerInformationDto> GetAsync(EntityDto<long> input);

        Task<PagedResultDto<BorrowerInformationDto>> GetPaginatedAllAsync(PagedBorrowerInformationDtoResultRequestDto input);

        Task<ResponseMessagesDto> CreateOrUpdateAsync(CreateOrUpdateBorrowerInformationDto input);

        Task<ResponseMessagesDto> DeleteAsync(EntityDto<long> input);

        Task<List<BorrowerInformation>> GetAllAsync(long? tenantId);

    }
}
