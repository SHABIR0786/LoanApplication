using Abp.Domain.Repositories;
using LoanManagement.AdminService.Interfaces;
using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminDisclosure;
using LoanManagement.Features.AdminLoanApplicationDocument;
using LoanManagement.Services.Interface;
using LoanManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LoanManagement.Services.Implementation
{
    public class AdminLoanApplicationDocumentService : Abp.Application.Services.ApplicationService, IAdminLoanApplicationDocumentService
    {
        private readonly IRepository<AdminLoanapplicationdocument, int> repository;
        private readonly IRepository<AdminDisclosure, int> admindisclousreRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminLoanApplicationDocumentService(IRepository<AdminLoanapplicationdocument, int> repository, IRepository<AdminDisclosure, int> admindisclousreRepo, IWebHostEnvironment webHostEnvironment)
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
                //UserId = request.UserId,
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
            try
            {
                return repository.GetAll().Where(x => x.IsDeleted == false).Select(d => new UpdateAdminLoanApplicationDocument()
                {
                    Id = d.Id,
                    DisclosureId = d.DisclosureId,
                    DocumentPath = d.DocumentPath,
                    LoanId = d.LoanId,
                    UserId = d.CreatorUserId,
                }).ToList();
            } 
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }

        public UpdateAdminLoanApplicationDocument GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Where(x=>x.IsDeleted==false).Select(d => new UpdateAdminLoanApplicationDocument()
            {
                Id = d.Id,
                DisclosureId = d.DisclosureId,
                DocumentPath = d.DocumentPath,
                LoanId = d.LoanId,
                // UserId = d.UserId,
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
            //obj.UserId = request.UserId;

            repository.Update(obj);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
        public async Task GetDisclouserData()
        {
            var dis=await admindisclousreRepo.GetAll().Where(x=>x.IsDeleted==false).ToListAsync();
            var data = new List<AdminDisclauserDataDto>();
            foreach (var item in dis)
            {
                var doc=repository.GetAll().Where(x=>x.DisclosureId==item.Id).FirstOrDefault();
                var record = new AdminDisclauserDataDto()
                {
                    Id= item.Id,
                    Title= item.Title,
                    adminLoanapplicationdocument=doc,
                };
                data.Add(record);
            }
          
        }
        public string UploadFile([FromForm] UploadAdminLoanApplicationDocument request)
        {
            try
            {
              //if(request.formFile.ContentType!= "application / pdf")
                //{
                //    throw new Exception("")
                //}
                var rootPath = _webHostEnvironment.WebRootPath;
                var disclosureDetail = admindisclousreRepo.Get(request.DisclosureId);
                var folderPath = Path.Combine(rootPath, "Documents", disclosureDetail.Title);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                FileInfo fileInfo = new FileInfo(request.formFile.FileName);
                var fileName=Path.Combine($"{request.UserId}_{Guid.NewGuid()}{fileInfo.Extension}");
                var filePath = Path.Combine(folderPath, fileName);
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    request.formFile.CopyTo(fs);
                }
                using (var fs = new FileStream(filePath, FileMode.Open))
                {
                    request.formFile.CopyTo(fs);
                }
                var entity = new AdminLoanapplicationdocument
                {
                    DisclosureId = request.DisclosureId,
                    DocumentPath = fileName,
                    LoanId = request.LoanId,
                   // UserId = request.UserId,
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
        public async Task DeleteFile(int disId,int userID)
        {
            var entity = await repository.GetAll().Where(x=>x.DisclosureId== disId&&x.CreatorUserId==userID).Include(a=>a.Disclosure).FirstOrDefaultAsync();
            var rootPath = _webHostEnvironment.WebRootPath;
            var folderPath = Path.Combine(rootPath, "Documents", entity.Disclosure.Title,entity.DocumentPath);
            if(System.IO.File.Exists(folderPath))
            {
                System.IO.File.Delete(folderPath);
            }
            repository.DeleteAsync(entity.Id);
        }
        public string UploadDocument(UploadAdminLoanApplicationDocument request, IFormFile formFile)
        {
            try
            {
                var rootPath = _webHostEnvironment.ContentRootPath;

                var disclosureDetail = admindisclousreRepo.Get(request.DisclosureId);
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
                    //UserId = request.UserId,
                };
                var display = new AdminLoanapplicationdocument
                {
                    //DisclosureId = request.DisclosureId,
                    DocumentPath = filePath,
                    //LoanId = request.LoanId,
                    //UserId = request.UserId,
                };
                // repository.Insert(entity);

                // UnitOfWorkManager.Current.SaveChanges();
                return entity.Id.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    }