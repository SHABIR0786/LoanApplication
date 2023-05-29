using LoanManagement.Features.Application;
using LoanManagement.Features.Application.AdditionalEmployementIncomeDetail;
using LoanManagement.Features.Application.AdditionalEmploymentDetail;
using LoanManagement.Features.Application.ApplicationFinancialAsset;
using LoanManagement.Features.Application.ApplicationFinancialLiability;
using LoanManagement.Features.Application.ApplicationFinancialOtherAsset;
using LoanManagement.Features.Application.ApplicationFinancialOtherLaibility;
using LoanManagement.Features.Application.ApplicationIncomeSource;
using LoanManagement.Features.Application.DeclarationQuestion;
using LoanManagement.Features.Application.EmployementIncomeDetail;
using LoanManagement.Features.Application.EmploymentDetail;
using LoanManagement.Features.Application.FinancialRealEstate;
using LoanManagement.Features.Application.MilitaryService;
using LoanManagement.Features.Application.PersonalInformation;
using LoanManagement.Features.Application.PreviousEmployementDetail;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Services.Interface
{
	public interface IApplicationService
	{

		string AddApplication(InsertApplicationRequest request);
		string DeleteApplication(int id);
		string UpdateApplication(UpdateApplicationRequest request);
		List<UpdateApplicationRequest> GetApplications();
		UpdateApplicationRequest GetApplicationById(int id);

		string AddApplicationAdditionalEmployementDetail(AddAdditionalEmploymentDetailRequest request);
		string UpdateApplicationAdditionalEmployementDetail(UpdateAdditionalEmploymentDetailRequest request);
		string DeleteApplicationAdditionalEmployementDetail(int id);
		List<UpdateAdditionalEmploymentDetailRequest> GetApplicationAdditionalEmployementDetails();
		UpdateAdditionalEmploymentDetailRequest GetApplicationAdditionalEmployementDetailById(int id);

		string AddApplicationAdditionalEmployementIncomeDetail(AddAdditionalEmployementIncomeDetailRequest request);
		string UpdateApplicationAdditionalEmployementIncomeDetail(UpdateAdditionalEmployementIncomeDetailRequest request);
		string DeleteApplicationAdditionalEmployementIncomeDetail(int id);
		List<UpdateAdditionalEmployementIncomeDetailRequest> GetApplicationAdditionalEmployementIncomeDetails();
		UpdateAdditionalEmployementIncomeDetailRequest GetApplicationAdditionalEmployementIncomeDetailById(int id);

		string AddApplicationDeclarationQuestion(AddApplicationDeclarationQuestionRequest request);
		string UpdateApplicationDeclarationQuestion(UpdateApplicationDeclarationQuestionRequest request);
		string DeleteApplicationDeclarationQuestion(int id);
		List<UpdateApplicationDeclarationQuestionRequest> GetApplicationDeclarationQuestions();
		UpdateApplicationDeclarationQuestionRequest GetApplicationDeclarationQuestionById(int id);

		string AddApplicationEmployementDetail(AddEmploymentDetailRequest request);
		string UpdateApplicationEmployementDetail(UpdateEmploymentDetailRequest request);
		string DeleteApplicationEmployementDetail(int id);
		List<UpdateEmploymentDetailRequest> GetApplicationEmployementDetails();
		UpdateEmploymentDetailRequest GetApplicationEmployementDetailById(int id);

		string AddApplicationEmployementIncomeDetail(AddEmployementIncomeDetailRequest request);
		string UpdateApplicationEmployementIncomeDetail(UpdateEmployementIncomeDetailRequest request);
		string DeleteApplicationEmployementIncomeDetail(int id);
		List<UpdateEmployementIncomeDetailRequest> GetApplicationEmployementIncomeDetails();
		UpdateEmployementIncomeDetailRequest GetApplicationEmployementIncomeDetailById(int id);

		string AddApplicationPreviousEmployementDetail(AddPreviousEmployementDetailRequest request);
		string UpdateApplicationPreviousEmployementDetail(UpdatePreviousEmployementDetailRequest request);
		string DeleteApplicationPreviousEmployementDetail(int id);
		List<UpdatePreviousEmployementDetailRequest> GetApplicationPreviousEmployementDetails();
		UpdatePreviousEmployementDetailRequest GetApplicationPreviousEmployementDetailById(int id);

		string AddApplicationFinancialRealEstate(AddFinancialRealEstateRequest request);
		string UpdateApplicationFinancialRealEstate(UpdateFinancialRealEstateRequest request);
		string DeleteApplicationFinancialRealEstate(int id);
		List<UpdateFinancialRealEstateRequest> GetApplicationFinancialRealEstates();
		UpdateFinancialRealEstateRequest GetApplicationFinancialRealEstateById(int id);

		string AddApplicationPersonalInformation(AddPersonalInformationRequest request);
		string UpdateApplicationPersonalInformation(UpdatePersonalInformationRequest request);
		string DeleteApplicationPersonalInformation(int id);
		List<UpdatePersonalInformationRequest> GetApplicationPersonalInformations();
		UpdatePersonalInformationRequest GetApplicationPersonalInformationById(int id);

		string AddApplicationFinancialAsset(AddApplicationFinancialAssetRequest request);
		string UpdateApplicationFinancialAsset(UpdateApplicationFinancialAssetRequest request);
		string DeleteApplicationFinancialAsset(int id);
		List<UpdateApplicationFinancialAssetRequest> GetApplicationFinancialAssets();
		UpdateApplicationFinancialAssetRequest GetApplicationFinancialAssetById(int id);
	
		string AddApplicationFinancialLiability(AddApplicationFinancialLiabilityRequest request);
		string UpdateApplicationFinancialLiability(UpdateApplicationFinancialLiabilityRequest request);
		string DeleteApplicationFinancialLiability(int id);
		List<UpdateApplicationFinancialLiabilityRequest> GetApplicationFinancialLiabilities();
		UpdateApplicationFinancialLiabilityRequest GetApplicationFinancialLiabilityById(int id);

		string AddApplicationIncomeSource(AddApplicationIncomeSourceRequest request);
		string UpdateApplicationIncomeSource(UpdateApplicationIncomeSourceRequest request);
		string DeleteApplicationIncomeSource(int id);
		List<UpdateApplicationIncomeSourceRequest> GetApplicationIncomeSources();
		UpdateApplicationIncomeSourceRequest GetApplicationIncomeSourceById(int id);
		
		string AddApplicationFinancialOtherAsset(AddApplicationFinancialOtherAssetRequest request);
		string UpdateApplicationFinancialOtherAsset(UpdateApplicationFinancialOtherAssetRequest request);
		string DeleteApplicationFinancialOtherAsset(int id);
		List<UpdateApplicationFinancialOtherAssetRequest> GetApplicationFinancialOtherAssets();
		UpdateApplicationFinancialOtherAssetRequest GetApplicationFinancialOtherAssetById(int id);
	
		string AddApplicationFinancialOtherLaibility(AddApplicationFinancialOtherLaibilityRequest request);
		string UpdateApplicationFinancialOtherLaibility(UpdateApplicationFinancialOtherLaibilityRequest request);
		string DeleteApplicationFinancialOtherLaibility(int id);
		List<UpdateApplicationFinancialOtherLaibilityRequest> GetApplicationFinancialOtherLaibilities();
		UpdateApplicationFinancialOtherLaibilityRequest GetApplicationFinancialOtherLaibilityById(int id);
	
		string AddMilitaryService(AddMilitaryServiceRequest request);
		string UpdateMilitaryService(UpdateMilitaryServiceRequest request);
		string DeleteMilitaryService(int id);
		List<UpdateMilitaryServiceRequest> GetMilitaryServices();
		UpdateMilitaryServiceRequest GetMilitaryServiceById(int id);
	}
}
