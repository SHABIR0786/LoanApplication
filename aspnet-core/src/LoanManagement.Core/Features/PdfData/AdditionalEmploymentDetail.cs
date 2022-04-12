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
        public ulong? IsEmployedBySomeone { get; set; }
        public ulong? IsSelfEmployed { get; set; }
        public ulong? IsOwnershipLessThan25 { get; set; }
        public float? MonthlyIncome { get; set; }
    }
}
