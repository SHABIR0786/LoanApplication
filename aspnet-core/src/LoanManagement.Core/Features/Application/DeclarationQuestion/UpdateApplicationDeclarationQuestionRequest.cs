using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.DeclarationQuestion
{
    public class UpdateApplicationDeclarationQuestionRequest : AddApplicationDeclarationQuestionRequest
    {
        public int Id { get; set; }
    }
}
