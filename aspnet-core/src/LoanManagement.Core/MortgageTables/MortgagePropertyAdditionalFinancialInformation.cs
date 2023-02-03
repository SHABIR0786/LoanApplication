using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgagePropertyAdditionalFinancialInformation:FullAuditedEntity<int>
    {
    
        public string street { get; set; }
        public string unit { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public decimal propertyValue { get; set; }
        public string intendedOccupancy { get; set; }
        public decimal monthlyInsurance { get; set; }
        public decimal monthlyRentalIncome { get; set; }
        public decimal netMonthlyRentalIncome { get; set; }
        public int? MortgagePropertyFinancialInformationId { get; set; }
        public virtual MortgagePropertyFinancialInformation MortgagePropertyFinancialInformation { get; set; }
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
