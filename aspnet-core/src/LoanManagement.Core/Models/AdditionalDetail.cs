using Abp.Domain.Entities.Auditing;

namespace LoanManagement.Models
{
    public class AdditionalDetail : FullAuditedEntity<long>
    {
        public string NameOfIndividualsOnTitle { get; set; }

    }
}