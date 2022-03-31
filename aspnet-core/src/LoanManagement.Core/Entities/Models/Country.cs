using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class Country
    {
        public Country()
        {
            ApplicationAdditionalEmployementDetails = new HashSet<ApplicationAdditionalEmployementDetail>();
            ApplicationEmployementDetails = new HashSet<ApplicationEmployementDetail>();
            ApplicationFinancialRealEstates = new HashSet<ApplicationFinancialRealEstate>();
            ApplicationPersonalInformationCurrentCountryId1a136Navigations = new HashSet<ApplicationPersonalInformation>();
            ApplicationPersonalInformationFormerCountryId1a156Navigations = new HashSet<ApplicationPersonalInformation>();
            ApplicationPersonalInformationMailingCountryId1a176Navigations = new HashSet<ApplicationPersonalInformation>();
            ApplicationPreviousEmployementDetails = new HashSet<ApplicationPreviousEmployementDetail>();
            LoanAndPropertyInformations = new HashSet<LoanAndPropertyInformation>();
            States = new HashSet<State>();
        }

        public int Id { get; set; }
        public string CountryName { get; set; } = null!;

        public virtual ICollection<ApplicationAdditionalEmployementDetail> ApplicationAdditionalEmployementDetails { get; set; }
        public virtual ICollection<ApplicationEmployementDetail> ApplicationEmployementDetails { get; set; }
        public virtual ICollection<ApplicationFinancialRealEstate> ApplicationFinancialRealEstates { get; set; }
        public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformationCurrentCountryId1a136Navigations { get; set; }
        public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformationFormerCountryId1a156Navigations { get; set; }
        public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformationMailingCountryId1a176Navigations { get; set; }
        public virtual ICollection<ApplicationPreviousEmployementDetail> ApplicationPreviousEmployementDetails { get; set; }
        public virtual ICollection<LoanAndPropertyInformation> LoanAndPropertyInformations { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}
