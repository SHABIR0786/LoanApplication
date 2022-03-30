using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class DeclarationQuestion
    {
        public DeclarationQuestion()
        {
            ApplicationDeclarationQuestions = new HashSet<ApplicationDeclarationQuestion>();
        }

        public int Id { get; set; }
        public int? DeclarationCategoryId { get; set; }
        public int? ParentQuestionId { get; set; }
        public string Question { get; set; } = null!;
        public ulong? IsActive { get; set; }

        public virtual DeclarationCategory? DeclarationCategory { get; set; }
        public virtual ICollection<ApplicationDeclarationQuestion> ApplicationDeclarationQuestions { get; set; }
    }
}
