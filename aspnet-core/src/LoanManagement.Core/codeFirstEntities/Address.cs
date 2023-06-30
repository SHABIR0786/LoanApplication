using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Address : FullAuditedEntity<long>
    {

        public string AddressType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        public int? ZipCode { get; set; }
        public int? Years { get; set; }
        public int? Months { get; set; }
        public long PersonalDetailId { get; set; }
        public int BorrowerTypeId { get; set; }

        public virtual Borrowertype BorrowerType { get; set; }
        public virtual Personaldetail PersonalDetail { get; set; }
        public virtual State State { get; set; }
    }
}
