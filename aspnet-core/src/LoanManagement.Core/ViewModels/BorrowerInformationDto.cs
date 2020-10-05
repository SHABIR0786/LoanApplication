using Abp.Application.Services.Dto;
using System;

namespace LoanManagement.ViewModels
{
    public class BorrowerInformationDto : EntityDto<long>
    {
        public string BorrowersName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string HomePhone { get; set; }
        public DateTime? DOB { get; set; }
        public int? YearsSchool { get; set; }
        public string Marital { get; set; }
        public string PresentAddress { get; set; }
        public string PresentAddressType { get; set; }
        public int? PresentAddressNoOfYears { get; set; }
        public string MailingAddress { get; set; }
        public string FormerAddressModel { get; set; }
        public string FormerAddressType { get; set; }
        public int? FormerAddressNoOfYears { get; set; }
        public int? BorrowerTypeId { get; set; }
        public int? TenantId { get; set; }
        public string BorrowerType { get; set; }
    }
}
