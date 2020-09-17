using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using Abp.AutoMapper;
using LoanManagement.AssetAndLiablity.Dto;
using LoanManagement.Authorization.Roles;
using LoanManagement.BorrowerEmploymentInformations.Dto;
using LoanManagement.BorrowerInformations;
using LoanManagement.DetailsOfTransaction.Dto;

namespace LoanManagement.LoanApplications.Dto
{
    public class LoanApplicationDto : EntityDto<int>
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