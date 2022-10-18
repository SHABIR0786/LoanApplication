using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class DeclarationCategory:Entity<int>
    {
        public DeclarationCategory()
        {
            DeclarationQuestions = new HashSet<DeclarationQuestion>();
        }

        public string DeclarationCategory1 { get; set; }

        public virtual ICollection<DeclarationQuestion> DeclarationQuestions { get; set; }
    }
}
