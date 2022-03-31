using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Declaration.DeclarationCategory
{
    public class UpdateDeclarationCategoryRequest: AddDeclarationCategoryRequest
    {
        public int Id { get; set; }
    }
}
