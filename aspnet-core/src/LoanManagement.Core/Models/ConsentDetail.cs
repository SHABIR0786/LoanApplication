using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace LoanManagement.Models
{
    public class ConsentDetail : FullAuditedEntity<long>
    {
        public bool? AgreeEConsent { get; set; }
         public string FirstName { get; set; }
          public string LastName { get; set; }
           public string Email { get; set; }
    }
}
