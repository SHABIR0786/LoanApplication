using Abp.Domain.Repositories;
using LoanManagement.AdminService.Interfaces;
using LoanManagement.codeFirstEntities;
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
    public class AdminLoanApplicationDocumentService : Abp.Application.Services.ApplicationService, IAdminLoanApplicationDocumentService
    {
        private readonly IRepository<AdminLoanapplicationdocument, int> repository;
        private readonly IRepository<AdminDisclosure, int> admindisclousreRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminLoanApplicationDocumentService(IRepository<AdminLoanapplicationdocument,int> repository, IRepository<AdminDisclosure,int> admindisclousreRepo, IWebHostEnvironment webHostEnvironment)
        {
            this.repository = repository;
            this.admindisclousreRepo = admindisclousreRepo;
            _webHostEnvironment = webHostEnvironment;
        }
        public string Add(AddAdminLoanApplicationDocument request)
        {
            var entity = new AdminLoanapplicationdocument
            {
                DisclosureId = request.DisclosureId,
                DocumentPath = request.DocumentPath,
                LoanId = request.LoanId,
                UserId = request.UserId,
            };
               repository.Insert(entity);

            UnitOfWorkManager.Current.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {

            var obj = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

           repository.Delete(obj);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateAdminLoanApplicationDocument> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateAdminLoanApplicationDocument()
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
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateAdminLoanApplicationDocument()
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
            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.DisclosureId = request.DisclosureId;
            obj.DocumentPath = request.DocumentPath;
            obj.LoanId = request.LoanId;
            obj.UserId = request.UserId;

            repository.Update(obj);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }

        public string UploadDocument(UploadAdminLoanApplicationDocument request, IFormFile formFile)
        {
            try
            {
                var rootPath = _webHostEnvironment.ContentRootPath;

                var disclosureDetail =  admindisclousreRepo.Get(request.DisclosureId);
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
                var entity = new AdminLoanapplicationdocument
                {
                    DisclosureId = request.DisclosureId,
                    DocumentPath = filePath,
                    LoanId = request.LoanId,
                    UserId = request.UserId,
                };
                repository.Insert(entity);

                UnitOfWorkManager.Current.SaveChanges();
                return entity.Id.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
