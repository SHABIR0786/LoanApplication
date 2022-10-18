using LoanManagement.Features.AdminLoanApplicationDocument;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
    public interface IAdminLoanApplicationDocumentService
    {
        string Add(AddAdminLoanApplicationDocument request);
        string Update(UpdateAdminLoanApplicationDocument request);
        string Delete(int id);
        List<UpdateAdminLoanApplicationDocument> GetAll();
        UpdateAdminLoanApplicationDocument GetById(int id);
        string UploadDocument(UploadAdminLoanApplicationDocument request, IFormFile formFile);
    }
}
