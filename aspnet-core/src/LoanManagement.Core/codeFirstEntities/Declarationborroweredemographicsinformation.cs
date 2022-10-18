using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Declarationborroweredemographicsinformation : FullAuditedEntity<long>
    {
        public bool? IsHispanicOrLatino { get; set; }
        public bool? IsMexican { get; set; }
        public bool? IsPuertoRican { get; set; }
        public bool? IsCuban { get; set; }
        public bool? IsOtherHispanicOrLatino { get; set; }
        public string Origin { get; set; }
        public bool? IsNotHispanicOrLatino { get; set; }
        public bool? CanNotProvideEthnic { get; set; }
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
        public bool? IsBlackOrAfricanAmerican { get; set; }
        public bool? IsNativeHawaiianOrOtherPacificIslander { get; set; }
        public bool? IsNativeHawaiian { get; set; }
        public bool? IsGuamanianOrChamorro { get; set; }
        public bool? IsSamoan { get; set; }
        public bool? IsOtherPacificIslander { get; set; }
        public string EnterRace { get; set; }
        public bool? IsWhite { get; set; }
        public bool? CanNotProvideRace { get; set; }
        public bool? IsMale { get; set; }
        public bool? IsFemale { get; set; }
        public bool? CanNotProvideSex { get; set; }
        public int BorrowerTypeId { get; set; }
        public long LoanApplicationId { get; set; }

        public virtual Borrowertype BorrowerType { get; set; }
        public virtual Loanapplication LoanApplication { get; set; }
    }
}
