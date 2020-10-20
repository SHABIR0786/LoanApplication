using Abp.Application.Services.Dto;

namespace LoanManagement.ViewModels
{
    public class CreditAuthAgreementDto : EntityDto<long?>
    {
        public bool? AgreeCreditAuthAgreement { get; set; }
    }
}