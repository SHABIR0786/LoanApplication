using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class DeclarationQuestion: FullAuditedEntity<int>
    {
        public DeclarationQuestion()
        {
            ApplicationDeclarationQuestions = new HashSet<ApplicationDeclarationQuestion>();
        }

        public int? DeclarationCategoryId { get; set; }
        public int? ParentQuestionId { get; set; }
        public string Question { get; set; }
        public ulong? IsActive { get; set; }

        public virtual DeclarationCategory DeclarationCategory { get; set; }
        public virtual ICollection<ApplicationDeclarationQuestion> ApplicationDeclarationQuestions { get; set; }
    }
}
