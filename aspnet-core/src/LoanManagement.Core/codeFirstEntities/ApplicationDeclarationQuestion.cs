using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class ApplicationDeclarationQuestion :  FullAuditedEntity<int>
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public int? DeclarationQuestionId { get; set; }
        public ulong? YesNo { get; set; }
        public string Description5a { get; set; }

        public virtual ApplicationPersonalInformation ApplicationPersonalInformation { get; set; }
        public virtual DeclarationQuestion DeclarationQuestion { get; set; }
    }
}
