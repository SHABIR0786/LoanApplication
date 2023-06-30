using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LoanManagement.codeFirstEntities;
using LoanManagement.MortgageTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageServices.MortgageApplication.Dto
{
    [AutoMapFrom(typeof(MortgageApplicationCurrentAddress))]

    public class MortgageApplicationCurrentAddressDto : FullAuditedEntityDto<int>
    {
        public string Street { get; set; }
        public string Unit { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public string Zip { get; set; }     
        public int? Year { get; set; }
        public string Month { get; set; }
        public string HousingType { get; set; }
        public decimal Rent { get; set; }
        //addressType: Current,Mailing,Former
        public string AddressType { get; set; }
        public int? PersonalInformationId { get; set; }
      //  public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationFormerAddress))]
    public class MortgageApplicationFormerAddressDto : FullAuditedEntityDto<int>
    {
        public string Street { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public int? Year { get; set; }
        public string Month { get; set; }
        public string HousingType { get; set; }
        public decimal Rent { get; set; }
        public int? PersonalInformationId { get; set; }
      //  public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationMailingAddress))]
    public class MortgageApplicationMailingAddressDto : FullAuditedEntityDto<int>
    {
        public string Street { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public int? PersonalInformationId { get; set; }
      //  public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
    }
}
