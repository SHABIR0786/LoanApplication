using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class LeadEmployementDetail: FullAuditedEntity<int>
    {
        public int EmployeeTypeId { get; set; }
        public int? LeadApplicationDetailPurchasingId { get; set; }
        public int? LeadApplicationDetailRefinancingId { get; set; }
        public int LeadApplicationTypeId { get; set; }
        public string EmployerName { get; set; }
        public string EmployementAddress { get; set; }
        public string EmployementSuite { get; set; }
        public string EmployementCity { get; set; }
        public int EmployementTaxeId { get; set; }
        public string EmployementZip { get; set; }
        public string EmployerPhoneNumber { get; set; }
        public ulong? IsCurrentJob { get; set; }
        public DateTime? EstimatedStartDate { get; set; }
        public string JobTitle { get; set; }
        public float? EstimatedAnnualBaseSalary { get; set; }
        public float? EstimatedAnnualBonus { get; set; }
        public float? EstimatedAnnualCommission { get; set; }
        public float? EstimatedAnnualOvertime { get; set; }
        public ulong? IsCoBorrower { get; set; }
    }
}
