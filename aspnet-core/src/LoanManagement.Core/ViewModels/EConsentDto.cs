using Abp.Application.Services.Dto;

namespace LoanManagement.ViewModels
{
    public class EConsentDto : EntityDto<long?>
    {
        public bool? AgreeEConsent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}