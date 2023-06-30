using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgagePropertyAdditionalFinancialInformation : FullAuditedEntity<int>
    {
        public string Street { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public decimal PropertyValue { get; set; }
        public string IntendedOccupancy { get; set; }
        public decimal MonthlyInsurance { get; set; }
        public decimal MonthlyRentalIncome { get; set; }
        public decimal NetMonthlyRentalIncome { get; set; }
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
