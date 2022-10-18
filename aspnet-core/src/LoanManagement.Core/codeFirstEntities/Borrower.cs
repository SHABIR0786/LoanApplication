using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Borrower: FullAuditedEntity<long>
    {
        public Borrower()
        {
            //PersonaldetailBorrowers = new HashSet<Personaldetail>();
            //PersonaldetailCoBorrowers = new HashSet<Personaldetail>();
        }

        public long Id { get; set; }
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
        public int BorrowerTypeId { get; set; }

        public virtual Borrowertype BorrowerType { get; set; }
        //public virtual ICollection<Personaldetail> PersonaldetailBorrowers { get; set; }
        //public virtual ICollection<Personaldetail> PersonaldetailCoBorrowers { get; set; }
    }
}
