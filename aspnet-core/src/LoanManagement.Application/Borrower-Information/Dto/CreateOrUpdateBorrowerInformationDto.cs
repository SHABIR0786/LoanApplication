using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace LoanManagement.BorrowerInformations
{
    public class CreateOrUpdateBorrowerInformationDto : EntityDto<long>
    {
        [Required]
        [StringLength(100)]
        public string BorrowersName { get; set; }
        [StringLength(100)] 
        public string SocialSecurityNumber { get; set; }
        public string HomePhone { get; set; }
        public DateTime DOB { get; set; }
        public int? YearsSchool { get; set; }
        public string Marital { get; set; }
        public string PresentAddress { get; set; }
        public string PresentAddressType { get; set; }
        public int? PresentAddressNoOfYears { get; set; }

        public string MailingAddress { get; set; }
        public string FormerAddressModel { get; set; }

        public string FormerAddressType { get; set; }
        public int? FormerAddressNoOfYears { get; set; }

        public long? BorrowerTypeId { get; set; }

        public int? TenantId { get; set; }
    }
}