using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class City
    {
        public City()
        {
            ApplicationAdditionalEmployementDetails = new HashSet<ApplicationAdditionalEmployementDetail>();
            ApplicationEmployementDetails = new HashSet<ApplicationEmployementDetail>();
            ApplicationFinancialRealEstates = new HashSet<ApplicationFinancialRealEstate>();
            ApplicationPersonalInformationCurrentCityId1a133Navigations = new HashSet<ApplicationPersonalInformation>();
            ApplicationPersonalInformationFormerCityId1a153Navigations = new HashSet<ApplicationPersonalInformation>();
            ApplicationPersonalInformationMailingCityId1a173Navigations = new HashSet<ApplicationPersonalInformation>();
            ApplicationPreviousEmployementDetails = new HashSet<ApplicationPreviousEmployementDetail>();
            LoanAndPropertyInformations = new HashSet<LoanAndPropertyInformation>();
        }

        public int Id { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; } = null!;

        public virtual State State { get; set; } = null!;
        public virtual ICollection<ApplicationAdditionalEmployementDetail> ApplicationAdditionalEmployementDetails { get; set; }
        public virtual ICollection<ApplicationEmployementDetail> ApplicationEmployementDetails { get; set; }
        public virtual ICollection<ApplicationFinancialRealEstate> ApplicationFinancialRealEstates { get; set; }
        public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformationCurrentCityId1a133Navigations { get; set; }
        public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformationFormerCityId1a153Navigations { get; set; }
        public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformationMailingCityId1a173Navigations { get; set; }
        public virtual ICollection<ApplicationPreviousEmployementDetail> ApplicationPreviousEmployementDetails { get; set; }
        public virtual ICollection<LoanAndPropertyInformation> LoanAndPropertyInformations { get; set; }
    }
}
