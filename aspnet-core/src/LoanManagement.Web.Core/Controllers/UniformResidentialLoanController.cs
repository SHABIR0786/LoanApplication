using Abp.Runtime.Validation;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.AcroForms;
using PdfSharpCore.Pdf.IO;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pdf = iTextSharp.text.pdf;
using LoanManagement.Enums;

namespace LoanManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UniformResidentialLoanController : LoanManagementControllerBase
    {
        private readonly ILoanAppService _loanAppService;
        private readonly IPersonalDetailService _personalDetailService;
        private readonly IWebHostEnvironment _env;

        public UniformResidentialLoanController(
            ILoanAppService loanAppService,
            IPersonalDetailService personalDetailService,
            IWebHostEnvironment env
        )
        {
            _loanAppService = loanAppService;
            _personalDetailService = personalDetailService;
            _env = env;
        }

        [DisableValidation]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LoanApplicationDto input)
        {
            if (input == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            if (!input.Id.HasValue || input.Id.Value == default)
            {
                await _loanAppService.CreateAsync(input);
            }

            await _loanAppService.UpdateAsync(input);

            FillData(input);

            return Json(input);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] long? id)
        {
            if (!id.HasValue)
                return BadRequest(ModelState);

            return Json(await _loanAppService.GetAsync(new Abp.Application.Services.Dto.EntityDto<long?>(id.Value)));
        }

        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody] PagedLoanApplicationResultRequestDto input)
        {
            if (input == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            return Json(await _loanAppService.GetAllCustomAsync(input));
        }

        private void FillData(LoanApplicationDto data)
        {
            string pdfTemplate = @"1003irev-unlocked.pdf";
            var pdfReader = new iTextSharp.text.pdf.PdfReader(pdfTemplate);
            using (var fileStream = new FileStream(
                "1003irev-unlocked-2.pdf", FileMode.Create))
            {
                var pdfStamper = new Pdf.PdfStamper(pdfReader, fileStream);
                var pdfFormFields = pdfStamper.AcroFields;

                String[] BorrowerJudgementsAgainst = pdfFormFields.GetAppearanceStates("Borrower Judgements against");
                if (data.Declaration.BorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == true)
                    pdfFormFields.SetField("Borrower Judgements against", "2");
                else if (data.Declaration.BorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == false)
                    pdfFormFields.SetField("Borrower Judgements against", "5");

                String[] BorrowerIsDeclaredBankrupt = pdfFormFields.GetAppearanceStates("Borrower Bankrupt");
                if (data.Declaration.BorrowerDeclaration.IsDeclaredBankrupt == true)
                    pdfFormFields.SetField("Borrower Bankrupt", "2");
                else if (data.Declaration.BorrowerDeclaration.IsDeclaredBankrupt == false)
                    pdfFormFields.SetField("Borrower Bankrupt", "5");

                String[] BorrowerLawsuit = pdfFormFields.GetAppearanceStates("Borrower Lawsuit");
                if (data.Declaration.BorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == true)
                    pdfFormFields.SetField("Borrower Lawsuit", "Two");
                else if (data.Declaration.BorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == false)
                    pdfFormFields.SetField("Borrower Lawsuit", "Five");

                String[] BorrowerForclose = pdfFormFields.GetAppearanceStates("Check Box");
                if (data.Declaration.BorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle == true)
                    pdfFormFields.SetField("Check Box", "2");
                else if (data.Declaration.CoBorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle == false)
                    pdfFormFields.SetField("Check Box", "5");

                String[] BorrowerLiability = pdfFormFields.GetAppearanceStates("Borrower Liability");
                if (data.Declaration.BorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure == true)
                    pdfFormFields.SetField("Borrower Liability", "2");
                else if (data.Declaration.BorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure == false)
                    pdfFormFields.SetField("Borrower Liability", "5");

                String[] BorrowerIsAnyPartOfTheDownPayment = pdfFormFields.GetAppearanceStates("h borrower");
                if (data.Declaration.BorrowerDeclaration.IsAnyPartOfTheDownPayment == true)
                    pdfFormFields.SetField("h borrower", "2");
                else if (data.Declaration.BorrowerDeclaration.IsAnyPartOfTheDownPayment == true)
                    pdfFormFields.SetField("h borrower", "1");

                String[] BorrowerIsCoMakerOrEndorser = pdfFormFields.GetAppearanceStates("i borrower");
                if (data.Declaration.BorrowerDeclaration.IsCoMakerOrEndorser == true)
                    pdfFormFields.SetField("i borrower", "Yes");
                else if (data.Declaration.BorrowerDeclaration.IsCoMakerOrEndorser == true)
                    pdfFormFields.SetField("i borrower", "2");

                String[] BorrowerisPresentlyDelinquent = pdfFormFields.GetAppearanceStates("f borrower");
                if (data.Declaration.BorrowerDeclaration.IsPresentlyDelinquent == true)
                    pdfFormFields.SetField("f borrower", "1");
                else if (data.Declaration.BorrowerDeclaration.IsPresentlyDelinquent == true)
                    pdfFormFields.SetField("f borrower", "No");

                String[] BorrowerIsObligatedToPayAlimonyChildSupport = pdfFormFields.GetAppearanceStates("g borrower");
                if (data.Declaration.BorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == true)
                    pdfFormFields.SetField("g borrower", "1");
                else if (data.Declaration.BorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == false)
                    pdfFormFields.SetField("g borrower", "No");

                String[] BorrowerIsUSCitizen = pdfFormFields.GetAppearanceStates("j borrower");
                if (data.Declaration.BorrowerDeclaration.IsUSCitizen == true)
                    pdfFormFields.SetField("j borrower", "2");
                else if (data.Declaration.BorrowerDeclaration.IsUSCitizen == false)
                    pdfFormFields.SetField("j borrower", "1");

                String[] BorrowerIsPermanentResidentSlien = pdfFormFields.GetAppearanceStates("k borrower");
                if (data.Declaration.BorrowerDeclaration.IsPermanentResidentSlien == true)
                    pdfFormFields.SetField("k borrower", "Yes");
                else if (data.Declaration.BorrowerDeclaration.IsPermanentResidentSlien == false)
                    pdfFormFields.SetField("k borrower", "2");

                String[] BorrowerIsIntendToOccupyThePropertyAsYourPrimary = pdfFormFields.GetAppearanceStates("l borrower");
                if (data.Declaration.BorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary == true)
                    pdfFormFields.SetField("l borrower", "yes");
                else if (data.Declaration.BorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary == false)
                    pdfFormFields.SetField("l borrower", "no");

                String[] BorrowerIsOwnershipInterestInPropertyInTheLastThreeYears = pdfFormFields.GetAppearanceStates("m borrower");
                if (data.Declaration.BorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == true)
                    pdfFormFields.SetField("m borrower", "yes");
                else if (data.Declaration.BorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == false)
                    pdfFormFields.SetField("m borrower", "No");
                if (data.Declaration.CoBorrowerDeclaration != null)
                {
                    String[] CoBorrowerJudgementsAgainst = pdfFormFields.GetAppearanceStates("Co-Borrower Judgements against");
                    if (data.Declaration.CoBorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == true)
                        pdfFormFields.SetField("Co-Borrower Judgements against", "2");
                    else if (data.Declaration.CoBorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == false)
                        pdfFormFields.SetField("Co-Borrower Judgements against", "5");

                    String[] CoBorrowerIsDeclaredBankrupt = pdfFormFields.GetAppearanceStates("Co-Borrower Bankrupt y");
                    if (data.Declaration.CoBorrowerDeclaration.IsDeclaredBankrupt == true)
                        pdfFormFields.SetField("Co-Borrower Bankrupt y", "2");
                    else if (data.Declaration.CoBorrowerDeclaration.IsDeclaredBankrupt == false)
                        pdfFormFields.SetField("Co-Borrower Bankrupt y", "5");

                    String[] CoBorrowerLawsuit = pdfFormFields.GetAppearanceStates("Co-Borrower Lawsuit y");
                    if (data.Declaration.CoBorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == true)
                        pdfFormFields.SetField("Co-Borrower Lawsuit y", "2");
                    else if (data.Declaration.CoBorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == false)
                        pdfFormFields.SetField("Co-Borrower Lawsuit y", "5");

                    String[] CoBorrowerForclose = pdfFormFields.GetAppearanceStates("Co-Borrower Forclose y");
                    if (data.Declaration.BorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle == true)
                        pdfFormFields.SetField("Co-Borrower Forclose y", "2");
                    else if (data.Declaration.CoBorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle == false)
                        pdfFormFields.SetField("Co-Borrower Forclose y", "5");

                    String[] CoBorrowerLiability = pdfFormFields.GetAppearanceStates("Co-Borrower Liability y");
                    if (data.Declaration.CoBorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure == true)
                        pdfFormFields.SetField("Co-Borrower Liability y", "2");
                    else if (data.Declaration.CoBorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure == false)
                        pdfFormFields.SetField("Co-Borrower Liability y", "5");

                    String[] CoBorrowerIsCoMakerOrEndorser = pdfFormFields.GetAppearanceStates("i coborrower");
                    if (data.Declaration.CoBorrowerDeclaration.IsCoMakerOrEndorser == true)
                        pdfFormFields.SetField("i coborrower", "Yes");
                    else if (data.Declaration.CoBorrowerDeclaration.IsCoMakerOrEndorser == true)
                        pdfFormFields.SetField("i coborrower", "2");


                    String[] CoBorrowerIsAnyPartOfTheDownPayment = pdfFormFields.GetAppearanceStates("h coborrower");
                    if (data.Declaration.CoBorrowerDeclaration.IsAnyPartOfTheDownPayment == true)
                        pdfFormFields.SetField("h coborrower", "Yes");
                    else if (data.Declaration.CoBorrowerDeclaration.IsAnyPartOfTheDownPayment == true)
                        pdfFormFields.SetField("h coborrower", "2");

                    String[] CoBorrowerisPresentlyDelinquent = pdfFormFields.GetAppearanceStates("f coborrower");
                    if (data.Declaration.CoBorrowerDeclaration.IsPresentlyDelinquent == true)
                        pdfFormFields.SetField("f coborrower", "1");
                    else if (data.Declaration.CoBorrowerDeclaration.IsPresentlyDelinquent == true)
                        pdfFormFields.SetField("f coborrower", "No");

                    String[] CoBorrowerIsObligatedToPayAlimonyChildSupport = pdfFormFields.GetAppearanceStates("g coborrower");
                    if (data.Declaration.CoBorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == true)
                        pdfFormFields.SetField("g coborrower", "1");
                    else if (data.Declaration.CoBorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == false)
                        pdfFormFields.SetField("g coborrower", "No");

                    String[] CoBorrowerIsUSCitizen = pdfFormFields.GetAppearanceStates("j coborrower");
                    if (data.Declaration.CoBorrowerDeclaration.IsUSCitizen == true)
                        pdfFormFields.SetField("j borrower", "yes");
                    else if (data.Declaration.CoBorrowerDeclaration.IsUSCitizen == false)
                        pdfFormFields.SetField("j borrower", "2");

                    String[] CoBorrowerIsPermanentResidentSlien = pdfFormFields.GetAppearanceStates("k coborrower");
                    if (data.Declaration.CoBorrowerDeclaration.IsPermanentResidentSlien == true)
                        pdfFormFields.SetField("k borrower", "yes");
                    else if (data.Declaration.CoBorrowerDeclaration.IsPermanentResidentSlien == false)
                        pdfFormFields.SetField("k borrower", "2");

                    String[] CoBorrowerIsIntendToOccupyThePropertyAsYourPrimary = pdfFormFields.GetAppearanceStates("l coborrower");
                    if (data.Declaration.CoBorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary == true)
                        pdfFormFields.SetField("l borrower", "2");
                    else if (data.Declaration.CoBorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary == false)
                        pdfFormFields.SetField("l borrower", "No");

                    String[] CoBorrowerIsOwnershipInterestInPropertyInTheLastThreeYears = pdfFormFields.GetAppearanceStates("m coborrower");
                    if (data.Declaration.CoBorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == true)
                        pdfFormFields.SetField("m borrower", "Yes");
                    else if (data.Declaration.CoBorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == false)
                        pdfFormFields.SetField("m borrower", "2");
                }
                if (data.EmploymentIncome.BorrowerEmploymentInfo != null)
                    for (int i = 0; i < data.EmploymentIncome.CoBorrowerEmploymentInfo.Count(); i++)
                    {


                        if (i == 0)
                        {
                            String[] CoBorrowerSelfEmployed1 = pdfFormFields.GetAppearanceStates("Co-Borrower Self Employed 1");
                            if (data.EmploymentIncome.CoBorrowerEmploymentInfo[i].IsSelfEmployed == true)
                                pdfFormFields.SetField("Co-Borrower Self Employed 1", CoBorrowerSelfEmployed1[0]);
                        }
                        else if (i == 1)
                        {
                            String[] CoBorrowerSelfEmployed1 = pdfFormFields.GetAppearanceStates("Co-Borrower Self Employed 2");
                            if (data.EmploymentIncome.CoBorrowerEmploymentInfo[i].IsSelfEmployed == true)
                                pdfFormFields.SetField("Co-Borrower Self Employed 2", CoBorrowerSelfEmployed1[0]);
                        }
                        else if (i == 2)
                        {
                            String[] CoBorrowerSelfEmployed1 = pdfFormFields.GetAppearanceStates("Co-Borrower Self Employed 3");
                            if (data.EmploymentIncome.CoBorrowerEmploymentInfo[i].IsSelfEmployed == true)
                                pdfFormFields.SetField("Co-Borrower Self Employed 2", CoBorrowerSelfEmployed1[0]);
                        }

                    }
                if (data.EmploymentIncome.BorrowerEmploymentInfo != null)
                    for (int i = 0; i < data.EmploymentIncome.BorrowerEmploymentInfo.Count(); i++)
                    {
                        if (i == 0)
                        {
                            String[] BorrowerSelfEmployed1 = pdfFormFields.GetAppearanceStates("Borrower Self Employed 1");
                            if (data.EmploymentIncome.BorrowerEmploymentInfo[i].IsSelfEmployed == true)
                                pdfFormFields.SetField("Borrower Self Employed 1", BorrowerSelfEmployed1[0]);
                        }
                        else if (i == 1)
                        {
                            String[] BorrowerSelfEmployed2 = pdfFormFields.GetAppearanceStates("Borrower Self Employed 2");
                            if (data.EmploymentIncome.BorrowerEmploymentInfo[i].IsSelfEmployed == true)
                                pdfFormFields.SetField("Borrower Self Employed 2", BorrowerSelfEmployed2[0]);
                        }
                        else if (i == 2)
                        {
                            String[] BorrowerSelfEmployed3 = pdfFormFields.GetAppearanceStates("Borrower Self Employed 3");
                            if (data.EmploymentIncome.BorrowerEmploymentInfo[i].IsSelfEmployed == true)
                                pdfFormFields.SetField("Borrower Self Employed 3", BorrowerSelfEmployed3[0]);
                        }
                    }
                //Demographic Information
                if (data.Declaration.BorrowerDemographic.Ethnicity != null)
                    foreach (var ethnic in data.Declaration.BorrowerDemographic.Ethnicity)
                        switch ((Ethnic)ethnic.Id)
                        {
                            case Ethnic.HispanicOrLatino:
                                {
                                    String[] BorrowerHispanicOrLatino = pdfFormFields.GetAppearanceStates("Ethnicity 1");
                                    pdfFormFields.SetField("Ethnicity 1", "2");
                                }

                                break;
                            case Ethnic.NotHispanicOrLatino:
                                {
                                    String[] BorrowerNotHispanicOrLatino = pdfFormFields.GetAppearanceStates("Ethnicity 1");
                                    pdfFormFields.SetField("Ethnicity 1", "Not");
                                }
                                break;
                            // case Ethnic.PuertoRican:
                            //     borrowerDemographic.IsPuertoRican = true;
                            //     break;
                            // case Ethnic.Cuban:
                            //     borrowerDemographic.IsCuban = true;
                            //     break;
                            // case Ethnic.OtherHispanicOrLatino:
                            //     borrowerDemographic.IsOtherHispanicOrLatino = true;
                            //     borrowerDemographic.Origin = ethnic.OtherValue;
                            //     break;
                            // case Ethnic.NotHispanicOrLatino:
                            //     borrowerDemographic.IsNotHispanicOrLatino = true;
                            //     break;
                            // case Ethnic.CanNotProvideEthnic:
                            //     borrowerDemographic.CanNotProvideEthnic = true;
                            //     break;
                            default:
                                break;
                        }

                foreach (var race in data.Declaration.BorrowerDemographic.Race)
                    switch ((Race)race.Id)
                    {
                        case Race.AmericanIndianOrAlaskaNative:
                            {
                                String[] BorrowerAmericanIndianOrAlaskaNative = pdfFormFields.GetAppearanceStates("race 1");
                                pdfFormFields.SetField("race 1", BorrowerAmericanIndianOrAlaskaNative[0]);
                            }

                            break;
                        case Race.Asian:
                            {
                                String[] BorrowerAsian = pdfFormFields.GetAppearanceStates("race 2");
                                pdfFormFields.SetField("race 2", BorrowerAsian[0]);
                            }
                            break;
                        case Race.BlackOrAfricanAmerican:
                            {
                                String[] BorrowerBlackOrAfricanAmerican = pdfFormFields.GetAppearanceStates("race 3");
                                pdfFormFields.SetField("race 3", BorrowerBlackOrAfricanAmerican[0]);
                            }
                            break;
                        case Race.NativeHawaiianOrOtherPacificIslander:
                            {
                                String[] BorrowerNativeHawaiianOrOtherPacificIslander = pdfFormFields.GetAppearanceStates("race 4");
                                pdfFormFields.SetField("race 4", BorrowerNativeHawaiianOrOtherPacificIslander[0]);
                            }
                            break;
                        case Race.White:
                            {
                                String[] BorrowerWhite = pdfFormFields.GetAppearanceStates("race 5");
                                pdfFormFields.SetField("race 5", BorrowerWhite[0]);
                            }
                            break;
                        // case Ethnic.NotHispanicOrLatino:
                        //     borrowerDemographic.IsNotHispanicOrLatino = true;
                        //     break;
                        // case Ethnic.CanNotProvideEthnic:
                        //     borrowerDemographic.CanNotProvideEthnic = true;
                        //     break;
                        default:
                            break;
                    }

                foreach (var sex in data.Declaration.BorrowerDemographic.Sex)
                    switch ((Sex)sex.Id)
                    {
                        case Sex.Female:
                            {
                                String[] BorrowerFemale = pdfFormFields.GetAppearanceStates("Ethnicity 1");
                                pdfFormFields.SetField("Ethnicity 1", "2");
                            }

                            break;
                        case Sex.Male:
                            {
                                String[] BorrowerMale = pdfFormFields.GetAppearanceStates(" Sex borrower");
                                pdfFormFields.SetField("Sex borrower", "1");
                            }
                            break;
                        // case Ethnic.PuertoRican:
                        //     borrowerDemographic.IsPuertoRican = true;
                        //     break;
                        // case Ethnic.Cuban:
                        //     borrowerDemographic.IsCuban = true;
                        //     break;
                        // case Ethnic.OtherHispanicOrLatino:
                        //     borrowerDemographic.IsOtherHispanicOrLatino = true;
                        //     borrowerDemographic.Origin = ethnic.OtherValue;
                        //     break;
                        // case Ethnic.NotHispanicOrLatino:
                        //     borrowerDemographic.IsNotHispanicOrLatino = true;
                        //     break;
                        // case Ethnic.CanNotProvideEthnic:
                        //     borrowerDemographic.CanNotProvideEthnic = true;
                        //     break;
                        default:
                            break;
                    }

                //Demographic Information CoBorrower
                if (data.Declaration.CoBorrowerDemographic != null && data.Declaration.CoBorrowerDemographic.Ethnicity != null)
                    foreach (var ethnic in data.Declaration.CoBorrowerDemographic.Ethnicity)
                        switch ((Ethnic)ethnic.Id)
                        {
                            case Ethnic.HispanicOrLatino:
                                {
                                    String[] CoBorrowerHispanicOrLatino = pdfFormFields.GetAppearanceStates("Ethnicity 2");
                                    pdfFormFields.SetField("Ethnicity 2", "2");
                                }

                                break;
                            case Ethnic.NotHispanicOrLatino:
                                {
                                    String[] CoBorrowerNotHispanicOrLatino = pdfFormFields.GetAppearanceStates("Ethnicity 2");
                                    pdfFormFields.SetField("Ethnicity 2", "Yes");
                                }
                                break;
                            // case Ethnic.PuertoRican:
                            //     borrowerDemographic.IsPuertoRican = true;
                            //     break;
                            // case Ethnic.Cuban:
                            //     borrowerDemographic.IsCuban = true;
                            //     break;
                            // case Ethnic.OtherHispanicOrLatino:
                            //     borrowerDemographic.IsOtherHispanicOrLatino = true;
                            //     borrowerDemographic.Origin = ethnic.OtherValue;
                            //     break;
                            // case Ethnic.NotHispanicOrLatino:
                            //     borrowerDemographic.IsNotHispanicOrLatino = true;
                            //     break;
                            // case Ethnic.CanNotProvideEthnic:
                            //     borrowerDemographic.CanNotProvideEthnic = true;
                            //     break;
                            default:
                                break;
                        }

                if (data.Declaration.CoBorrowerDemographic != null && data.Declaration.CoBorrowerDemographic.Race != null)
                    foreach (var race in data.Declaration.CoBorrowerDemographic.Race)
                        switch ((Race)race.Id)
                        {
                            case Race.AmericanIndianOrAlaskaNative:
                                {
                                    String[] CoBorrowerAmericanIndianOrAlaskaNative = pdfFormFields.GetAppearanceStates("race c1");
                                    pdfFormFields.SetField("race c1", CoBorrowerAmericanIndianOrAlaskaNative[0]);
                                }

                                break;
                            case Race.Asian:
                                {
                                    String[] CoBorrowerAsian = pdfFormFields.GetAppearanceStates("race c4");
                                    pdfFormFields.SetField("race c4", CoBorrowerAsian[0]);
                                }
                                break;
                            case Race.BlackOrAfricanAmerican:
                                {
                                    String[] CoBorrowerBlackOrAfricanAmerican = pdfFormFields.GetAppearanceStates("race c6");
                                    pdfFormFields.SetField("race c6", CoBorrowerBlackOrAfricanAmerican[0]);
                                }
                                break;
                            case Race.NativeHawaiianOrOtherPacificIslander:
                                {
                                    String[] CoBorrowerNativeHawaiianOrOtherPacificIslander = pdfFormFields.GetAppearanceStates("race c2");
                                    pdfFormFields.SetField("race c2", CoBorrowerNativeHawaiianOrOtherPacificIslander[0]);
                                }
                                break;
                            case Race.White:
                                {
                                    String[] CoBorrowerWhite = pdfFormFields.GetAppearanceStates("race c5");
                                    pdfFormFields.SetField("race c5", CoBorrowerWhite[0]);
                                }
                                break;
                            // case Ethnic.NotHispanicOrLatino:
                            //     borrowerDemographic.IsNotHispanicOrLatino = true;
                            //     break;
                            // case Ethnic.CanNotProvideEthnic:
                            //     borrowerDemographic.CanNotProvideEthnic = true;
                            //     break;
                            default:
                                break;
                        }

                if (data.Declaration.CoBorrowerDemographic != null && data.Declaration.CoBorrowerDemographic.Sex != null)
                    foreach (var sex in data.Declaration.CoBorrowerDemographic.Sex)
                        switch ((Sex)sex.Id)
                        {
                            case Sex.Female:
                                {
                                    String[] CoBorrowerFemale = pdfFormFields.GetAppearanceStates("Ethnicity 1");
                                    pdfFormFields.SetField("Ethnicity 1", "2");
                                }

                                break;
                            case Sex.Male:
                                {
                                    String[] CoBorrowerMale = pdfFormFields.GetAppearanceStates(" Sex borrower");
                                    pdfFormFields.SetField("Sex borrower", "1");
                                }
                                break;
                            // case Ethnic.PuertoRican:
                            //     borrowerDemographic.IsPuertoRican = true;
                            //     break;
                            // case Ethnic.Cuban:
                            //     borrowerDemographic.IsCuban = true;
                            //     break;
                            // case Ethnic.OtherHispanicOrLatino:
                            //     borrowerDemographic.IsOtherHispanicOrLatino = true;
                            //     borrowerDemographic.Origin = ethnic.OtherValue;
                            //     break;
                            // case Ethnic.NotHispanicOrLatino:
                            //     borrowerDemographic.IsNotHispanicOrLatino = true;
                            //     break;
                            // case Ethnic.CanNotProvideEthnic:
                            //     borrowerDemographic.CanNotProvideEthnic = true;
                            //     break;
                            default:
                                break;
                        }
                pdfFormFields.SetField("Purpose of Loan", "cnsaoicn21");
                pdfFormFields.SetField("Amount", data.LoanDetails.CurrentLoanAmount.HasValue ? data.LoanDetails.CurrentLoanAmount.Value.ToString() : "");
                pdfFormFields.SetField("Borrower Name", data.PersonalInformation.Borrower.FirstName + " " + data.PersonalInformation.Borrower.LastName);
                pdfFormFields.SetField("Borrower SSN", data.PersonalInformation.Borrower.SocialSecurityNumber);
                pdfFormFields.SetField("Borrower Home Phone", data.PersonalInformation.Borrower.HomePhone);
                pdfFormFields.SetField("Borrower DOB", data.PersonalInformation.Borrower.DateOfBirth);
                pdfFormFields.SetField("Dependents not listed by Co-Borrower no", data.PersonalInformation.Borrower.NumberOfDependents.HasValue ? data.PersonalInformation.Borrower.NumberOfDependents.Value.ToString() : "");
                pdfFormFields.SetField("Borrower Present Address", data.PersonalInformation.ResidentialAddress.AddressLine1 + " "
                  + data.PersonalInformation.ResidentialAddress.City + " "
                     + (data.PersonalInformation.ResidentialAddress.StateId.HasValue ? _personalDetailService.GetStateId(data.PersonalInformation.ResidentialAddress.StateId.Value) : "") + " "
                   + (data.PersonalInformation.ResidentialAddress.ZipCode.HasValue ? data.PersonalInformation.ResidentialAddress.ZipCode.Value.ToString() : ""));

                if (data.PersonalInformation.IsMailingAddressSameAsResidential == false && data.PersonalInformation.MailingAddress != null)
                {
                    pdfFormFields.SetField("Borrower Mailing Address if different from Present", data.PersonalInformation.MailingAddress.AddressLine1 + " "
                  + data.PersonalInformation.MailingAddress.City + " "
                     + (data.PersonalInformation.MailingAddress.StateId.HasValue ? _personalDetailService.GetStateId(data.PersonalInformation.MailingAddress.StateId.Value) : "") + " "
                   + (data.PersonalInformation.MailingAddress.ZipCode.HasValue ? data.PersonalInformation.MailingAddress.ZipCode.Value.ToString() : ""));
                }

                if (data.PersonalInformation.PreviousAddresses != null && data.PersonalInformation.PreviousAddresses.Count() != 0)
                {
                    pdfFormFields.SetField("Borrower Former Address if different from Present", data.PersonalInformation.PreviousAddresses[0].AddressLine1 + " "
                  + data.PersonalInformation.PreviousAddresses[0].City + " "
                     + (data.PersonalInformation.PreviousAddresses[0].StateId.HasValue ? _personalDetailService.GetStateId(data.PersonalInformation.PreviousAddresses[0].StateId.Value) : "") + " "
                   + (data.PersonalInformation.PreviousAddresses[0].ZipCode.HasValue ? data.PersonalInformation.PreviousAddresses[0].ZipCode.Value.ToString() : ""));

                }


                pdfFormFields.SetField("Borrower No of Years", data.PersonalInformation.ResidentialAddress.Years.HasValue ? data.PersonalInformation.ResidentialAddress.Years.Value.ToString() : "");
                pdfFormFields.SetField("Borrower No of Years Former Address", data.PersonalInformation.IsMailingAddressSameAsResidential == false ?
                    data.PersonalInformation.MailingAddress.AddressLine1 + " " +
                    data.PersonalInformation.MailingAddress.City + " " +
                    (data.PersonalInformation.MailingAddress.StateId.HasValue ? data.PersonalInformation.MailingAddress.StateId.Value.ToString() : "") + " " +
                    (data.PersonalInformation.MailingAddress.ZipCode.HasValue ? data.PersonalInformation.MailingAddress.ZipCode.Value.ToString() : "") : "");
                if (data.EmploymentIncome.BorrowerEmploymentInfo.Count() >= 1 && data.EmploymentIncome.BorrowerEmploymentInfo[0].StartDate.HasValue)
                {
                    DateTime now = DateTime.Today;
                    int Years = now.Year - data.EmploymentIncome.BorrowerEmploymentInfo[0].StartDate.Value.Year;
                    if (data.EmploymentIncome.BorrowerEmploymentInfo[0].StartDate.Value > now.AddYears(-Years)) Years--;
                    pdfFormFields.SetField("Borrower Years on the job", Years.ToString());

                }

                pdfFormFields.SetField("Borrower Name and Address of Employer", data.PersonalInformation.ResidentialAddress.AddressLine1 + " "
                    + data.PersonalInformation.ResidentialAddress.City + " "
                       + (data.PersonalInformation.ResidentialAddress.StateId.HasValue ? _personalDetailService.GetStateId(data.PersonalInformation.ResidentialAddress.StateId.Value) : "") + " "
                     + (data.PersonalInformation.ResidentialAddress.ZipCode.HasValue ? data.PersonalInformation.ResidentialAddress.ZipCode.Value.ToString() : ""));
                pdfFormFields.SetField("Borrower Business phone", data.PersonalInformation.Borrower.CellPhone);

                if (data.PersonalInformation.CoBorrower != null)
                {
                    pdfFormFields.SetField("Co-Borrower SSN", data.PersonalInformation.CoBorrower.SocialSecurityNumber);
                    pdfFormFields.SetField("Co-Borrower Name", data.PersonalInformation.CoBorrower.FirstName + " " + data.PersonalInformation.CoBorrower.LastName);
                    pdfFormFields.SetField("Co-Borrower Home Phone", data.PersonalInformation.CoBorrower.HomePhone);
                    pdfFormFields.SetField("Co-Borrower DOB", data.PersonalInformation.CoBorrower.DateOfBirth);
                    pdfFormFields.SetField("Dependents not listed by Borrower no", data.PersonalInformation.CoBorrower.NumberOfDependents.HasValue ? data.PersonalInformation.CoBorrower.NumberOfDependents.Value.ToString() : "");
                    pdfFormFields.SetField("Co-Borrower Present Address", data.PersonalInformation.CoBorrowerResidentialAddress.AddressLine1 + " "
                            + data.PersonalInformation.CoBorrowerResidentialAddress.City + " "
                               + (data.PersonalInformation.CoBorrowerResidentialAddress.StateId.HasValue ? _personalDetailService.GetStateId(data.PersonalInformation.CoBorrowerResidentialAddress.StateId.Value) : "") + " "
                            + (data.PersonalInformation.CoBorrowerResidentialAddress.ZipCode.HasValue ? data.PersonalInformation.CoBorrowerResidentialAddress.ZipCode.Value.ToString() : ""));
                    pdfFormFields.SetField("Co-Borrower No of Years", data.PersonalInformation.CoBorrowerResidentialAddress.Years.ToString());
                    if (data.PersonalInformation.MailingAddress != null)
                    {
                        pdfFormFields.SetField("Co-Borrower Mailing Address if different from Present", data.PersonalInformation.CoBorrowerMailingAddress.AddressLine1 + " "
                        + data.PersonalInformation.CoBorrowerMailingAddress.City + " "
                           + (data.PersonalInformation.CoBorrowerMailingAddress.StateId.HasValue ? _personalDetailService.GetStateId(data.PersonalInformation.CoBorrowerMailingAddress.StateId.Value) : "") + " "
                         + (data.PersonalInformation.CoBorrowerMailingAddress.ZipCode.HasValue ? data.PersonalInformation.CoBorrowerMailingAddress.ZipCode.Value.ToString() : ""));
                    }

                    if (data.PersonalInformation.CoBorrowerPreviousAddresses != null && data.PersonalInformation.CoBorrowerPreviousAddresses.Count() != 0)
                    {
                        pdfFormFields.SetField("Co-Borrower Former Address if different from Present", data.PersonalInformation.CoBorrowerPreviousAddresses[0].AddressLine1 + " "
                        + data.PersonalInformation.CoBorrowerPreviousAddresses[0].City + " "
                           + (data.PersonalInformation.CoBorrowerPreviousAddresses[0].StateId.HasValue ? _personalDetailService.GetStateId(data.PersonalInformation.CoBorrowerPreviousAddresses[0].StateId.Value) : "") + " "
                         + (data.PersonalInformation.CoBorrowerPreviousAddresses[0].ZipCode.HasValue ? data.PersonalInformation.CoBorrowerPreviousAddresses[0].ZipCode.Value.ToString() : ""));
                    }
                }
                if (data.EmploymentIncome.CoBorrowerEmploymentInfo.Count() >= 1 && data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StartDate.HasValue)
                {
                    DateTime now = DateTime.Today;
                    int Years = now.Year - data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StartDate.Value.Year;
                    if (data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StartDate.Value > now.AddYears(-Years)) Years--;
                    pdfFormFields.SetField("Co-Borrower Years on the job", Years.ToString());

                    pdfFormFields.SetField("Co-Borrower Name and Address of Employer", data.EmploymentIncome.CoBorrowerEmploymentInfo[0].EmployerName + " " +
                         data.EmploymentIncome.CoBorrowerEmploymentInfo[0].Address1 + " " +
                        data.EmploymentIncome.CoBorrowerEmploymentInfo[0].City + " "
                            + (data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StateId.HasValue ? _personalDetailService.GetStateId(data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StateId.Value) : "") + " "
                          + (data.EmploymentIncome.CoBorrowerEmploymentInfo[0].ZipCode.HasValue ? data.EmploymentIncome.CoBorrowerEmploymentInfo[0].ZipCode.Value.ToString() : "")
                          );
                }
                if (data.EmploymentIncome.BorrowerEmploymentInfo.Count >= 2)
                {
                    pdfFormFields.SetField("Borrower Employment info Cont Dates of Employ", data.EmploymentIncome.BorrowerEmploymentInfo[1].Position);
                    pdfFormFields.SetField("Borrower Employment info Cont Dates of Employ", data.EmploymentIncome.BorrowerEmploymentInfo[1].StartDate.Value.ToString() + " " +
                      data.EmploymentIncome.BorrowerEmploymentInfo[1].EndDate.Value.ToString()
                      );
                    pdfFormFields.SetField("Borrower Employment info Cont Name and adress of Employ", data.EmploymentIncome.BorrowerEmploymentInfo[1].EmployerName + " " +
                            data.EmploymentIncome.BorrowerEmploymentInfo[1].Address1 + " "
                            + data.EmploymentIncome.BorrowerEmploymentInfo[1].City + " "
                           + (data.EmploymentIncome.BorrowerEmploymentInfo[1].StateId.HasValue ? _personalDetailService.GetStateId(data.EmploymentIncome.BorrowerEmploymentInfo[1].StateId.Value) : "") + " "
                            + (data.EmploymentIncome.BorrowerEmploymentInfo[1].ZipCode.HasValue ? data.EmploymentIncome.BorrowerEmploymentInfo[1].ZipCode.Value.ToString() : "")
                            );
                }

                if (data.EmploymentIncome.BorrowerEmploymentInfo.Count >= 3)
                {
                    pdfFormFields.SetField("Borrower Employment info Cont position title2", data.EmploymentIncome.BorrowerEmploymentInfo[2].Position
                       );
                    pdfFormFields.SetField("Borrower Employment info Cont Dates of Employ 2", data.EmploymentIncome.BorrowerEmploymentInfo[2].StartDate.Value.ToString() + " " +
                            data.EmploymentIncome.BorrowerEmploymentInfo[2].EndDate.Value.ToString()
                            );
                    pdfFormFields.SetField("Borrower Employment info Cont Name and adress of Employ 2", data.EmploymentIncome.BorrowerEmploymentInfo[2].EmployerName + " " +
                   data.EmploymentIncome.BorrowerEmploymentInfo[2].Address1 + " "
                   + data.EmploymentIncome.BorrowerEmploymentInfo[2].City + " "
                  + (data.EmploymentIncome.BorrowerEmploymentInfo[2].StateId.HasValue ? _personalDetailService.GetStateId(data.EmploymentIncome.BorrowerEmploymentInfo[2].StateId.Value) : "") + " "
                   + (data.EmploymentIncome.BorrowerEmploymentInfo[2].ZipCode.HasValue ? data.EmploymentIncome.BorrowerEmploymentInfo[2].ZipCode.Value.ToString() : "")
                   );

                }
                pdfFormFields.SetField("Monthly income Borrower Bonuses a1", data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.Value.ToString() : "");
                pdfFormFields.SetField("Monthly income Borrower Base a", data.EmploymentIncome.BorrowerMonthlyIncome.Base.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Base.Value.ToString() : "");
                pdfFormFields.SetField("Monthly income Borrower Commissions a5", data.EmploymentIncome.BorrowerMonthlyIncome.Commissions.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Commissions.Value.ToString() : "");
                pdfFormFields.SetField("Monthly income Borrower Dividends a10", data.EmploymentIncome.BorrowerMonthlyIncome.Dividends.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Dividends.Value.ToString() : "");
                pdfFormFields.SetField("Monthly income Borrower Overtime 1", data.EmploymentIncome.BorrowerMonthlyIncome.Overtime.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Overtime.Value.ToString() : "");
                pdfFormFields.SetField("Monthly income Borrower Total a29", (
                    (data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.Value : 0) +
                    (data.EmploymentIncome.BorrowerMonthlyIncome.Base.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Base.Value : 0) +
                    (data.EmploymentIncome.BorrowerMonthlyIncome.Commissions.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Commissions.Value : 0) +
                    (data.EmploymentIncome.BorrowerMonthlyIncome.Dividends.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Dividends.Value : 0) +
                    (data.EmploymentIncome.BorrowerMonthlyIncome.Overtime.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Overtime.Value : 0)).ToString()
                    );

                if (data.EmploymentIncome.CoBorrowerMonthlyIncome != null)
                {
                    pdfFormFields.SetField("Monthly income Co-Borrower Bonuses a2", data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Bonuses.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Bonuses.Value.ToString() : "");
                    pdfFormFields.SetField("Monthly income Co-Borrower Base c", data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Base.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Base.Value.ToString() : "");
                    pdfFormFields.SetField("Monthly income Co-Borrower Commissions a6", data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Commissions.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Commissions.Value.ToString() : "");
                    pdfFormFields.SetField("Monthly income Co-Borrower Dividends/Interest a11", data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Dividends.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Dividends.Value.ToString() : "");
                    pdfFormFields.SetField("Monthly income Co-Borrower Overtime 2", data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Overtime.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Overtime.Value.ToString() : "");
                    pdfFormFields.SetField("Monthly income Co-Borrower Total a30", (
                            (data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Bonuses.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Bonuses.Value : 0) +
                            (data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Base.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Base.Value : 0) +
                            (data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Commissions.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Commissions.Value : 0) +
                            (data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Dividends.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Dividends.Value : 0) +
                            (data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Overtime.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Overtime.Value : 0)).ToString());
                }
               


                if (data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).Count() >= 2)
                {
                    pdfFormFields.SetField("Assets Name and Adress of Bank, S&L, Or Credit Union 4",
                     data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[1].Address + " " +
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[1].City + " " +
                    _personalDetailService.GetStateId(data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[1].StateId)
                    );

                    pdfFormFields.SetField("Assets Acct no 4",
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[1].AccountNumber
                    );

                    pdfFormFields.SetField("Assets Acct no 4 Balance 5",
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[1].CashValue.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[0].CashValue.Value.ToString() : ""
                    );
                }

                if (data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).Count() >= 1)
                {

                    pdfFormFields.SetField("Assets Name and Adress of Bank, S&L, Or Credit Union 3", data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[1].Address + " " +
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[1].City + " " +
                    _personalDetailService.GetStateId(data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[1].StateId)
                    );

                    pdfFormFields.SetField("Assets Acct no 3",
                                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[1].AccountNumber
                                        );

                    pdfFormFields.SetField("Assets Acct no 3 Balance 4",
                                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[1].CashValue.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[0].CashValue.Value.ToString() : ""
                    );
                }

                if (data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).Count() >= 2)
                {
                    pdfFormFields.SetField("Assets Name and Adress of Bank, S&L, Or Credit Union 2", data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[1].Address + " " +
                       data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[1].City + " " +
                       _personalDetailService.GetStateId(data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[1].StateId)
                       );

                    pdfFormFields.SetField("Assets Acct no 2",
                                       data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[1].AccountNumber
                                       );

                    pdfFormFields.SetField("Assets Acct no 1 Balance b",
                                       data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[1].CashValue.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[0].CashValue.Value.ToString() : ""
                                       );
                }

                if (data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).Count() >= 1)
                {
                    pdfFormFields.SetField("Assets Name and Adress of Bank, S&L, Or Credit Union",
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[0].Address + " " +
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[0].City + " " +
                    _personalDetailService.GetStateId(data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[0].StateId)
                    );

                    pdfFormFields.SetField("Assets Acct no 1",
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[0].AccountNumber
                                   );

                    pdfFormFields.SetField("Assets Acct no 1 Balance a",
                       data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[0].CashValue.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[0].CashValue.Value.ToString() : ""
                                       );
                }

                if (data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).Count() >= 3)
                {
                    pdfFormFields.SetField("Owned Real Estate Address 3a",
                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].Address + " " +
                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].City + " " +
                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].StateId
                        );

                    pdfFormFields.SetField("Type of Propertya",
                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].PresentMarketValue.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].PresentMarketValue.Value.ToString() : ""
                                   );

                    pdfFormFields.SetField("Owned Real Estate Address 3 Market Value",
                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].PresentMarketValue.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].PresentMarketValue.Value.ToString() : ""
                                  );

                    pdfFormFields.SetField("Owned Real Estate Address 3 Amount of Mortgages Liens",
                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].OutstandingMortgageBalance.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].OutstandingMortgageBalance.Value.ToString() : ""
                                   );

                    pdfFormFields.SetField("Owned Real Estate Address 3 Gross Rental Income",
                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].GrossRentalIncome.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].GrossRentalIncome.Value.ToString() : ""
                                  );

                    pdfFormFields.SetField("Owned Real Estate Address 3 Mortage Payments",
                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].MonthlyMortgagePayment.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].MonthlyMortgagePayment.Value.ToString() : ""
                                   );

                    pdfFormFields.SetField("Owned Real Estate Address 3 Insurance Maintenance Taxes",
                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].TaxesInsuranceAndOther.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].TaxesInsuranceAndOther.Value.ToString() : ""
                                   );
                    //PdfTextField GrossRentalIncome1 = (PdfTextField)(form.Fields["Owned Real Estate Address 1 Net Rental Income a"]);
                    //GrossRentalIncome1.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0]..ToString());
                }

                if (data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).Count() >= 2)
                {
                    pdfFormFields.SetField("Owned Real Estate Address 1a",
                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[1].Address + " " +
                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[1].City + " " +
                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[1].StateId
                        );

                    pdfFormFields.SetField("Type of Property 2",
                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[1].PropertyType);

                    pdfFormFields.SetField("Type of Propertya",
                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[1].PropertyType);

                    pdfFormFields.SetField("Owned Real Estate Address 2  Market Value",
                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[1].PresentMarketValue.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[1].PresentMarketValue.Value.ToString() : "");

                    pdfFormFields.SetField("Owned Real Estate Address 2  Amount of Mortgages Liens",
                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[1].OutstandingMortgageBalance.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[1].OutstandingMortgageBalance.Value.ToString() : "");

                    pdfFormFields.SetField("Owned Real Estate Address 2 Gross Rental Income",
                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].GrossRentalIncome.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].GrossRentalIncome.Value.ToString() : "");

                    pdfFormFields.SetField("Owned Real Estate Address 2 Mortage Payments",
                       data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].MonthlyMortgagePayment.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].MonthlyMortgagePayment.Value.ToString() : "");

                    pdfFormFields.SetField("Owned Real Estate Address 2 Insurance Maintenance Taxes",
                       data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].TaxesInsuranceAndOther.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].TaxesInsuranceAndOther.Value.ToString() : "");

                    //PdfTextField GrossRentalIncome1 = (PdfTextField)(form.Fields["Owned Real Estate Address 1 Net Rental Income a"]);
                    //GrossRentalIncome1.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0]..ToString());
                }
                pdfStamper.Close();
            }
        }


    }
}
