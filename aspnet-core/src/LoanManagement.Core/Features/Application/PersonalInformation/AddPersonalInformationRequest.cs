using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.PersonalInformation
{
    public class AddPersonalInformationRequest
    {
        public int ApplicationId { get; set; }
        public string FirstName1a1 { get; set; }
        public string MiddleName1a2 { get; set; }
        public string LastName1a3 { get; set; }
        public string Suffix1a4 { get; set; }
        public string AlternateFirstName1a21 { get; set; }
        public string AlternateMiddleName1a22 { get; set; }
        public string AlternateLastName1a23 { get; set; }
        public string AlternateSuffix1a24 { get; set; }
        public string Ssn1a3 { get; set; }
        public DateTime? Dob1a4 { get; set; }
        public int CitizenshipTypeId1a5 { get; set; }
        public int MaritialStatusId1a7 { get; set; }
        public int? Dependents1a8 { get; set; }
        public string Ages1a81 { get; set; }
        public string HomePhone1a9 { get; set; }
        public string CellPhone1a10 { get; set; }
        public string WorkPhone1a11 { get; set; }
        public string Ext1a111 { get; set; }
        public string Email1a12 { get; set; }
        public string CurrentStreet1a131 { get; set; }
        public string CurrentUnit1a132 { get; set; }
        public string CurrentZip1a135 { get; set; }
        public int CurrentCountryId1a136 { get; set; }
        public int CurrentStateId1a134 { get; set; }
        public int CurrentCityId1a133 { get; set; }
        public int? CurrentYears1a14 { get; set; }
        public int? CurrentMonths1a15 { get; set; }
        public int CurrentHousingTypeId1a141 { get; set; }
        public float? CurrentRent1a142 { get; set; }
        public string FormerStreet1a151 { get; set; }
        public string FormerUnit1a152 { get; set; }
        public string FormerZip1a155 { get; set; }
        public int FormerCountryId1a156 { get; set; }
        public int FormerStateId1a154 { get; set; }
        public int FormerCityId1a153 { get; set; }
        public int? FormerYears1a16 { get; set; }
        public int? FormerMonths1a161 { get; set; }
        public int FormerHousingTypeId1a161 { get; set; }
        public float? FormerRent1a162 { get; set; }
        public string MailingStreet1a171 { get; set; }
        public string MailingUnit1a172 { get; set; }
        public string MailingZip1a175 { get; set; }
        public int MailingCountryId1a176 { get; set; }
        public int MailingStateId1a174 { get; set; }
        public int MailingCityId1a173 { get; set; }
    }
}
