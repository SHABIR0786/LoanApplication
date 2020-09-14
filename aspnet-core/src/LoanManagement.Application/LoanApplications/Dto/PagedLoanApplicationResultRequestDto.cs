using Abp.Application.Services.Dto;

namespace LoanManagement.Roles.Dto
{
    public class PagedLoanApplicationResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

