using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.AdminLoanApplicationDocument
{
    public class UploadAdminLoanApplicationDocument
    {
        public int LoanId { get; set; }
        public int DisclosureId { get; set; }
        public int UserId { get; set; }
        public IFormFile formFile { get; set; }
    }
}
