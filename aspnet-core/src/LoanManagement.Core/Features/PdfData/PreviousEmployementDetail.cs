using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.PdfData
{
    public class PreviousEmployementDetail
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public string EmployerBusinessName1d2 { get; set; }
        public string Street1d31 { get; set; }
        public string Unit1d32 { get; set; }
        public string Zip1d35 { get; set; }
        public string Country1d36 { get; set; }
        public string StateId1d34 { get; set; }
        public string City1d33 { get; set; }
        public string PositionTitle1d4 { get; set; }
        public DateTime? StartDate1d5 { get; set; }
        public DateTime? EndDate1d6 { get; set; }
        public ulong? IsSelfEmployed1d7 { get; set; }
        public float? GrossMonthlyIncome1d8 { get; set; }
    }
}
