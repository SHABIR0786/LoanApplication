using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using LoanManagement.MortgageTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageServices.DemographicInformation.Dto
{
    [AutoMapFrom(typeof(MortgageApplicationDemographicInformation))]
    public class MortgageApplicationDemographicInformationDto:FullAuditedEntityDto<int>
    {
        public bool? IsHispanicOrLatino { get; set; }
        public bool? IsMexican { get; set; }
        public bool? IsPuertoRican { get; set; }
        public bool? IsCuban { get; set; }
        public bool? IsOtherHispanicOrLatino { get; set; }
        public string Origin { get; set; }
        public bool? IsNotHispanicOrLatino { get; set; }
        public bool? CanNotProvideEthnicInfo { get; set; }
        public bool? IsAmericanIndianOrAlaskaNative { get; set; }
        public string NameOfEnrolledOrPrincipalTribe { get; set; }
        public bool? IsAsian { get; set; }
        public bool? IsAsianIndian { get; set; }
        public bool? IsChinese { get; set; }
        public bool? IsFilipino { get; set; }
        public bool? IsJapanese { get; set; }
        public bool? IsKorean { get; set; }
        public bool? IsVietnamese { get; set; }
        public bool? IsOtherAsian { get; set; }
        public string OtherAsianRace { get; set; }
        public bool? IsBlackOrAfricanAmerican { get; set; }
        public bool? IsNativeHawaiianOrOtherPacificIslander { get; set; }
        public bool? IsNativeHawaiian { get; set; }
        public bool? IsGuamanianOrChamorro { get; set; }
        public bool? IsSamoan { get; set; }
        public bool? IsOtherPacificIslander { get; set; }
        public string OtherPacificIslanderRace { get; set; }
        public bool? IsWhite { get; set; }
        public bool? CanNotProvideRaceInfo { get; set; }
        public bool? IsMale { get; set; }
        public bool? IsFemale { get; set; }
        public bool? CanNotProvideSexInfo { get; set; }
        public string DemographicInfoSource { get; set; }
        public int? PersonalInformationId { get; set; }
        //public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        public MortgageApplicaitonDempgraphicInfoByFinancialInstitutionDto DemographicInfoByFinancialInstitution { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicaitonDempgraphicInfoByFinancialInstitution))]
    public class MortgageApplicaitonDempgraphicInfoByFinancialInstitutionDto : FullAuditedEntityDto<int>
    {
        public bool? IsEthnicityByObservation { get; set; }
        public bool? IsGenderByObservation { get; set; }
        public bool? IsRaceByObservation { get; set; }
        public int? PersonalInformationId { get; set; }
       // public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
