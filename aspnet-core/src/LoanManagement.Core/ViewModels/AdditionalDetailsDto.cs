using Abp.Application.Services.Dto;

namespace LoanManagement.ViewModels
{
    public class AdditionalDetailsDto : EntityDto<long>
    {
        public string NameOfIndividualsOnTitle { get; set; }
        public long? LoanApplicationId { get; set; }

    }
}