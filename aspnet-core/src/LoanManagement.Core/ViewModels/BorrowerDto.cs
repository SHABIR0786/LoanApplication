using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace LoanManagement.Models
{
    public class BorrowerDto : EntityDto<long>
    {
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }

        public string LastName { get; set; }
        public string Suffix { get; set; }

        public string Email { get; set; }

        public string DateOfBirth { get; set; }

        public string SocialSecurityNumber { get; set; }

        public int MaritalStatusId { get; set; }

        public int NumberOfDependents { get; set; }

        public string CellPhone { get; set; }

        public string HomePhone { get; set; }

        public int PersonalDetailId { get; set; }
        public int BorrowerTypeId { get; set; }

    }
}