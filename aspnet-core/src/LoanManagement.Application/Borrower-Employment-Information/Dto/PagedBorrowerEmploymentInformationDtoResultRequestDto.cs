using Abp.Application.Services.Dto;

namespace LoanManagement.BorrowerEmploymentInformations.Dto
{
    public class PagedBorrowerEmploymentInformationDtoResultRequestDto : PagedResultRequestDto
    {
         public string Keyword { get; set; }
         public int? TenantId { get; set; }
    }
}

