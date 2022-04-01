using Microsoft.AspNetCore.Mvc;
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
using LoanManagement.Services.Interface;

namespace LoanManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _service;

        public ApplicationController(IApplicationService application)
        {
            _service = application;
        }

        [HttpPost]
        [Route("add")]
        public string InsertApplication([FromBody] InsertApplicationRequest insertApplication)
        {
            return _service.AddApplication(insertApplication);
        }

        [HttpPost]
        [Route("Update")]
        public string UpdateApplication([FromBody] UpdateApplicationRequest ApplicationRequest)
        {
            return _service.UpdateApplication(ApplicationRequest);
        }

        [HttpDelete]
        [Route("Delete")]
        public string DeleteApplication([FromQuery] int id)
        {
            return _service.DeleteApplication(id);
        }

        [HttpGet]
        [Route("applications")]
        public ActionResult GetApplications()
        {
            return Ok(_service.GetApplications());
        }

        [HttpGet]
        [Route("application")]
        public ActionResult GetApplication([FromQuery] int id)
        {
            return Ok(_service.GetApplicationById(id));
        }

        [HttpPost]
        [Route("additioanl-employment-detail/add")]
        public string InsertApplicationAdditionalEmployementDetail([FromBody] AddAdditionalEmploymentDetailRequest request)
        {
            return _service.AddApplicationAdditionalEmployementDetail(request);
        }

        [HttpPost]
        [Route("additioanl-employment-detail/Update")]
        public string UpdateApplicationAdditionalEmployementDetail([FromBody] UpdateAdditionalEmploymentDetailRequest request)
        {
            return _service.UpdateApplicationAdditionalEmployementDetail(request);
        }

        [HttpDelete]
        [Route("additioanl-employment-detail/Delete")]
        public string DeleteApplicationAdditionalEmployementDetail([FromQuery] int id)
        {
            return _service.DeleteApplicationAdditionalEmployementDetail(id);
        }

        [HttpGet]
        [Route("additioanl-employment-details")]
        public ActionResult GetApplicationAdditionalEmployementDetails()
        {
            return Ok(_service.GetApplicationAdditionalEmployementDetails());
        }

        [HttpGet]
        [Route("additioanl-employment-detail")]
        public ActionResult GetApplicationAdditionalEmployementDetail([FromQuery] int id)
        {
            return Ok(_service.GetApplicationAdditionalEmployementDetailById(id));
        }

        [HttpPost]
        [Route("additioanl-employment/income-detail/add")]
        public string InsertApplicationAdditionalEmployementIncomeDetail([FromBody] AddAdditionalEmployementIncomeDetailRequest request)
        {
            return _service.AddApplicationAdditionalEmployementIncomeDetail(request);
        }

        [HttpPost]
        [Route("additioanl-employment/income-detail/Update")]
        public string UpdateApplicationAdditionalEmployementIncomeDetail([FromBody] UpdateAdditionalEmployementIncomeDetailRequest request)
        {
            return _service.UpdateApplicationAdditionalEmployementIncomeDetail(request);
        }

        [HttpDelete]
        [Route("additioanl-employment/income-detail/Delete")]
        public string DeleteApplicationAdditionalEmployementIncomeDetail([FromQuery] int id)
        {
            return _service.DeleteApplicationAdditionalEmployementIncomeDetail(id);
        }

        [HttpGet]
        [Route("additioanl-employment/income-details")]
        public ActionResult GetApplicationAdditionalEmployementIncomeDetails()
        {
            return Ok(_service.GetApplicationAdditionalEmployementIncomeDetails());
        }

        [HttpGet]
        [Route("additioanl-employment/income-detail")]
        public ActionResult GetApplicationAdditionalEmployementIncomeDetail([FromQuery] int id)
        {
            return Ok(_service.GetApplicationAdditionalEmployementIncomeDetailById(id));
        }

        [HttpPost]
        [Route("application-declaration-question/add")]
        public string InsertApplicationDeclarationQuestion([FromBody] AddApplicationDeclarationQuestionRequest request)
        {
            return _service.AddApplicationDeclarationQuestion(request);
        }

        [HttpPost]
        [Route("application-declaration-question/Update")]
        public string UpdateApplicationDeclarationQuestion([FromBody] UpdateApplicationDeclarationQuestionRequest request)
        {
            return _service.UpdateApplicationDeclarationQuestion(request);
        }

        [HttpDelete]
        [Route("application-declaration-question/Delete")]
        public string DeleteApplicationDeclarationQuestion([FromQuery] int id)
        {
            return _service.DeleteApplicationDeclarationQuestion(id);
        }

        [HttpGet]
        [Route("application-declaration-questions")]
        public ActionResult GetApplicationDeclarationQuestions()
        {
            return Ok(_service.GetApplicationDeclarationQuestions());
        }

        [HttpGet]
        [Route("application-declaration-question")]
        public ActionResult GetApplicationDeclarationQuestion([FromQuery] int id)
        {
            return Ok(_service.GetApplicationDeclarationQuestionById(id));
        }

        [HttpPost]
        [Route("employment-detail/add")]
        public string InsertApplicationEmployementDetail([FromBody] AddEmploymentDetailRequest ApplicationEmployementDetailRequest)
        {
            return _service.AddApplicationEmployementDetail(ApplicationEmployementDetailRequest);
        }

        [HttpPost]
        [Route("employment-detail/Update")]
        public string UpdateApplicationEmployementDetail([FromBody] UpdateEmploymentDetailRequest ApplicationEmployementDetailRequest)
        {
            return _service.UpdateApplicationEmployementDetail(ApplicationEmployementDetailRequest);
        }

        [HttpDelete]
        [Route("employment-detail/Delete")]
        public string DeleteApplicationEmployementDetail([FromQuery] int id)
        {
            return _service.DeleteApplicationEmployementDetail(id);
        }

        [HttpGet]
        [Route("employment-details")]
        public ActionResult GetApplicationEmployementDetails()
        {
            return Ok(_service.GetApplicationEmployementDetails());
        }

        [HttpGet]
        [Route("employment-detail")]
        public ActionResult GetApplicationEmployementDetail([FromQuery] int id)
        {
            return Ok(_service.GetApplicationEmployementDetailById(id));
        }

        [HttpPost]
        [Route("employment-income-detail/add")]
        public string InsertApplicationEmployementIncomeDetail([FromBody] AddEmployementIncomeDetailRequest ApplicationEmployementIncomeDetailRequest)
        {
            return _service.AddApplicationEmployementIncomeDetail(ApplicationEmployementIncomeDetailRequest);
        }

        [HttpPost]
        [Route("employment-income-detail/Update")]
        public string UpdateApplicationEmployementIncomeDetail([FromBody] UpdateEmployementIncomeDetailRequest ApplicationEmployementIncomeDetailRequest)
        {
            return _service.UpdateApplicationEmployementIncomeDetail(ApplicationEmployementIncomeDetailRequest);
        }

        [HttpDelete]
        [Route("employment-income-detail/Delete")]
        public string DeleteApplicationEmployementIncomeDetail([FromQuery] int id)
        {
            return _service.DeleteApplicationEmployementIncomeDetail(id);
        }

        [HttpGet]
        [Route("employment-income-details")]
        public ActionResult GetApplicationEmployementIncomeDetails()
        {
            return Ok(_service.GetApplicationEmployementIncomeDetails());
        }

        [HttpGet]
        [Route("employment-income-detail")]
        public ActionResult GetApplicationEmployementIncomeDetail([FromQuery] int id)
        {
            return Ok(_service.GetApplicationEmployementIncomeDetailById(id));
        }

        [HttpPost]
        [Route("previous-employment-detail/add")]
        public string InsertApplicationPreviousEmployementDetail([FromBody] AddPreviousEmployementDetailRequest request)
        {
            return _service.AddApplicationPreviousEmployementDetail(request);
        }

        [HttpPost]
        [Route("previous-employment-detail/Update")]
        public string UpdateApplicationPreviousEmployementDetail([FromBody] UpdatePreviousEmployementDetailRequest request)
        {
            return _service.UpdateApplicationPreviousEmployementDetail(request);
        }

        [HttpDelete]
        [Route("previous-employment-detail/Delete")]
        public string DeleteApplicationPreviousEmployementDetail([FromQuery] int id)
        {
            return _service.DeleteApplicationPreviousEmployementDetail(id);
        }

        [HttpGet]
        [Route("previous-employment-details")]
        public ActionResult GetApplicationPreviousEmployementDetails()
        {
            return Ok(_service.GetApplicationPreviousEmployementDetails());
        }

        [HttpGet]
        [Route("previous-employment-detail")]
        public ActionResult GetApplicationPreviousEmployementDetail([FromQuery] int id)
        {
            return Ok(_service.GetApplicationPreviousEmployementDetailById(id));
        }

        [HttpPost]
        [Route("financial-real-state/add")]
        public string InsertApplicationFinancialRealEstate([FromBody] AddFinancialRealEstateRequest request)
        {
            return _service.AddApplicationFinancialRealEstate(request);
        }

        [HttpPost]
        [Route("financial-real-state/Update")]
        public string UpdateApplicationFinancialRealEstate([FromBody] UpdateFinancialRealEstateRequest request)
        {
            return _service.UpdateApplicationFinancialRealEstate(request);
        }

        [HttpDelete]
        [Route("financial-real-state/Delete")]
        public string DeleteApplicationFinancialRealEstate([FromQuery] int id)
        {
            return _service.DeleteApplicationFinancialRealEstate(id);
        }

        [HttpGet]
        [Route("financial-real-states")]
        public ActionResult GetApplicationFinancialRealEstates()
        {
            return Ok(_service.GetApplicationFinancialRealEstates());
        }

        [HttpGet]
        [Route("financial-real-state")]
        public ActionResult GetApplicationFinancialRealEstate([FromQuery] int id)
        {
            return Ok(_service.GetApplicationFinancialRealEstateById(id));
        }

        [HttpPost]
        [Route("personal-information/add")]
        public string InsertApplicationPersonalInformation([FromBody] AddPersonalInformationRequest request)
        {
            return _service.AddApplicationPersonalInformation(request);
        }

        [HttpPost]
        [Route("personal-information/Update")]
        public string UpdateApplicationPersonalInformation([FromBody] UpdatePersonalInformationRequest request)
        {
            return _service.UpdateApplicationPersonalInformation(request);
        }

        [HttpDelete]
        [Route("personal-information/Delete")]
        public string DeleteApplicationPersonalInformation([FromQuery] int id)
        {
            return _service.DeleteApplicationPersonalInformation(id);
        }

        [HttpGet]
        [Route("personal-information/details")]
        public ActionResult GetApplicationPersonalInformations()
        {
            return Ok(_service.GetApplicationPersonalInformations());
        }

        [HttpGet]
        [Route("personal-information/detail")]
        public ActionResult GetApplicationPersonalInformation([FromQuery] int id)
        {
            return Ok(_service.GetApplicationPersonalInformationById(id));
        }


        [HttpPost]
        [Route("financial-asset/add")]
        public string InsertApplicationFinancialAsset([FromBody] AddApplicationFinancialAssetRequest request)
        {
            return _service.AddApplicationFinancialAsset(request);
        }

        [HttpPost]
        [Route("financial-asset/Update")]
        public string UpdateApplicationFinancialAsset([FromBody] UpdateApplicationFinancialAssetRequest request)
        {
            return _service.UpdateApplicationFinancialAsset(request);
        }

        [HttpDelete]
        [Route("financial-asset/Delete")]
        public string DeleteApplicationFinancialAsset([FromQuery] int id)
        {
            return _service.DeleteApplicationFinancialAsset(id);
        }

        [HttpGet]
        [Route("financial-assets")]
        public ActionResult GetApplicationFinancialAssets()
        {
            return Ok(_service.GetApplicationFinancialAssets());
        }

        [HttpGet]
        [Route("financial-asset")]
        public ActionResult GetApplicationFinancialAsset([FromQuery] int id)
        {
            return Ok(_service.GetApplicationFinancialAssetById(id));
        }

        [HttpPost]
        [Route("financial-Liability/add")]
        public string InsertApplicationFinancialLiability([FromBody] AddApplicationFinancialLiabilityRequest request)
        {
            return _service.AddApplicationFinancialLiability(request);
        }

        [HttpPost]
        [Route("financial-Liability/Update")]
        public string UpdateApplicationFinancialLiability([FromBody] UpdateApplicationFinancialLiabilityRequest request)
        {
            return _service.UpdateApplicationFinancialLiability(request);
        }

        [HttpDelete]
        [Route("financial-Liability/Delete")]
        public string DeleteApplicationFinancialLiability([FromQuery] int id)
        {
            return _service.DeleteApplicationFinancialLiability(id);
        }

        [HttpGet]
        [Route("financial-Liabilities")]
        public ActionResult GetApplicationFinancialLiabilities()
        {
            return Ok(_service.GetApplicationFinancialLiabilities());
        }

        [HttpGet]
        [Route("financial-Liability")]
        public ActionResult GetApplicationFinancialLiability([FromQuery] int id)
        {
            return Ok(_service.GetApplicationFinancialLiabilityById(id));
        }

        [HttpPost]
        [Route("income-source/add")]
        public string InsertApplicationIncomeSource([FromBody] AddApplicationIncomeSourceRequest ApplicationIncomeSourceRequest)
        {
            return _service.AddApplicationIncomeSource(ApplicationIncomeSourceRequest);
        }

        [HttpPost]
        [Route("income-source/Update")]
        public string UpdateApplicationIncomeSource([FromBody] UpdateApplicationIncomeSourceRequest ApplicationIncomeSourceRequest)
        {
            return _service.UpdateApplicationIncomeSource(ApplicationIncomeSourceRequest);
        }

        [HttpDelete]
        [Route("income-source/Delete")]
        public string DeleteApplicationIncomeSource([FromQuery] int id)
        {
            return _service.DeleteApplicationIncomeSource(id);
        }

        [HttpGet]
        [Route("income-sources")]
        public ActionResult GetApplicationIncomeSources()
        {
            return Ok(_service.GetApplicationIncomeSources());
        }

        [HttpGet]
        [Route("income-source")]
        public ActionResult GetApplicationIncomeSource([FromQuery] int id)
        {
            return Ok(_service.GetApplicationIncomeSourceById(id));
        }

        [HttpPost]
        [Route("other-financial-asset/add")]
        public string InsertApplicationFinancialOtherAsset([FromBody] AddApplicationFinancialOtherAssetRequest ApplicationFinancialOtherAssetRequest)
        {
            return _service.AddApplicationFinancialOtherAsset(ApplicationFinancialOtherAssetRequest);
        }

        [HttpPost]
        [Route("other-financial-asset/Update")]
        public string UpdateApplicationFinancialOtherAsset([FromBody] UpdateApplicationFinancialOtherAssetRequest ApplicationFinancialOtherAssetRequest)
        {
            return _service.UpdateApplicationFinancialOtherAsset(ApplicationFinancialOtherAssetRequest);
        }

        [HttpDelete]
        [Route("other-financial-asset/Delete")]
        public string DeleteApplicationFinancialOtherAsset([FromQuery] int id)
        {
            return _service.DeleteApplicationFinancialOtherAsset(id);
        }

        [HttpGet]
        [Route("other-financial-assets")]
        public ActionResult GetApplicationFinancialOtherAssets()
        {
            return Ok(_service.GetApplicationFinancialOtherAssets());
        }

        [HttpGet]
        [Route("other-financial-asset")]
        public ActionResult GetApplicationFinancialOtherAsset([FromQuery] int id)
        {
            return Ok(_service.GetApplicationFinancialOtherAssetById(id));
        }

        [HttpPost]
        [Route("other-financial-liability/add")]
        public string InsertApplicationFinancialOtherLaibility([FromBody] AddApplicationFinancialOtherLaibilityRequest ApplicationFinancialOtherLaibilityRequest)
        {
            return _service.AddApplicationFinancialOtherLaibility(ApplicationFinancialOtherLaibilityRequest);
        }

        [HttpPost]
        [Route("other-financial-liabilityUpdate")]
        public string UpdateApplicationFinancialOtherLaibility([FromBody] UpdateApplicationFinancialOtherLaibilityRequest ApplicationFinancialOtherLaibilityRequest)
        {
            return _service.UpdateApplicationFinancialOtherLaibility(ApplicationFinancialOtherLaibilityRequest);
        }

        [HttpDelete]
        [Route("other-financial-liabilityDelete")]
        public string DeleteApplicationFinancialOtherLaibility([FromQuery] int id)
        {
            return _service.DeleteApplicationFinancialOtherLaibility(id);
        }

        [HttpGet]
        [Route("other-financial-liabilities")]
        public ActionResult ApplicationFinancialOtherLaibilities()
        {
            return Ok(_service.GetApplicationFinancialOtherLaibilities());
        }

        [HttpGet]
        [Route("other-financial-liability")]
        public ActionResult GetApplicationFinancialOtherLaibility([FromQuery] int id)
        {
            return Ok(_service.GetApplicationFinancialOtherLaibilityById(id));
        }

        [HttpPost]
        [Route("military-service/add")]
        public string InsertMilitaryService([FromBody] AddMilitaryServiceRequest MilitaryServiceRequest)
        {
            return _service.AddMilitaryService(MilitaryServiceRequest);
        }

        [HttpPost]
        [Route("military-service/Update")]
        public string UpdateMilitaryService([FromBody] UpdateMilitaryServiceRequest MilitaryServiceRequest)
        {
            return _service.UpdateMilitaryService(MilitaryServiceRequest);
        }

        [HttpDelete]
        [Route("military-service/Delete")]
        public string DeleteMilitaryService([FromQuery] int id)
        {
            return _service.DeleteMilitaryService(id);
        }

        [HttpGet]
        [Route("military-services")]
        public ActionResult MilitaryServices()
        {
            return Ok(_service.GetMilitaryServices());
        }

        [HttpGet]
        [Route("military-service")]
        public ActionResult GetMilitaryService([FromQuery] int id)
        {
            return Ok(_service.GetMilitaryServiceById(id));
        }
    }

}

