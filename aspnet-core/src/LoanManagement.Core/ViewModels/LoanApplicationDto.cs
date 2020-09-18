using Abp.Application.Services.Dto;
using LoanManagement.LoanApplications.Dto;

namespace LoanManagement.ViewModels
{
    public class LoanApplicationDto : EntityDto<long>
    {
        public MortgageTypeDto MortgageType { get; set; }
        public PropertyInformationDto PropertyInformation { get; set; }
        public CreateOrUpdateBorrowerInformationDto BorrowerInformation { get; set; }
        public CreateOrUpdateBorrowerInformationDto CoBorrowerInformation { get; set; }
        public CreateOrUpdateBorrowerEmploymentInformationDto BorrowerEmploymentInfromation { get; set; }
        public CreateOrUpdateBorrowerEmploymentInformationDto CoBorrowerEmploymentInfromation { get; set; }
        public CreateOrUpdateAssetAndLiablityDto AssetAndLiablity { get; set; }
        public CreateOrUpdateDetailsOfTransactionDto DetailsOfTransaction { get; set; }
    }
}