using Abp.Application.Services.Dto;
using System.Text.Json.Serialization;

namespace LoanManagement.ViewModels
{
    public class DeclarationDto : EntityDto<long?>
    {
        public new long? Id { get; set; }
        public long LoanApplicationId { get; set; }
        public DeclarationDetailDto BorrowerDeclaration { get; set; }
        public DemographicDto BorrowerDemographic { get; set; }

        public DeclarationDetailDto CoBorrowerDeclaration { get; set; }
        public DemographicDto CoBorrowerDemographic { get; set; }
    }
}
