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
            else
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

                String[] CoBorrowerJudgementsAgainst = pdfFormFields.GetAppearanceStates("Co-Borrower Judgements against");
                if (data.Declaration.CoBorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == true)
                    pdfFormFields.SetField("Co-Borrower Judgements against", "2");
                else if (data.Declaration.CoBorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == false)
                    pdfFormFields.SetField("Co-Borrower Judgements against", "5");

                String[] BorrowerIsDeclaredBankrupt = pdfFormFields.GetAppearanceStates("Borrower Bankrupt");
                if (data.Declaration.BorrowerDeclaration.IsDeclaredBankrupt == true)
                    pdfFormFields.SetField("Borrower Bankrupt", "2");
                else if (data.Declaration.BorrowerDeclaration.IsDeclaredBankrupt == false)
                    pdfFormFields.SetField("Borrower Bankrupt", "5");

                String[] CoBorrowerIsDeclaredBankrupt = pdfFormFields.GetAppearanceStates("Co-Borrower Bankrupt y");
                if (data.Declaration.CoBorrowerDeclaration.IsDeclaredBankrupt == true)
                    pdfFormFields.SetField("Co-Borrower Bankrupt y", "2");
                else if (data.Declaration.CoBorrowerDeclaration.IsDeclaredBankrupt == false)
                    pdfFormFields.SetField("Co-Borrower Bankrupt y", "5");

                String[] BorrowerLawsuit = pdfFormFields.GetAppearanceStates("Borrower Lawsuit");
                if (data.Declaration.BorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == true)
                    pdfFormFields.SetField("Borrower Lawsuit", "Two");
                else if (data.Declaration.BorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == false)
                    pdfFormFields.SetField("Borrower Lawsuit", "Five");

                String[] CoBorrowerLawsuit = pdfFormFields.GetAppearanceStates("Co-Borrower Lawsuit y");
                if (data.Declaration.CoBorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == true)
                    pdfFormFields.SetField("Co-Borrower Lawsuit y", "2");
                else if (data.Declaration.CoBorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == false)
                    pdfFormFields.SetField("Co-Borrower Lawsuit y", "5");


                String[] BorrowerForclose = pdfFormFields.GetAppearanceStates("Check Box");
                if (data.Declaration.BorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle == true)
                    pdfFormFields.SetField("Check Box", "2");
                else if (data.Declaration.CoBorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle == false)
                    pdfFormFields.SetField("Check Box", "5");

                String[] CoBorrowerForclose = pdfFormFields.GetAppearanceStates("Co-Borrower Forclose y");
                if (data.Declaration.BorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle == true)
                    pdfFormFields.SetField("Co-Borrower Forclose y", "2");
                else if (data.Declaration.CoBorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle == false)
                    pdfFormFields.SetField("Co-Borrower Forclose y", "5");

                String[] BorrowerLiability = pdfFormFields.GetAppearanceStates("Borrower Liability");
                if (data.Declaration.BorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure == true)
                    pdfFormFields.SetField("Borrower Liability", "2");
                else if (data.Declaration.BorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure == false)
                    pdfFormFields.SetField("Borrower Liability", "5");

                String[] CoBorrowerLiability = pdfFormFields.GetAppearanceStates("Co-Borrower Liability y");
                if (data.Declaration.CoBorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure == true)
                    pdfFormFields.SetField("Co-Borrower Liability y", "2");
                else if (data.Declaration.CoBorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure == false)
                    pdfFormFields.SetField("Co-Borrower Liability y", "5");

                String[] BorrowerIsAnyPartOfTheDownPayment = pdfFormFields.GetAppearanceStates("h borrower");
                if (data.Declaration.BorrowerDeclaration.IsAnyPartOfTheDownPayment == true)
                    pdfFormFields.SetField("h borrower", "2");
                else if (data.Declaration.BorrowerDeclaration.IsAnyPartOfTheDownPayment == true)
                    pdfFormFields.SetField("h borrower", "1");

                String[] CoBorrowerIsAnyPartOfTheDownPayment = pdfFormFields.GetAppearanceStates("h coborrower");
                if (data.Declaration.CoBorrowerDeclaration.IsAnyPartOfTheDownPayment == true)
                    pdfFormFields.SetField("h coborrower", "Yes");
                else if (data.Declaration.CoBorrowerDeclaration.IsAnyPartOfTheDownPayment == true)
                    pdfFormFields.SetField("h coborrower", "2");

                String[] BorrowerIsCoMakerOrEndorser = pdfFormFields.GetAppearanceStates("i borrower");
                if (data.Declaration.BorrowerDeclaration.IsCoMakerOrEndorser == true)
                    pdfFormFields.SetField("i borrower", "Yes");
                else if (data.Declaration.BorrowerDeclaration.IsCoMakerOrEndorser == true)
                    pdfFormFields.SetField("i borrower", "2");

                String[] CoBorrowerIsCoMakerOrEndorser = pdfFormFields.GetAppearanceStates("i coborrower");
                if (data.Declaration.CoBorrowerDeclaration.IsCoMakerOrEndorser == true)
                    pdfFormFields.SetField("i coborrower", "Yes");
                else if (data.Declaration.CoBorrowerDeclaration.IsCoMakerOrEndorser == true)
                    pdfFormFields.SetField("i coborrower", "2");

                String[] BorrowerisPresentlyDelinquent = pdfFormFields.GetAppearanceStates("f borrower");
                if (data.Declaration.BorrowerDeclaration.IsPresentlyDelinquent == true)
                    pdfFormFields.SetField("f borrower", "1");
                else if (data.Declaration.BorrowerDeclaration.IsPresentlyDelinquent == true)
                    pdfFormFields.SetField("f borrower", "No");

                String[] CoBorrowerisPresentlyDelinquent = pdfFormFields.GetAppearanceStates("f coborrower");
                if (data.Declaration.CoBorrowerDeclaration.IsPresentlyDelinquent == true)
                    pdfFormFields.SetField("f coborrower", "1");
                else if (data.Declaration.CoBorrowerDeclaration.IsPresentlyDelinquent == true)
                    pdfFormFields.SetField("f coborrower", "No");

                String[] BorrowerIsObligatedToPayAlimonyChildSupport = pdfFormFields.GetAppearanceStates("g borrower");
                if (data.Declaration.BorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == true)
                    pdfFormFields.SetField("g borrower", "1");
                else if (data.Declaration.BorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == false)
                    pdfFormFields.SetField("g borrower", "No");

                String[] CoBorrowerIsObligatedToPayAlimonyChildSupport = pdfFormFields.GetAppearanceStates("g coborrower");
                if (data.Declaration.CoBorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == true)
                    pdfFormFields.SetField("g coborrower", "1");
                else if (data.Declaration.CoBorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == false)
                    pdfFormFields.SetField("g coborrower", "No");

                String[] BorrowerIsUSCitizen = pdfFormFields.GetAppearanceStates("j borrower");
                if (data.Declaration.BorrowerDeclaration.IsUSCitizen == true)
                    pdfFormFields.SetField("j borrower", "2");
                else if (data.Declaration.BorrowerDeclaration.IsUSCitizen == false)
                    pdfFormFields.SetField("j borrower", "1");

                String[] CoBorrowerIsUSCitizen = pdfFormFields.GetAppearanceStates("j coborrower");
                if (data.Declaration.CoBorrowerDeclaration.IsUSCitizen == true)
                    pdfFormFields.SetField("j borrower", "yes");
                else if (data.Declaration.CoBorrowerDeclaration.IsUSCitizen == false)
                    pdfFormFields.SetField("j borrower", "2");

                String[] BorrowerIsPermanentResidentSlien = pdfFormFields.GetAppearanceStates("k borrower");
                if (data.Declaration.BorrowerDeclaration.IsPermanentResidentSlien == true)
                    pdfFormFields.SetField("k borrower", "Yes");
                else if (data.Declaration.BorrowerDeclaration.IsPermanentResidentSlien == false)
                    pdfFormFields.SetField("k borrower", "2");

                String[] CoBorrowerIsPermanentResidentSlien = pdfFormFields.GetAppearanceStates("k coborrower");
                if (data.Declaration.CoBorrowerDeclaration.IsPermanentResidentSlien == true)
                    pdfFormFields.SetField("k borrower", "yes");
                else if (data.Declaration.CoBorrowerDeclaration.IsPermanentResidentSlien == false)
                    pdfFormFields.SetField("k borrower", "2");

                String[] BorrowerIsIntendToOccupyThePropertyAsYourPrimary = pdfFormFields.GetAppearanceStates("l borrower");
                if (data.Declaration.BorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary == true)
                    pdfFormFields.SetField("l borrower", "yes");
                else if (data.Declaration.BorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary == false)
                    pdfFormFields.SetField("l borrower", "no");

                String[] CoBorrowerIsIntendToOccupyThePropertyAsYourPrimary = pdfFormFields.GetAppearanceStates("l coborrower");
                if (data.Declaration.CoBorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary == true)
                    pdfFormFields.SetField("l borrower", "2");
                else if (data.Declaration.CoBorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary == false)
                    pdfFormFields.SetField("l borrower", "No");

                String[] BorrowerIsOwnershipInterestInPropertyInTheLastThreeYears = pdfFormFields.GetAppearanceStates("m borrower");
                if (data.Declaration.BorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == true)
                    pdfFormFields.SetField("m borrower", "yes");
                else if (data.Declaration.BorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == false)
                    pdfFormFields.SetField("m borrower", "No");

                String[] CoBorrowerIsOwnershipInterestInPropertyInTheLastThreeYears = pdfFormFields.GetAppearanceStates("m coborrower");
                if (data.Declaration.CoBorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == true)
                    pdfFormFields.SetField("m borrower", "Yes");
                else if (data.Declaration.CoBorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == false)
                    pdfFormFields.SetField("m borrower", "2");

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
                pdfFormFields.SetField("Purpose of Loan", data.LoanDetails.PurposeOfLoan.HasValue ? data.LoanDetails.PurposeOfLoan.Value.ToString() : "");
                pdfFormFields.SetField("Amount", data.LoanDetails.CurrentLoanAmount.HasValue ? data.LoanDetails.CurrentLoanAmount.Value.ToString() : "");
                pdfFormFields.SetField("Purpose of Loan", data.LoanDetails.PurposeOfLoan.HasValue ? data.LoanDetails.PurposeOfLoan.Value.ToString() : "");

                pdfStamper.Close();
            }
        }


    }
}
