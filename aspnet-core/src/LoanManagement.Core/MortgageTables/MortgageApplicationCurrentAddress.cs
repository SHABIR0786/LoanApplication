using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LoanManagement.codeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationCurrentAddress : FullAuditedEntity<int>
    {
        public string Street { get; set; }
        public string Unit { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }
        public int? StateId { get; set; }
        public virtual CountryState State { get; set; }
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
        public string Zip { get; set; }    
        public int? Year { get; set; }
        public string Month { get; set; }
        public string HousingType { get; set; }
        public decimal Rent { get; set; }
        //addressType: Current,Mailing,Former
        public string AddressType { get; set; }
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
