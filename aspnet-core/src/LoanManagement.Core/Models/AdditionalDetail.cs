using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace LoanManagement.Models
{
    public class AdditionalDetail : FullAuditedEntity<long>
    {
        public string NameOfIndividualsOnTitle { get; set; }

    }
}