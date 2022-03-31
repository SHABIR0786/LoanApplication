using Microsoft.EntityFrameworkCore;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.Declaration.DeclarationCategory;
using LoanManagement.Features.Declaration.DeclarationQuestion;
using LoanManagement.Services.Interface;
using LoanManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
	public class DeclarationService : IDeclarationService
	{
		private readonly MortgagedbContext _dbContext;

		public DeclarationService(MortgagedbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public string AddDeclarationCategory(AddDeclarationCategoryRequest request)
		{
			_dbContext.DeclarationCategories.Add(new DeclarationCategory()
			{
				DeclarationCategory1 = request.DeclarationCategory1
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateDeclarationCategory(UpdateDeclarationCategoryRequest request)
		{
			var objDeclarationCategory = _dbContext.DeclarationCategories.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objDeclarationCategory == null)
			{
				return AppConsts.NoRecordFound;
			}

			objDeclarationCategory.DeclarationCategory1 = request.DeclarationCategory1;

			_dbContext.Entry(objDeclarationCategory).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteDeclarationCategory(int id)
		{
			var objDeclarationCategory = _dbContext.DeclarationCategories.Where(s => s.Id == id).FirstOrDefault();

			if (objDeclarationCategory == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.DeclarationCategories.Remove(objDeclarationCategory);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateDeclarationCategoryRequest> GetDeclarationCategories()
		{
			return _dbContext.DeclarationCategories.Select(d => new UpdateDeclarationCategoryRequest()
			{
				Id = d.Id,
				DeclarationCategory1 = d.DeclarationCategory1
			}).ToList();
		}

		public UpdateDeclarationCategoryRequest GetDeclarationCategoryById(int id)
		{
			return _dbContext.DeclarationCategories.Where(s => s.Id == id).Select(d => new UpdateDeclarationCategoryRequest()
			{
				Id = d.Id,
				DeclarationCategory1 = d.DeclarationCategory1
			}).FirstOrDefault();
		}

		public string AddDeclarationQuestion(AddDeclarationQuestionRequest request)
		{
			_dbContext.DeclarationQuestions.Add(new DeclarationQuestion()
			{
				ParentQuestionId = request.ParentQuestionId,
				DeclarationCategoryId = request.DeclarationCategoryId,
				Question = request.Question,
				IsActive = request.IsActive
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateDeclarationQuestion(UpdateDeclarationQuestionRequest request)
		{
			var objDeclarationQuestion = _dbContext.DeclarationQuestions.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objDeclarationQuestion == null)
			{
				return AppConsts.NoRecordFound;
			}

			objDeclarationQuestion.ParentQuestionId = request.ParentQuestionId;
			objDeclarationQuestion.DeclarationCategoryId = request.DeclarationCategoryId;
			objDeclarationQuestion.Question = request.Question;
			objDeclarationQuestion.IsActive = request.IsActive;

			_dbContext.Entry(objDeclarationQuestion).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteDeclarationQuestion(int id)
		{
			var objDeclarationQuestion = _dbContext.DeclarationQuestions.Where(s => s.Id == id).FirstOrDefault();

			if (objDeclarationQuestion == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.DeclarationQuestions.Remove(objDeclarationQuestion);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateDeclarationQuestionRequest> GetDeclarationQuestions()
		{
			return _dbContext.DeclarationQuestions.Select(d => new UpdateDeclarationQuestionRequest()
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
			return _dbContext.DeclarationQuestions.Where(s => s.Id == id).Select(d => new UpdateDeclarationQuestionRequest()
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
