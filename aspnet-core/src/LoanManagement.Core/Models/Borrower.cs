using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.Models
{
    public class Borrower : FullAuditedEntity<long>
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

        //[ForeignKey("PersonalDetailId")]
        //public PersonalDetail PersonalDetail { get; set; }
        public int PersonalDetailId { get; set; }

        [ForeignKey("BorrowerTypeId")]
        public BorrowerType BorrowerType { get; set; }
        public int BorrowerTypeId { get; set; }

    }
}