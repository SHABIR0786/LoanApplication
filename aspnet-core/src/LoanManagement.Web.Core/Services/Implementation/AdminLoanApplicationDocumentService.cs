using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminLoanApplicationDocument;
using LoanManagement.Services.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    public class AdminLoanApplicationDocumentService : IAdminLoanApplicationDocumentService
    {
        private readonly MortgagedbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAdminDisclosureService _adminDisclosureService;
        public AdminLoanApplicationDocumentService(MortgagedbContext dbContext, IWebHostEnvironment webHostEnvironment, IAdminDisclosureService adminDisclosureService)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
            _adminDisclosureService = adminDisclosureService;
        }
        public string Add(AddAdminLoanApplicationDocument request)
        {
            var entity = new Entities.Models.AdminLoanapplicationdocument
            {
                DisclosureId = request.DisclosureId,
                DocumentPath = request.DocumentPath,
                LoanId = request.LoanId,
                UserId = request.UserId,
            };
               _dbContext.AdminLoanapplicationdocuments.Add(entity);

            _dbContext.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {

            var obj = _dbContext.AdminLoanapplicationdocuments.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.AdminLoanapplicationdocuments.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateAdminLoanApplicationDocument> GetAll()
        {
            return _dbContext.AdminLoanapplicationdocuments.Select(d => new UpdateAdminLoanApplicationDocument()
            {
                Id = d.Id,
                DisclosureId = d.DisclosureId,
                DocumentPath = d.DocumentPath,
                LoanId = d.LoanId,
                UserId = d.UserId,
            }).ToList();
        }

        public UpdateAdminLoanApplicationDocument GetById(int id)
        {
            return _dbContext.AdminLoanapplicationdocuments.Where(s => s.Id == id).Select(d => new UpdateAdminLoanApplicationDocument()
            {
                Id = d.Id,
                DisclosureId = d.DisclosureId,
                DocumentPath = d.DocumentPath,
                LoanId = d.LoanId,
                UserId = d.UserId,
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminLoanApplicationDocument request)
        {
            var obj = _dbContext.AdminLoanapplicationdocuments.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.DisclosureId = request.DisclosureId;
            obj.DocumentPath = request.DocumentPath;
            obj.LoanId = request.LoanId;
            obj.UserId = request.UserId;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }

        public string UploadDocument(UpdateAdminLoanApplicationDocument request, IFormFile formFile)
        {
            try
            {
                var rootPath = _webHostEnvironment.ContentRootPath;

                var disclosureDetail = _adminDisclosureService.GetById(request.DisclosureId);
                var folderPath = Path.Combine(rootPath, "Documents", disclosureDetail.Title);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                FileInfo fileInfo = new FileInfo(formFile.FileName);
                var filePath = Path.Combine(folderPath, $"{request.UserId}_{Guid.NewGuid()}{fileInfo.Extension}");
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fs);
                }

                _dbContext.AdminLoanapplicationdocuments.Add(new Entities.Models.AdminLoanapplicationdocument
                {
                    DisclosureId = request.DisclosureId,
                    DocumentPath = request.DocumentPath,
                    LoanId = request.LoanId,
                    UserId = request.UserId,
                });

                _dbContext.SaveChanges();
                return entity.Id.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
