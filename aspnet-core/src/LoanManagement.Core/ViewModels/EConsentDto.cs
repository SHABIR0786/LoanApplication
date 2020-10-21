using Abp.Application.Services.Dto;

namespace LoanManagement.ViewModels
{
    public class EConsentDto : EntityDto<long?>
    {
        public bool? AgreeEConsent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool? CoborrowerAgreeEConsent { get; set; }
        public string CoborrowerFirstName { get; set; }
        public string CoborrowerLastName { get; set; }
        public string CoborrowerEmail { get; set; }
    }
}