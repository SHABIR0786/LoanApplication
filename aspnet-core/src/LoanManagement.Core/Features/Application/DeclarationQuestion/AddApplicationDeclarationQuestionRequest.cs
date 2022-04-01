using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.DeclarationQuestion
{
    public class AddApplicationDeclarationQuestionRequest
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public int? DeclarationQuestionId { get; set; }
        public ulong? YesNo { get; set; }
        public string Description5a { get; set; }
    }
}
