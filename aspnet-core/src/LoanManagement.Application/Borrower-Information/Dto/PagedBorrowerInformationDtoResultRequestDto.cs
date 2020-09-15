using Abp.Application.Services.Dto;

namespace LoanManagement.BorrowerInformations
{
    public class PagedBorrowerInformationDtoResultRequestDto : PagedResultRequestDto
    {
         public string Keyword { get; set; }
         public int? TenantId { get; set; }
    }
}

