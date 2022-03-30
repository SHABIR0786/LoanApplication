using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class DeclarationCategory
    {
        public DeclarationCategory()
        {
            DeclarationQuestions = new HashSet<DeclarationQuestion>();
        }

        public int Id { get; set; }
        public string DeclarationCategory1 { get; set; } = null!;

        public virtual ICollection<DeclarationQuestion> DeclarationQuestions { get; set; }
    }
}
