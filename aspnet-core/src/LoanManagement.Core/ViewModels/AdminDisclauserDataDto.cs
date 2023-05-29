using LoanManagement.codeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.ViewModels
{
    public class AdminDisclauserDataDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AdminLoanapplicationdocument adminLoanapplicationdocument { get; set; }
    }
}
