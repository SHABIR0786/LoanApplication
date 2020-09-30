using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace LoanManagement.Models
{
    public class EmploymentIncome : FullAuditedEntity<long>
    {
        public List<BorrowerEmploymentInformation> BorrowerEmploymentInformations { get; set; }
        public List<BorrowerEmploymentInformation> CoBorrowerEmploymentInformations { get; set; }
        public List<BorrowerMonthlyIncome> BorrowerMonthlyIncome { get; set; }
        public List<BorrowerMonthlyIncome> CoBorrowerMonthlyIncome { get; set; }
    }
}
