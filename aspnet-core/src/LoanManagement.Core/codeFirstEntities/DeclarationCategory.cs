using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class DeclarationCategory
    {
        public DeclarationCategory()
        {
            DeclarationQuestions = new HashSet<DeclarationQuestion>();
        }

        public int Id { get; set; }
        public string DeclarationCategory1 { get; set; }

        public virtual ICollection<DeclarationQuestion> DeclarationQuestions { get; set; }
    }
}
