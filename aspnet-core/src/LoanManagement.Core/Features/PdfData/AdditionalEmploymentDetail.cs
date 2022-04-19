using LoanManagement.Features.Application.AdditionalEmploymentDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.PdfData
{
    public class AdditionalEmploymentDetail
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public string EmployerBusinessName { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string Unit { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PositionTitle { get; set; }
        public DateTime? StartDate { get; set; }
        public int? WorkingYears { get; set; }
        public int? WorkingMonths { get; set; }
        public bool? IsEmployedBySomeone { get; set; }
        public bool? IsSelfEmployed { get; set; }
        public bool? IsOwnershipLessThan25 { get; set; }
        public float? MonthlyIncome { get; set; }
        public List<AdditionalEmployementIncomeDetail> EmployementIncomeDetail { get; set; }
    }
    
    public class AdditionalEmployementIncomeDetail
    {
        public int Id { get; set; }
        public int ApplicationAdditionalEmployementDetails { get; set; }
        public string IncomeType { get; set; }
        public float? Amount { get; set; }

    }
}
