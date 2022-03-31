using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class ApplicationPersonalInformation
    {
        public ApplicationPersonalInformation()
        {
            ApplicationAdditionalEmployementDetails = new HashSet<ApplicationAdditionalEmployementDetail>();
            ApplicationDeclarationQuestions = new HashSet<ApplicationDeclarationQuestion>();
            ApplicationEmployementDetails = new HashSet<ApplicationEmployementDetail>();
            ApplicationFinancialAssets = new HashSet<ApplicationFinancialAsset>();
            ApplicationFinancialLaibilities = new HashSet<ApplicationFinancialLaibility>();
            ApplicationFinancialOtherAssets = new HashSet<ApplicationFinancialOtherAsset>();
            ApplicationFinancialOtherLaibilities = new HashSet<ApplicationFinancialOtherLaibility>();
            ApplicationFinancialRealEstates = new HashSet<ApplicationFinancialRealEstate>();
            ApplicationIncomeSources = new HashSet<ApplicationIncomeSource>();
            ApplicationPreviousEmployementDetails = new HashSet<ApplicationPreviousEmployementDetail>();
            DemographicInformations = new HashSet<DemographicInformation>();
            LoanAndPropertyInformationGifts = new HashSet<LoanAndPropertyInformationGift>();
            LoanAndPropertyInformationOtherMortageLoans = new HashSet<LoanAndPropertyInformationOtherMortageLoan>();
            LoanAndPropertyInformationRentalIncomes = new HashSet<LoanAndPropertyInformationRentalIncome>();
            LoanAndPropertyInformations = new HashSet<LoanAndPropertyInformation>();
            LoanOriginatorInformations = new HashSet<LoanOriginatorInformation>();
            MilitaryServices = new HashSet<MilitaryService>();
        }

        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string FirstName1a1 { get; set; }
        public string MiddleName1a2 { get; set; }
        public string LastName1a3 { get; set; }
        public string Suffix1a4 { get; set; }
        public string AlternateFirstName1a21 { get; set; }
        public string AlternateMiddleName1a22 { get; set; }
        public string AlternateLastName1a23 { get; set; }
        public string AlternateSuffix1a24 { get; set; }
        public string Ssn1a3 { get; set; }
        public DateTime? Dob1a4 { get; set; }
        public int CitizenshipTypeId1a5 { get; set; }
        public int MaritialStatusId1a7 { get; set; }
        public int? Dependents1a8 { get; set; }
        public string Ages1a81 { get; set; }
        public string HomePhone1a9 { get; set; }
        public string CellPhone1a10 { get; set; }
        public string WorkPhone1a11 { get; set; }
        public string Ext1a111 { get; set; }
        public string Email1a12 { get; set; }
        public string CurrentStreet1a131 { get; set; }
        public string CurrentUnit1a132 { get; set; }
        public string CurrentZip1a135 { get; set; }
        public int CurrentCountryId1a136 { get; set; }
        public int CurrentStateId1a134 { get; set; }
        public int CurrentCityId1a133 { get; set; }
        public int? CurrentYears1a14 { get; set; }
        public int? CurrentMonths1a15 { get; set; }
        public int CurrentHousingTypeId1a141 { get; set; }
        public float? CurrentRent1a142 { get; set; }
        public string FormerStreet1a151 { get; set; }
        public string FormerUnit1a152 { get; set; }
        public string FormerZip1a155 { get; set; }
        public int FormerCountryId1a156 { get; set; }
        public int FormerStateId1a154 { get; set; }
        public int FormerCityId1a153 { get; set; }
        public int? FormerYears1a16 { get; set; }
        public int? FormerMonths1a161 { get; set; }
        public int FormerHousingTypeId1a161 { get; set; }
        public float? FormerRent1a162 { get; set; }
        public string MailingStreet1a171 { get; set; }
        public string MailingUnit1a172 { get; set; }
        public string MailingZip1a175 { get; set; }
        public int MailingCountryId1a176 { get; set; }
        public int MailingStateId1a174 { get; set; }
        public int MailingCityId1a173 { get; set; }

        public virtual Application Application { get; set; } = null!;
        public virtual CitizenshipType CitizenshipTypeId1a5Navigation { get; set; } = null!;
        public virtual City CurrentCityId1a133Navigation { get; set; } = null!;
        public virtual Country CurrentCountryId1a136Navigation { get; set; } = null!;
        public virtual HousingType CurrentHousingTypeId1a141Navigation { get; set; } = null!;
        public virtual State CurrentStateId1a134Navigation { get; set; } = null!;
        public virtual City FormerCityId1a153Navigation { get; set; } = null!;
        public virtual Country FormerCountryId1a156Navigation { get; set; } = null!;
        public virtual HousingType FormerHousingTypeId1a161Navigation { get; set; } = null!;
        public virtual State FormerStateId1a154Navigation { get; set; } = null!;
        public virtual City MailingCityId1a173Navigation { get; set; } = null!;
        public virtual Country MailingCountryId1a176Navigation { get; set; } = null!;
        public virtual State MailingStateId1a174Navigation { get; set; } = null!;
        public virtual MaritialStatus MaritialStatusId1a7Navigation { get; set; } = null!;
        public virtual ICollection<ApplicationAdditionalEmployementDetail> ApplicationAdditionalEmployementDetails { get; set; }
        public virtual ICollection<ApplicationDeclarationQuestion> ApplicationDeclarationQuestions { get; set; }
        public virtual ICollection<ApplicationEmployementDetail> ApplicationEmployementDetails { get; set; }
        public virtual ICollection<ApplicationFinancialAsset> ApplicationFinancialAssets { get; set; }
        public virtual ICollection<ApplicationFinancialLaibility> ApplicationFinancialLaibilities { get; set; }
        public virtual ICollection<ApplicationFinancialOtherAsset> ApplicationFinancialOtherAssets { get; set; }
        public virtual ICollection<ApplicationFinancialOtherLaibility> ApplicationFinancialOtherLaibilities { get; set; }
        public virtual ICollection<ApplicationFinancialRealEstate> ApplicationFinancialRealEstates { get; set; }
        public virtual ICollection<ApplicationIncomeSource> ApplicationIncomeSources { get; set; }
        public virtual ICollection<ApplicationPreviousEmployementDetail> ApplicationPreviousEmployementDetails { get; set; }
        public virtual ICollection<DemographicInformation> DemographicInformations { get; set; }
        public virtual ICollection<LoanAndPropertyInformationGift> LoanAndPropertyInformationGifts { get; set; }
        public virtual ICollection<LoanAndPropertyInformationOtherMortageLoan> LoanAndPropertyInformationOtherMortageLoans { get; set; }
        public virtual ICollection<LoanAndPropertyInformationRentalIncome> LoanAndPropertyInformationRentalIncomes { get; set; }
        public virtual ICollection<LoanAndPropertyInformation> LoanAndPropertyInformations { get; set; }
        public virtual ICollection<LoanOriginatorInformation> LoanOriginatorInformations { get; set; }
        public virtual ICollection<MilitaryService> MilitaryServices { get; set; }
    }
}
