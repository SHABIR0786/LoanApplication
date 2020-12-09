using System;
using Abp.Application.Services.Dto;

namespace LoanManagement.ViewModels
{
    public class BorrowerDto : EntityDto<long?>
    {
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string SocialSecurityNumber { get; set; }
        public int? MaritalStatusId { get; set; }
        public int? NumberOfDependents { get; set; }
        public string CellPhone { get; set; }
        public string HomePhone { get; set; }
        public int? PersonalDetailId { get; set; }
        public int BorrowerTypeId { get; set; }

        public bool IsNull()
        {
            return string.IsNullOrWhiteSpace(FirstName) && string.IsNullOrWhiteSpace(MiddleInitial) && string.IsNullOrWhiteSpace(LastName) &&
            string.IsNullOrWhiteSpace(Suffix) && string.IsNullOrWhiteSpace(Email) && string.IsNullOrWhiteSpace(DateOfBirth) && string.IsNullOrWhiteSpace(SocialSecurityNumber) &&
            !MaritalStatusId.HasValue && !NumberOfDependents.HasValue && string.IsNullOrWhiteSpace(CellPhone) || string.IsNullOrWhiteSpace(HomePhone);
        }
    }
}