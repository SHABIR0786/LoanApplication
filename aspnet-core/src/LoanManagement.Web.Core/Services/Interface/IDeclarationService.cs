using LoanManagement.Features.Declaration.DeclarationCategory;
using LoanManagement.Features.Declaration.DeclarationQuestion;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
	public interface IDeclarationService
	{
		string AddDeclarationCategory(AddDeclarationCategoryRequest request);
		string UpdateDeclarationCategory(UpdateDeclarationCategoryRequest request);
		string DeleteDeclarationCategory(int id);
		List<UpdateDeclarationCategoryRequest> GetDeclarationCategories();
		UpdateDeclarationCategoryRequest GetDeclarationCategoryById(int id);
		string AddDeclarationQuestion(AddDeclarationQuestionRequest request);
		string UpdateDeclarationQuestion(UpdateDeclarationQuestionRequest request);
		string DeleteDeclarationQuestion(int id);
		List<UpdateDeclarationQuestionRequest> GetDeclarationQuestions();
		UpdateDeclarationQuestionRequest GetDeclarationQuestionById(int id);
	}
}
