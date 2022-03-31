using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Loan.LoanAndPropertyInformation
{
    public class AddLoanAndPropertyInformationRequest
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public float? LoanAmount4a1 { get; set; }
        public string LoanPurpose4a2 { get; set; }
        public string PropertyStreet4a31 { get; set; }
        public string PropertyUnitNo4a32 { get; set; }
        public string PropertyZip4a35 { get; set; }
        public int CountryId4a36 { get; set; }
        public int StateId4a34 { get; set; }
        public int CityId4a33 { get; set; }
        public int? PropertyNumberUnits4a4 { get; set; }
        public float? PropertyValue4a5 { get; set; }
        public int? LoanPropertyOccupancyId4a6 { get; set; }
        public ulong? FhaSecondaryResidance4a61 { get; set; }
        public ulong? IsMixedUseProperty4a7 { get; set; }
        public ulong? IsManufacturedHome4a8 { get; set; }
    }
}
