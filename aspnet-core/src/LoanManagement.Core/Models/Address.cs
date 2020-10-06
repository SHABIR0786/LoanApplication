using Abp.Domain.Entities.Auditing;

namespace LoanManagement.Models
{
    public class Address : FullAuditedEntity<long>
    {
        public string AddressType { get; set; }
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public int? ZipCode { get; set; }
        public int? Years { get; set; }
        public int? Months { get; set; }

        public long PersonalDetailId { get; set; }
        public PersonalDetail PersonalDetail { get; set; }
    }
}