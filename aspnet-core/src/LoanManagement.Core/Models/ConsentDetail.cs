using Abp.Domain.Entities.Auditing;

namespace LoanManagement.Models
{
    public class ConsentDetail : FullAuditedEntity<long>
    {
        public bool? AgreeEConsent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool? CoborrowerAgreeEConsent { get; set; }
        public string CoborrowerFirstName { get; set; }
        public string CoborrowerLastName { get; set; }
        public string CoborrowerEmail { get; set; }
    }
}

