using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.AdditionalEmploymentDetail
{
    public class AddAdditionalEmploymentDetailRequest
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public string EmployerBusinessName { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string Unit { get; set; }
        public string Zip { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
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
