using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace LoanManagement.Models
{
    public class Address : FullAuditedEntity<long>
    {
        public string AddressType { get; set; }
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public int Years { get; set; }
        public int Months { get; set; }
        
    }
}