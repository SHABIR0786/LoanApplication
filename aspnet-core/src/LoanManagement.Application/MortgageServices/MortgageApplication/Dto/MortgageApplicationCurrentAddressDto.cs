using Abp.Application.Services.Dto;
using Abp.AutoMapper;
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
        public string street { get; set; }
        public string unit { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public int? year { get; set; }
        public string month { get; set; }
        public string housingType { get; set; }
        public decimal rent { get; set; }
        public int? PersonalInformationId { get; set; }
      //  public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationFormerAddress))]
    public class MortgageApplicationFormerAddressDto : FullAuditedEntityDto<int>
    {
        public string street { get; set; }
        public string unit { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public int? year { get; set; }
        public string month { get; set; }
        public string housingType { get; set; }
        public decimal rent { get; set; }
        public int? PersonalInformationId { get; set; }
      //  public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationMailingAddress))]
    public class MortgageApplicationMailingAddressDto : FullAuditedEntityDto<int>
    {
        public string street { get; set; }
        public string unit { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public int? PersonalInformationId { get; set; }
      //  public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
    }
}
