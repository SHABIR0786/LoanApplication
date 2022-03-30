using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Declaration.DeclarationQuestion
{
    public class AddDeclarationQuestionRequest
    {
        public int? DeclarationCategoryId { get; set; }
        public int? ParentQuestionId { get; set; }
        public string Question { get; set; } = null!;
        public ulong? IsActive { get; set; }
    }
}
