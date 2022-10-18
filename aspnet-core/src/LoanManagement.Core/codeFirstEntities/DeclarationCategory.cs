using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class DeclarationCategory: FullAuditedEntity<int>
    {
        public DeclarationCategory()
        {
            DeclarationQuestions = new HashSet<DeclarationQuestion>();
        }

        public string DeclarationCategory1 { get; set; }

        public virtual ICollection<DeclarationQuestion> DeclarationQuestions { get; set; }
    }
}
