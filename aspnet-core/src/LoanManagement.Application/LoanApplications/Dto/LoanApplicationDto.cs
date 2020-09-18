using Abp.Application.Services.Dto;
using LoanManagement.AssetAndLiablity.Dto;
using LoanManagement.DetailsOfTransaction.Dto;

namespace LoanManagement.LoanApplications.Dto
{
    public class LoanApplicationDto : EntityDto<long>
    {
        public MortgageTypeDto MortgageType { get; set; }
        public PropertyInformationDto PropertyInformation { get; set; }
        public BorrowerInformationDto BorrowerInformation { get; set; }
        public BorrowerInformationDto CoBorrowerInformation { get; set; }

        public BorrowerEmploymentInformationDto BorrowerEmploymentInformation1 { get; set; }
        public BorrowerEmploymentInformationDto BorrowerEmploymentInformation2 { get; set; }
        public BorrowerEmploymentInformationDto BorrowerEmploymentInformation3 { get; set; }

        public BorrowerEmploymentInformationDto CoBorrowerEmploymentInformation1 { get; set; }
        public BorrowerEmploymentInformationDto CoBorrowerEmploymentInformation2 { get; set; }
        public BorrowerEmploymentInformationDto CoBorrowerEmploymentInformation3 { get; set; }

        public CreateOrUpdateAssetAndLiablityDto AssetAndLiablity { get; set; }
        public CreateOrUpdateDetailsOfTransactionDto DetailsOfTransaction { get; set; }
    }
}