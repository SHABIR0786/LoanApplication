using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.PdfData
{
    public class ApplicationEmployementDetail
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public string EmployerBusinessName1b2 { get; set; }
        public string Phone1b3 { get; set; }
        public string Street1b41 { get; set; }
        public string Unit1b42 { get; set; }
        public string Zip1b45 { get; set; }
        public string Country1b46 { get; set; }
        public string State1b44 { get; set; }
        public string City1b43 { get; set; }
        public string PositionTitle1b5 { get; set; }
        public DateTime? StartDate1b6 { get; set; }
        public int? WorkingYears1b7 { get; set; }
        public int? WorkingMonths { get; set; }
        public ulong? IsEmployedBySomeone1b8 { get; set; }
        public ulong? IsSelfEmployed1b9 { get; set; }
        public ulong? IsOwnershipLessThan251b91 { get; set; }
        public float? MonthlyIncome1b92 { get; set; }
    }
}
