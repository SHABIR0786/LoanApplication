using Abp.Application.Services.Dto;

namespace LoanManagement.ViewModels
{
    public class PagedLoanApplicationResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

