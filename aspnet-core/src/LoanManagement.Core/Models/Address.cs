using Abp.Domain.Entities.Auditing;

namespace LoanManagement.Models
{
    public class Address : FullAuditedEntity<long>
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

        public PersonalDetail PersonalDetail { get; set; }
        public State State { get; set; }
        public BorrowerType BorrowerType { get; set; }
    }
}