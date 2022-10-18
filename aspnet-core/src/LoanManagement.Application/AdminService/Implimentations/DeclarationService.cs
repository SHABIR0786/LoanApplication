using Microsoft.EntityFrameworkCore;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.Declaration.DeclarationCategory;
using LoanManagement.Features.Declaration.DeclarationQuestion;
using LoanManagement.Services.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;

namespace LoanManagement.Services.Implementation
{
	public class DeclarationService : Abp.Application.Services.ApplicationService, IDeclarationService
	{
		private readonly IRepository<DeclarationCategory, int> repository;
		private readonly IRepository<DeclarationQuestion, int> declarationQuestionRepo;

		public DeclarationService(IRepository<DeclarationCategory,int> repository, IRepository<DeclarationQuestion,int> declarationQuestionRepo)
		{
			
			this.repository = repository;
			this.declarationQuestionRepo = declarationQuestionRepo;
		}

		public string AddDeclarationCategory(AddDeclarationCategoryRequest request)
		{
			repository.Insert(new codeFirstEntities.DeclarationCategory()
			{
				DeclarationCategory1 = request.DeclarationCategory1
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateDeclarationCategory(UpdateDeclarationCategoryRequest request)
		{
			var objDeclarationCategory = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objDeclarationCategory == null)
			{
				return AppConsts.NoRecordFound;
			}

			objDeclarationCategory.DeclarationCategory1 = request.DeclarationCategory1;

			repository.Update(objDeclarationCategory);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteDeclarationCategory(int id)
		{
			var objDeclarationCategory = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objDeclarationCategory == null)
			{
				return AppConsts.NoRecordFound;
			}

			repository.Delete(objDeclarationCategory);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateDeclarationCategoryRequest> GetDeclarationCategories()
		{
			return repository.GetAll().Select(d => new UpdateDeclarationCategoryRequest()
			{
				Id = d.Id,
				DeclarationCategory1 = d.DeclarationCategory1
			}).ToList();
		}

		public UpdateDeclarationCategoryRequest GetDeclarationCategoryById(int id)
		{
			return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateDeclarationCategoryRequest()
			{
				Id = d.Id,
				DeclarationCategory1 = d.DeclarationCategory1
			}).FirstOrDefault();
		}

		public string AddDeclarationQuestion(AddDeclarationQuestionRequest request)
		{
            declarationQuestionRepo.Insert(new codeFirstEntities.DeclarationQuestion()
			{
				ParentQuestionId = request.ParentQuestionId,
				DeclarationCategoryId = request.DeclarationCategoryId,
				Question = request.Question,
				IsActive = request.IsActive
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateDeclarationQuestion(UpdateDeclarationQuestionRequest request)
		{
			var objDeclarationQuestion = declarationQuestionRepo.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objDeclarationQuestion == null)
			{
				return AppConsts.NoRecordFound;
			}

			objDeclarationQuestion.ParentQuestionId = request.ParentQuestionId;
			objDeclarationQuestion.DeclarationCategoryId = request.DeclarationCategoryId;
			objDeclarationQuestion.Question = request.Question;
			objDeclarationQuestion.IsActive = request.IsActive;

			declarationQuestionRepo.Update(objDeclarationQuestion);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteDeclarationQuestion(int id)
		{
			var objDeclarationQuestion = declarationQuestionRepo.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objDeclarationQuestion == null)
			{
				return AppConsts.NoRecordFound;
			}

			declarationQuestionRepo.Delete(objDeclarationQuestion);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateDeclarationQuestionRequest> GetDeclarationQuestions()
		{
			return declarationQuestionRepo.GetAll().Select(d => new UpdateDeclarationQuestionRequest()
			{
				Id = d.Id,
				DeclarationCategoryId = d.DeclarationCategoryId,
				IsActive = d.IsActive,
				Question = d.Question,
				ParentQuestionId = d.ParentQuestionId
			}).ToList();
		}

		public UpdateDeclarationQuestionRequest GetDeclarationQuestionById(int id)
		{
			return declarationQuestionRepo.GetAll().Where(s => s.Id == id).Select(d => new UpdateDeclarationQuestionRequest()
			{
				Id = d.Id,
				DeclarationCategoryId = d.DeclarationCategoryId,
				IsActive = d.IsActive,
				Question = d.Question,
				ParentQuestionId = d.ParentQuestionId
			}).FirstOrDefault();
		}
	}
}
