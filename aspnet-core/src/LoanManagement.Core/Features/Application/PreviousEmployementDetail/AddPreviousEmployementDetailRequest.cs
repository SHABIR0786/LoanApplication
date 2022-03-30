using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.PreviousEmployementDetail
{
    public class AddPreviousEmployementDetailRequest
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public string EmployerBusinessName1d2 { get; set; }
        public string Street1d31 { get; set; }
        public string Unit1d32 { get; set; }
        public string Zip1d35 { get; set; }
        public int CountryId1d36 { get; set; }
        public int StateId1d34 { get; set; }
        public int CityId1d33 { get; set; }
        public string PositionTitle1d4 { get; set; }
        public DateTime? StartDate1d5 { get; set; }
        public DateTime? EndDate1d6 { get; set; }
        public ulong? IsSelfEmployed1d7 { get; set; }
        public float? GrossMonthlyIncome1d8 { get; set; }
    }
}
