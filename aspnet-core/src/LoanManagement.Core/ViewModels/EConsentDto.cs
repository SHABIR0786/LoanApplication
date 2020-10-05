using Abp.Application.Services.Dto;

namespace LoanManagement.ViewModels
{
    public class EConsentDto : EntityDto<long>
    {
        public bool? AgreeEConsent { get; set; }
        public long LoanApplicationId { get; set; }
    }
}