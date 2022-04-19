using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.PdfData
{
    public class DeclarationCategory
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public string Category { get; set; }
        public bool? YesNo { get; set; }
        public List<ApplicationDeclarationQuestion> ApplicationDeclarationQuestions { get; set; }
    }

    public class ApplicationDeclarationQuestion
    {
        public bool? IsParent { get; set; }
        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;
        public bool? YesNo { get; set; }
    }

}
