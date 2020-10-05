using Abp.Application.Services.Dto;

namespace LoanManagement.ViewModels
{
    public class DeclarationBorrowereDemographicsInformationDto : EntityDto<long>
    {
        public bool? IsHispanicOrLatino { get; set; }
        public bool? IsMexican { get; set; }
        public bool? IsPuertoRican { get; set; }
        public bool? IsCuban { get; set; }
        public bool? IsOtherHispanicOrLatino { get; set; }
        public string Origin { get; set; }

        public bool? IsNotHispanicOrLatino { get; set; }
        public bool? IsNotProvideInformation { get; set; }
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
        public string EnterRace { get; set; }

        public bool? IsWhite { get; set; }
        public bool? IsWishToprovideInformation { get; set; }

        public bool? IsMale { get; set; }
        public bool? IsFemale { get; set; }
        public bool? IsDonotProvideSexInformattion { get; set; }

        public long LoanApplicationId { get; set; }
    }
}