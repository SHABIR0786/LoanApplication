using Abp.Domain.Entities.Auditing;
using LoanManagement.codeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationLoanPropertyAddress:FullAuditedEntity<int>
    {
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        public string Street { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }
        public int? StateId { get; set; }
        public virtual CountryState State { get; set; }
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
        public string Zip { get; set; }
        public int? NumberOfUnits { get; set; }
        public decimal PropertyValue { get; set; }
    }
}
