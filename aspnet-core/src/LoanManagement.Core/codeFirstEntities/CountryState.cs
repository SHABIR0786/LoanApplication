using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class CountryState:FullAuditedEntity<long>
    {
        public CountryState()
        {
            ApplicationAdditionalEmployementDetails = new HashSet<ApplicationAdditionalEmployementDetail>();
            ApplicationEmployementDetails = new HashSet<ApplicationEmployementDetail>();
            ApplicationFinancialRealEstates = new HashSet<ApplicationFinancialRealEstate>();
            //ApplicationPersonalInformationCurrentStateId1a134Navigations = new HashSet<ApplicationPersonalInformation>();
            //ApplicationPersonalInformationFormerStateId1a154Navigations = new HashSet<ApplicationPersonalInformation>();
            //ApplicationPersonalInformationMailingStateId1a174Navigations = new HashSet<ApplicationPersonalInformation>();
            ApplicationPreviousEmployementDetails = new HashSet<ApplicationPreviousEmployementDetail>();
            Cities = new HashSet<City>();
        }

        public int CountryId { get; set; }
        public string StateName { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<ApplicationAdditionalEmployementDetail> ApplicationAdditionalEmployementDetails { get; set; }
        public virtual ICollection<ApplicationEmployementDetail> ApplicationEmployementDetails { get; set; }
        public virtual ICollection<ApplicationFinancialRealEstate> ApplicationFinancialRealEstates { get; set; }
        //public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformationCurrentStateId1a134Navigations { get; set; }
        //public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformationFormerStateId1a154Navigations { get; set; }
        //public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformationMailingStateId1a174Navigations { get; set; }
        public virtual ICollection<ApplicationPreviousEmployementDetail> ApplicationPreviousEmployementDetails { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
