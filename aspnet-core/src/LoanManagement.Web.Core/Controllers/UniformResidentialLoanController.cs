using Abp.Runtime.Validation;
using LoanManagement.CredcoServices;
using LoanManagement.Data;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Enums;
using LoanManagement.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Pdf = iTextSharp.text.pdf;

namespace LoanManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UniformResidentialLoanController : LoanManagementControllerBase
    {
        private readonly ILoanAppService _loanAppService;
        private readonly ICredcoApi _credcoApi;
        public IWebHostEnvironment _hostingEnvironment;
        private readonly SmtpClient _smtpClient;
        public UniformResidentialLoanController(
            SmtpClient smtpClient,
            ILoanAppService loanAppService,
            ICredcoApi credcoApi,
            IWebHostEnvironment hostingEnvironment
        )
        {
            _smtpClient = smtpClient;
            _loanAppService = loanAppService;
            _credcoApi = credcoApi;
            _hostingEnvironment = hostingEnvironment;
        }


        [DisableValidation]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LoanApplicationDto input)
        {
            try
            {
                if (input == null || !ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!input.Id.HasValue || input.Id.Value == default)
                {
                    input = await _loanAppService.CreateAsync(input);
                }

                await _loanAppService.UpdateAsync(input);

                return Json(input);
            }catch(Exception ex)
            {
                return Json(ex.Message);
            }
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

        public async Task<IActionResult> CreatePdfNew([FromQuery] long Id)
        {
            var mailMessage = new MailMessage();
            mailMessage.To.Add(new MailAddress("wmartin@ezonlinemortgage.com"));
            mailMessage.To.Add(new MailAddress("shabir.abdulmajeed786@gmail.com"));
            mailMessage.From = new MailAddress("loanapplicationmail@gmail.com");
            mailMessage.Subject = "Home Buying Funnel Form New Lead";
            var data = await _loanAppService.GetAsync(new Abp.Application.Services.Dto.EntityDto<long?>(Id));
            string pdfTemplate = @"Borrower_v28.pdf";
            var pdfReader = new Pdf.PdfReader(pdfTemplate);
            var (fileName, path) = CreateFileName(Id);
          // MemoryStream memoryStream = new MemoryStream();
            var fileStream = new FileStream(path, FileMode.Create);
            var pdfStamper = new Pdf.PdfStamper(pdfReader, fileStream);
            decimal assetsTotalCash = 0;

            try
            {
                var pdfFormFields = pdfStamper.AcroFields;
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Name[0]", $"{StringExtensions.FirstCharToUpper(data.PersonalInformation.Borrower.FirstName)}, {StringExtensions.FirstCharToUpper(data.PersonalInformation.Borrower.MiddleInitial)}, {StringExtensions.FirstCharToUpper(data.PersonalInformation.Borrower.LastName)}, {StringExtensions.FirstCharToUpper(data.PersonalInformation.Borrower.Suffix)}");
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Security_1[0]", data.PersonalInformation.Borrower.SocialSecurityNumber.Substring(0, 3));
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Security_2[0]", data.PersonalInformation.Borrower.SocialSecurityNumber.Substring(3, 2));
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Security_3[0]", data.PersonalInformation.Borrower.SocialSecurityNumber.Substring(5, 4));
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Alt_Name[0]", $"{StringExtensions.FirstCharToUpper(data.PersonalInformation.Borrower.FirstName)}, {StringExtensions.FirstCharToUpper(data.PersonalInformation.Borrower.MiddleInitial)}, {StringExtensions.FirstCharToUpper(data.PersonalInformation.Borrower.LastName)}, {StringExtensions.FirstCharToUpper(data.PersonalInformation.Borrower.Suffix)}");
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Birth_1[0]", data.PersonalInformation.Borrower.DateOfBirth.Substring(5, 2));
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Birth_2[0]", data.PersonalInformation.Borrower.DateOfBirth.Substring(8, 2));
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Birth_3[0]", data.PersonalInformation.Borrower.DateOfBirth.Substring(0, 4));
                pdfFormFields.SetField("topmostSubform[0].Page1[0].credit[0].individual[0]._1a_Individual[0]", (data.PersonalInformation.IsApplyingWithCoBorrower != null && data.PersonalInformation.IsApplyingWithCoBorrower == true) ? "1" : "0");

                if((data.PersonalInformation.IsApplyingWithCoBorrower != null && data.PersonalInformation.IsApplyingWithCoBorrower == true))
                {
                    pdfFormFields.SetField("topmostSubform[0].Page1[0].credit[0].joint[0]._1a_Joint[0]", "1");
                } else {
                    pdfFormFields.SetField("topmostSubform[0].Page1[0].credit[0].individual[0]._1a_Individual[0]", "1");
                }
                pdfFormFields.SetField("topmostSubform[0].Page1[0].credit[0].joint[0]._1a_Borrowers_Number[0]", "1");
                if (data.Declaration.BorrowerDeclaration.IsUSCitizen == true)
                {
                    pdfFormFields.SetField("topmostSubform[0].Page1[0].citizenship[0].citizen[0]._1a_US_Citizen[0]", "1");
                }
                if(data.Declaration.BorrowerDeclaration.IsPermanentResidentSlien == true)
                {
                   pdfFormFields.SetField("topmostSubform[0].Page1[0].citizenship[0].permanent[0]._1a_Permanent_Resident_Alien[0]", "1");
                }else
                {
                    pdfFormFields.SetField("topmostSubform[0].Page1[0].citizenship[0].non_permanent[0]._1a_Non_Permanent_Resident_Alien[0]", "1");
                }

               //  pdfFormFields.SetField("topmostSubform[0].Page1[0].credit[0].joint[0]._1a_Borrowers_Number[0]", data);

                pdfFormFields.SetField("topmostSubform[0].Page1[0].credit[0].joint[0]._1a_Initials[0]", data.PersonalInformation.Borrower.FirstName ?? " ");

                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Borrower_s_Name[0]", $"{data.PersonalInformation.CoBorrower.FirstName ?? ""}, {data.PersonalInformation.CoBorrower.MiddleInitial ?? ""}, {data.PersonalInformation.CoBorrower.LastName ?? ""}, {data.PersonalInformation.CoBorrower.Suffix ?? ""}");

                var MaritalStatusId = "";
                if (data.PersonalInformation.Borrower.MaritalStatusId.HasValue)
                {
                    MaritalStatusId = data.PersonalInformation.Borrower.MaritalStatusId.Value.ToString();
                }

                if (MaritalStatusId == "1")
                {
                    pdfFormFields.SetField("topmostSubform[0].Page1[0].marital-status[0].married[0]._1a_Married[0]", "1");
                }
                else if (MaritalStatusId == "2")
                {
                    pdfFormFields.SetField("topmostSubform[0].Page1[0].marital-status[0].unmarried[0]._1a_Unmarried[0]", "1");
                }
                else if (MaritalStatusId == "3")
                {
                    pdfFormFields.SetField("topmostSubform[0].Page1[0].marital-status[0].separated[0]._1a_Separated[0]", "1");
                }


                  pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Dependents[0]", data.PersonalInformation.Borrower.NumberOfDependents.HasValue ? data.PersonalInformation.Borrower.NumberOfDependents.Value.ToString() : "");
                 // pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Dependent_Age[0]",data.PersonalInformation.Borrower);

                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_PhoneH1[0]", data.PersonalInformation.Borrower.HomePhone.Substring(0, 3));
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_PhoneH2[0]", data.PersonalInformation.Borrower.HomePhone.Substring(3, 3));
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_PhoneH3[0]", data.PersonalInformation.Borrower.HomePhone.Substring(6, 3));

                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_PhoneC1[0]", data.PersonalInformation.Borrower.CellPhone.Substring(0, 3));
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_PhoneC2[0]", data.PersonalInformation.Borrower.CellPhone.Substring(3, 3));
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_PhoneC3[0]", data.PersonalInformation.Borrower.CellPhone.Substring(6, 4));

                // pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_PhoneW1[0]", data.PersonalInformation.Borrower);

                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Email[0]", data.PersonalInformation.Borrower.Email);
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Address_City[0]", data.PersonalInformation.ResidentialAddress.City);
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Address_State[0]", StateData.GetStateById(data.LoanDetails.StateId.Value));
                // pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Country[0]", data.PersonalInformation.ResidentialAddress.);
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Address_Zip[0]", data.PersonalInformation.ResidentialAddress.ZipCode.ToString() ?? "");
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Address_St[0]", data.PersonalInformation.ResidentialAddress.AddressLine1);
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Address_Years[0]", data.PersonalInformation.ResidentialAddress.Years.ToString() ?? "");
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Address_Months[0]", data.PersonalInformation.ResidentialAddress.Months.ToString() ?? "");
                if (data.Expenses.IsLiveWithFamilySelectRent == true)
                {
                  //  pdfFormFields.SetField("topmostSubform[0].Page1[0].housing_current[0].rent[0]._1a_Current_Rent[0]", "False");
                }
                else
                {
                    pdfFormFields.SetField("topmostSubform[0].Page1[0].housing_current[0].own[0]._1a_Current_Own[0]", "True");
                }
              //  pdfFormFields.SetField("topmostSubform[0].Page1[0].housing_current[0].rent[0]._1a_Current_Rent[0]", data.Expenses.Rent.ToString() ?? "");
                pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Address_St[0]", data.PersonalInformation.ResidentialAddress.AddressLine1);
                // pdfFormFields.SetField("topmostSubform[0].Page1[0].housing_current[0].no_primary[0]._1a_Current_NoPrimary[0]",data.Expenses.);


                if (data.PersonalInformation.PreviousAddresses.Count > 0)
                {
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Former_Address_City[0]", data.PersonalInformation.PreviousAddresses[0].City);
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_FormerAddress_St[0]", data.PersonalInformation.PreviousAddresses[0].AddressLine1);
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Former_Address_State[0]", StateData.GetStateById(data.PersonalInformation.PreviousAddresses[0].StateId ?? 1));
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Former_Address_Zip[0]", data.PersonalInformation.PreviousAddresses[0].ZipCode.ToString() ?? "");
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Former_Address_Years[0]", data.PersonalInformation.PreviousAddresses[0].Years.ToString() ?? "");
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Former_Address_Months[0]", data.PersonalInformation.PreviousAddresses[0].Months.ToString() ?? "");
                }
                else
                {
                    var FormerAddress = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page1[0]._1a_Does_Not_Apply1[0]");
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Does_Not_Apply1[0]", FormerAddress[0]);
                }


                if ((data.PersonalInformation.IsMailingAddressSameAsResidential != null && data.PersonalInformation.IsMailingAddressSameAsResidential == false))
                {
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Mail_Address_City[0]", data.PersonalInformation.MailingAddress.City);
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Mail_Address_State[0]", StateData.GetStateById(data.PersonalInformation.MailingAddress.StateId ?? 1));
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Mail_Address_Zip[0]", data.PersonalInformation.MailingAddress.ZipCode.ToString() ?? "");
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Mail_Address_St[0]", data.PersonalInformation.MailingAddress.AddressLine1);
                }
                else
                {
                    var MailAddress = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page1[0]._1a_Does_Not_Apply2[0]");
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Does_Not_Apply2[0]", MailAddress[0]);
                }


                if (data.EmploymentIncome.BorrowerEmploymentInfo.Count > 0)
                {
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Employer[0]", data.EmploymentIncome.BorrowerEmploymentInfo[0].EmployerName);

                    //  pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_PhoneE1[0]", data.EmploymentIncome.BorrowerEmploymentInfo[0].HomePhone.Substring(0, 3));
                    //  pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_PhoneE2[0]", data.EmploymentIncome.BorrowerEmploymentInfo[0].HomePhone.Substring(3, 3));
                    //  pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_PhoneE3[0]", data.EmploymentIncome.BorrowerEmploymentInfo[0].HomePhone.Substring(6, 3));

                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_City[0]", data.EmploymentIncome.BorrowerEmploymentInfo[0].City);
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_State[0]", StateData.GetStateById(data.EmploymentIncome.BorrowerEmploymentInfo[0].StateId ?? 1));
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Zip[0]", data.EmploymentIncome.BorrowerEmploymentInfo[0].ZipCode.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Address[0]", data.EmploymentIncome.BorrowerEmploymentInfo[0].Address1);
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Position[0]", data.EmploymentIncome.BorrowerEmploymentInfo[0].Position);
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Employment_Start_Day[0]", data.EmploymentIncome.BorrowerEmploymentInfo[0].StartDate.ToString().Substring(8, 2));
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Employment_Start_Month[0]", data.EmploymentIncome.BorrowerEmploymentInfo[0].StartDate.ToString().Substring(5, 2));
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Employment_Start_Year[0]", data.EmploymentIncome.BorrowerEmploymentInfo[0].StartDate.ToString().Substring(0, 4));
                    var DateDiff = (Convert.ToDateTime(data.EmploymentIncome.BorrowerEmploymentInfo[0].StartDate) - Convert.ToDateTime(data.EmploymentIncome.BorrowerEmploymentInfo[0].EndDate));
                    DateTime zeroTime = new DateTime(1, 1, 1);
                    int years = (zeroTime + DateDiff).Year - 1;
                    int Months = (zeroTime + DateDiff).Month - 1;
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Employment_Years[0]", years.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Employment_Months[0]", Months.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Monthly_Income_Loss[0]", data.EmploymentIncome.BorrowerMonthlyIncome.Base.ToString() ?? "");
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Base[0]", data.EmploymentIncome.BorrowerMonthlyIncome.Base.ToString() ?? "");
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Bonus[0]", data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.ToString() ?? "");
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Overtime[0]", data.EmploymentIncome.BorrowerMonthlyIncome.Overtime.ToString() ?? "");
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Commission[0]", data.EmploymentIncome.BorrowerMonthlyIncome.Commissions.ToString() ?? "");
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Other[0]", data.EmploymentIncome.BorrowerMonthlyIncome.Dividends.ToString() ?? "");
                    var IncomeTotal = data.EmploymentIncome.BorrowerMonthlyIncome.Base + data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses + data.EmploymentIncome.BorrowerMonthlyIncome.Overtime + data.EmploymentIncome.BorrowerMonthlyIncome.Commissions + data.EmploymentIncome.BorrowerMonthlyIncome.Dividends;
                    pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_IncomeTotal[0]", IncomeTotal.ToString());
                    if (data.EmploymentIncome.BorrowerEmploymentInfo[0].IsSelfEmployed.HasValue && data.EmploymentIncome.BorrowerEmploymentInfo[0].IsSelfEmployed == true)
                    {
                        var SelfEmployeed = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page1[0]._1b_Owner[0]");
                        pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Owner[0]", SelfEmployeed[0]);
                    }
                }

                // Page 2 started from here ..
                // Page 2 C section
                if (data.EmploymentIncome.BorrowerEmploymentInfo.Count > 1)
                {
                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Employer[0]", data.EmploymentIncome.BorrowerEmploymentInfo[1].EmployerName);

                    //  pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_PhoneE1[0]", data.EmploymentIncome.BorrowerEmploymentInfo[0].HomePhone.Substring(0, 3));
                    //  pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_PhoneE2[0]", data.EmploymentIncome.BorrowerEmploymentInfo[0].HomePhone.Substring(3, 3));
                    //  pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_PhoneE3[0]", data.EmploymentIncome.BorrowerEmploymentInfo[0].HomePhone.Substring(6, 3));

                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_City[0]", data.EmploymentIncome.BorrowerEmploymentInfo[1].City);
                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_State[0]", StateData.GetStateById(data.EmploymentIncome.BorrowerEmploymentInfo[1].StateId ?? 1));
                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Zip[0]", data.EmploymentIncome.BorrowerEmploymentInfo[1].ZipCode.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Address[0]", data.EmploymentIncome.BorrowerEmploymentInfo[1].Address1);
                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Position[0]", data.EmploymentIncome.BorrowerEmploymentInfo[1].Position);
                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Employment_Start_Day[0]", data.EmploymentIncome.BorrowerEmploymentInfo[1].StartDate.ToString().Substring(8, 2));
                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Employment_Start_Month[0]", data.EmploymentIncome.BorrowerEmploymentInfo[1].StartDate.ToString().Substring(5, 2));
                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Employment_Start_Year[0]", data.EmploymentIncome.BorrowerEmploymentInfo[1].StartDate.ToString().Substring(0, 4));
                    var DateDiff = (Convert.ToDateTime(data.EmploymentIncome.BorrowerEmploymentInfo[1].EndDate) - Convert.ToDateTime(data.EmploymentIncome.BorrowerEmploymentInfo[1].StartDate));
                   
                    DateTime zeroTime2 = new DateTime(1, 1, 1);
                    int years = (zeroTime2 + DateDiff).Year - 1;
                    int Months = (zeroTime2 + DateDiff).Month - 1;
                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Employment_Years[0]", years.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Employment_Months[0]", Months.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Monthly_Income_Loss[0]", data.EmploymentIncome.BorrowerMonthlyIncome.Base.ToString() ?? "");
                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Base[0]", data.EmploymentIncome.BorrowerMonthlyIncome.Base.ToString() ?? "");
                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Bonus[0]", data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.ToString() ?? "");
                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Overtime[0]", data.EmploymentIncome.BorrowerMonthlyIncome.Overtime.ToString() ?? "");
                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Commission[0]", data.EmploymentIncome.BorrowerMonthlyIncome.Commissions.ToString() ?? "");
                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Other[0]", data.EmploymentIncome.BorrowerMonthlyIncome.Dividends.ToString() ?? "");
                    var IncomeTotal = data.EmploymentIncome.BorrowerMonthlyIncome.Base + data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses + data.EmploymentIncome.BorrowerMonthlyIncome.Overtime + data.EmploymentIncome.BorrowerMonthlyIncome.Commissions + data.EmploymentIncome.BorrowerMonthlyIncome.Dividends;
                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_IncomeTotal[0]", IncomeTotal.ToString());
                    if (data.EmploymentIncome.BorrowerEmploymentInfo[1].IsSelfEmployed.HasValue && data.EmploymentIncome.BorrowerEmploymentInfo[1].IsSelfEmployed == true)
                    {
                        var SelfEmployeed = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page2[0]._1c_Owner[0]");
                        pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Owner[0]", SelfEmployeed[0]);
                    }
                }

                // Page 2 End C Section

                if (data.EmploymentIncome.CoBorrowerEmploymentInfo.Count > 0)
                {
                    //pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_Address[0]", data.EmploymentIncome.CoBorrowerEmploymentInfo[0].Address1);
                    //pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_City[0]", data.EmploymentIncome.CoBorrowerEmploymentInfo[0].City);
                    //  pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_Country[0]", data.EmploymentIncome.CoBorrowerEmploymentInfo[0].City);

                    //if (data.EmploymentIncome.CoBorrowerEmploymentInfo[0].EndDate != null)
                    //{
                    //    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_Employent_End_Year[0]", data.EmploymentIncome.CoBorrowerEmploymentInfo[0].EndDate.ToString().Substring(0, 4));
                    //    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_Employment_End_Day[0]", data.EmploymentIncome.CoBorrowerEmploymentInfo[0].EndDate.ToString().Substring(8, 2));
                    //    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_Employment_End_Month[0]", data.EmploymentIncome.CoBorrowerEmploymentInfo[0].EndDate.ToString().Substring(5, 2));
                    //}

                    //pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_Employer[0]", data.EmploymentIncome.CoBorrowerEmploymentInfo[0].EmployerName);
                    //if (data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StartDate != null)
                    //{
                    //    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_Employment_Start_Day[0]", data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StartDate.ToString().Substring(8, 2));
                    //    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_Employment_Start_Month[0]", data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StartDate.ToString().Substring(5, 2));
                    //    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_Employment_Start_Year[0]", data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StartDate.ToString().Substring(0, 4));
                    //}

                    //var grossIncome = data.EmploymentIncome.CoBorrowerMonthlyIncome.Base + data.EmploymentIncome.CoBorrowerMonthlyIncome.Bonuses + data.EmploymentIncome.CoBorrowerMonthlyIncome.Overtime + data.EmploymentIncome.CoBorrowerMonthlyIncome.Commissions + data.EmploymentIncome.CoBorrowerMonthlyIncome.Dividends;
                    //pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_Gross_Monthly_Income[0]", grossIncome.ToString() ?? "");
                    //if (data.EmploymentIncome.CoBorrowerEmploymentInfo[0].IsSelfEmployed.HasValue && data.EmploymentIncome.CoBorrowerEmploymentInfo[0].IsSelfEmployed == true)
                    //{
                    //    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_Owner[0]", "1");
                    //}

                    //if (data.EmploymentIncome.CoBorrowerEmploymentInfo[0].Position != null)
                    //{
                    //    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_Position[0]", data.EmploymentIncome.CoBorrowerEmploymentInfo[0].Position.ToString());
                    //}

                    pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_State[0]", StateData.GetStateById(data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StateId ?? 0));
                    //  pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_Unit[0]", data.EmploymentIncome.CoBorrowerEmploymentInfo[0]);
                    
                   // pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_Zip[0]", data.EmploymentIncome.CoBorrowerEmploymentInfo[0].ZipCode.ToString());
                }
                else
                {
                  //  var DoesNotApply = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page2[0]._1d_Does_Not_Apply[0]");
                 //   pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_Does_Not_Apply[0]", DoesNotApply[0]);
                }


                if (data.EmploymentIncome.AdditionalIncomes.Count > 0)
                {
                    //decimal TotalOtherMonthlyIncome = 0;
                    //pdfFormFields.SetField("topmostSubform[0].Page2[0].Table1[0].T1R1[0]._1e_Income_Other_Sources1[0]", IncomeSourceData.GetIncomeSourceById(data.EmploymentIncome.AdditionalIncomes[0].IncomeSourceId??0));
                    //pdfFormFields.SetField("topmostSubform[0].Page2[0].Table1[0].T1R1[0]._1e_Other_Monthly_Income1[0]", data.EmploymentIncome.AdditionalIncomes[0].Amount.ToString());
                    //TotalOtherMonthlyIncome = TotalOtherMonthlyIncome + data.EmploymentIncome.AdditionalIncomes[0].Amount ?? 0;
                    //if (data.EmploymentIncome.AdditionalIncomes.Count > 1)
                    //{
                    //    pdfFormFields.SetField("topmostSubform[0].Page2[0].Table1[0].T1R2[0]._1e_Income_Other_Sources2[0]", IncomeSourceData.GetIncomeSourceById(data.EmploymentIncome.AdditionalIncomes[1].IncomeSourceId??0));
                    //    pdfFormFields.SetField("topmostSubform[0].Page2[0].Table1[0].T1R2[0]._1e_Other_Monthly_Income2[0]", data.EmploymentIncome.AdditionalIncomes[1].Amount.ToString());
                    //    TotalOtherMonthlyIncome = TotalOtherMonthlyIncome + data.EmploymentIncome.AdditionalIncomes[1].Amount ?? 0;

                    //}
                    //if (data.EmploymentIncome.AdditionalIncomes.Count > 2)
                    //{
                    //    pdfFormFields.SetField("topmostSubform[0].Page2[0].Table1[0].T1R3[0]._1e_Income_Other_Sources3[0]", IncomeSourceData.GetIncomeSourceById(data.EmploymentIncome.AdditionalIncomes[2].IncomeSourceId??0));
                    //    pdfFormFields.SetField("topmostSubform[0].Page2[0].Table1[0].T1R3[0]._1e_Other_Monthly_Income3[0]", data.EmploymentIncome.AdditionalIncomes[0].Amount.ToString());
                    //    TotalOtherMonthlyIncome = TotalOtherMonthlyIncome + data.EmploymentIncome.AdditionalIncomes[2].Amount ?? 0;
                    //}
                //    pdfFormFields.SetField("topmostSubform[0].Page2[0].Table1[0].T1R4[0]._1e_Total_Other_Monthly_Income[0]", TotalOtherMonthlyIncome.ToString());
                }
                else
                {
    //                var DoesNotApply = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page2[0]._1d_Does_Not_Apply[0]");
    
    //                pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_Does_Not_Apply[0]", DoesNotApply[0]);
                }


                // Page 3 is started from here...
                decimal totalCash = 0;
                if (data.ManualAssetEntries != null)
                {
                    if (data.ManualAssetEntries.Count > 0)
                    {
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR1[0]._2a_Account1[0]", data.ManualAssetEntries[0].AccountNumber.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR1[0]._2a_Account_Type1[0]", data.ManualAssetEntries[0].AssetTypeId.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR1[0]._2a_Cash1[0]", data.ManualAssetEntries[0].CashValue.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR1[0]._2a_Financial1[0]", data.ManualAssetEntries[0].BankName.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2b[0].TR1[0]._2b_Asset_Type1[0]", data.ManualAssetEntries[0].AssetTypeId.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2b[0].TR1[0]._2b_Cash1[0]", data.ManualAssetEntries[0].CashValue.ToString());
                        totalCash = totalCash + data.ManualAssetEntries[0].CashValue ?? 0;
                        assetsTotalCash = assetsTotalCash + data.ManualAssetEntries[0].CashValue ?? 0;
                    }

                    if (data.ManualAssetEntries.Count > 1)
                    {
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR2[0]._2a_Account2[0]", data.ManualAssetEntries[1].AccountNumber.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR2[0]._2a_Account_Type2[0]", data.ManualAssetEntries[1].AssetTypeId.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR2[0]._2a_Cash2[0]", data.ManualAssetEntries[1].CashValue.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR2[0]._2a_Financial2[0]", data.ManualAssetEntries[1].BankName.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2b[0].TR2[0]._2b_Asset_Type2[0]", data.ManualAssetEntries[1].AssetTypeId.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2b[0].TR2[0]._2b_Cash2[0]", data.ManualAssetEntries[1].CashValue.ToString());
                        totalCash = totalCash + data.ManualAssetEntries[1].CashValue ?? 0;
                        assetsTotalCash = assetsTotalCash + data.ManualAssetEntries[1].CashValue ?? 0;
                    }
                    if (data.ManualAssetEntries.Count > 2)
                    {
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR3[0]._2a_Account3[0]", data.ManualAssetEntries[2].AccountNumber.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR3[0]._2a_Account_Type3[0]", data.ManualAssetEntries[2].AssetTypeId.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR3[0]._2a_Cash3[0]", data.ManualAssetEntries[2].CashValue.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR3[0]._2a_Financial3[0]", data.ManualAssetEntries[2].BankName.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2b[0].TR3[0]._2b_Asset_Type3[0]", data.ManualAssetEntries[2].AssetTypeId.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2b[0].TR3[0]._2b_Cash3[0]", data.ManualAssetEntries[2].CashValue.ToString());
                        totalCash = totalCash + data.ManualAssetEntries[2].CashValue ?? 0;
                        assetsTotalCash = assetsTotalCash + data.ManualAssetEntries[2].CashValue ?? 0;

                    }

                    if (data.ManualAssetEntries.Count > 3)
                    {
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR4[0]._2a_Account4[0]", data.ManualAssetEntries[3].AccountNumber.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR4[0]._2a_Account_Type4[0]", data.ManualAssetEntries[3].AssetTypeId.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR4[0]._2a_Cash4[0]", data.ManualAssetEntries[3].CashValue.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR4[0]._2a_Financial4[0]", data.ManualAssetEntries[3].BankName.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2b[0].TR4[0]._2b_Asset_Type4[0]", data.ManualAssetEntries[3].AssetTypeId.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2b[0].TR4[0]._2b_Cash4[0]", data.ManualAssetEntries[3].CashValue.ToString());
                        totalCash = totalCash + data.ManualAssetEntries[3].CashValue ?? 0;
                        assetsTotalCash = assetsTotalCash + data.ManualAssetEntries[3].CashValue ?? 0;
                    }

                    if (data.ManualAssetEntries.Count > 4)
                    {
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR5[0]._2a_Account5[0]", data.ManualAssetEntries[4].AccountNumber.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR5[0]._2a_Account_Type5[0]", data.ManualAssetEntries[4].AssetTypeId.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR5[0]._2a_Cash5[0]", data.ManualAssetEntries[4].CashValue.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR5[0]._2a_Financial5[0]", data.ManualAssetEntries[4].BankName.ToString());
                        totalCash = totalCash + data.ManualAssetEntries[4].CashValue ?? 0;
                    }


                    pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR6[0]._2a_Total_Cash[0]", totalCash.ToString());

                    pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2b[0].TR5[0]._2b_TotalCash[0]", assetsTotalCash.ToString());
                    if (data.ManualAssetEntries[0].StockAndBonds != null)
                    {
                        if (data.ManualAssetEntries[0].StockAndBonds.Count > 0)
                        {
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR1[0]._2c_Account1[0]", data.ManualAssetEntries[0].StockAndBonds[0].AccountNumber);
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR1[0]._2c_Account_Type1[0]", data.ManualAssetEntries[0].AssetTypeId.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR1[0]._2c_Company1[0]", data.ManualAssetEntries[0].StockAndBonds[0].CompanyName.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR1[0]._2c_Monthly1[0]", data.ManualAssetEntries[0].StockAndBonds[0].Value.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR1[0]._2c_Paid_Off1[0]", data.ManualAssetEntries[0].StockAndBonds[0].Value.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR1[0]._2c_Unpaid1[0]", data.ManualAssetEntries[0].StockAndBonds[0].Value.ToString());
                        }
                        if (data.ManualAssetEntries[0].StockAndBonds.Count > 1)
                        {

                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR2[0]._2c_Account2[0]", data.ManualAssetEntries[0].StockAndBonds[1].AccountNumber);
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR2[0]._2c_Account_Type2[0]", data.ManualAssetEntries[0].AssetTypeId.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR2[0]._2c_Company2[0]", data.ManualAssetEntries[0].StockAndBonds[1].CompanyName.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR2[0]._2c_Monthly2[0]", data.ManualAssetEntries[0].StockAndBonds[1].Value.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR2[0]._2c_Paid_Off2[0]", data.ManualAssetEntries[0].StockAndBonds[1].Value.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR2[0]._2c_Unpaid2[0]", data.ManualAssetEntries[0].StockAndBonds[1].Value.ToString());
                        }
                        if (data.ManualAssetEntries[0].StockAndBonds.Count > 2)
                        {

                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR3[0]._2c_Account3[0]", data.ManualAssetEntries[0].StockAndBonds[2].AccountNumber);
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR3[0]._2c_Account_Type3[0]", data.ManualAssetEntries[0].AssetTypeId.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR3[0]._2c_Company3[0]", data.ManualAssetEntries[0].StockAndBonds[2].CompanyName.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR3[0]._2c_Monthly3[0]", data.ManualAssetEntries[0].StockAndBonds[2].Value.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR3[0]._2c_Paid_Off3[0]", data.ManualAssetEntries[0].StockAndBonds[2].Value.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR3[0]._2c_Unpaid3[0]", data.ManualAssetEntries[0].StockAndBonds[2].Value.ToString());
                        }
                        if (data.ManualAssetEntries[0].StockAndBonds.Count > 3)
                        {
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR4[0]._2c_Account4[0]", data.ManualAssetEntries[0].StockAndBonds[3].AccountNumber);
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR4[0]._2c_Account_Type4[0]", data.ManualAssetEntries[0].AssetTypeId.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR4[0]._2c_Company4[0]", data.ManualAssetEntries[0].StockAndBonds[3].CompanyName.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR4[0]._2c_Monthly4[0]", data.ManualAssetEntries[0].StockAndBonds[3].Value.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR4[0]._2c_Paid_Off4[0]", data.ManualAssetEntries[0].StockAndBonds[3].Value.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR4[0]._2c_Unpaid4[0]", data.ManualAssetEntries[0].StockAndBonds[3].Value.ToString());
                        }
                        if (data.ManualAssetEntries[0].StockAndBonds.Count > 4)
                        {

                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR5[0]._2c_Account5[0]", data.ManualAssetEntries[0].StockAndBonds[4].AccountNumber);
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR5[0]._2c_Account_Type5[0]", data.ManualAssetEntries[0].AssetTypeId.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR5[0]._2c_Company5[0]", data.ManualAssetEntries[0].StockAndBonds[4].CompanyName.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR5[0]._2c_Monthly5[0]", data.ManualAssetEntries[0].StockAndBonds[4].Value.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR5[0]._2c_Paid_Off5[0]", data.ManualAssetEntries[0].StockAndBonds[4].Value.ToString());
                            pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR5[0]._2c_Unpaid5[0]", data.ManualAssetEntries[0].StockAndBonds[4].Value.ToString());
                        }
                    }
                    else
                    {
                        pdfFormFields.SetField("topmostSubform[0].Page3[0]._2b_Does_Not_Apply[0]", "1");
                    }
                    //  pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2d[0].TR1[0]._2d_Liability_Type1[0]", data.ManualAssetEntries[0]);
                    //  pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2d[0].TR1[0]._2d_Monthly1[0]", );
                    //  pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2d[0].TR2[0]._2d_Liability_Type2[0]", );
                    // pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2d[0].TR2[0]._2d_Monthly2[0]", );
                    // pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2d[0].TR3[0]._2d_Liability_Type3[0]", );
                    //  pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2d[0].TR3[0]._2d_Monthly3[0]", );

                    //pdfFormFields.SetField("topmostSubform[0].Page3[0]._2c_Does_Not_Apply[0]", );
                }
                else
                {
                    pdfFormFields.SetField("topmostSubform[0].Page3[0]._2d_Does_Not_Apply[0]", "1");
                }

                // Page 3 ended here ..

                // Page 4 start from here ..
                if (data.ManualAssetEntries != null && data.ManualAssetEntries.Count != 0)
                {
                    if (data.ManualAssetEntries.Count > 0)
                    {
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3a_Account1[0]", data.ManualAssetEntries[0].AccountNumber);
                        // pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3a_Credit1[0]", data.ManualAssetEntries[0]);
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3a_Creditor1[0]", data.ManualAssetEntries[0].Name);
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3a_Monthly_Mortgage1[0]", (data.ManualAssetEntries[0].MonthlyMortgagePayment ?? 0).ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3a_Paid_Off1[0]", (data.ManualAssetEntries[0].OutstandingMortgageBalance ?? 0).ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3a_Type1[0]", data.ManualAssetEntries[0].PropertyType);
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3a_Unpaid1[0]", (data.ManualAssetEntries[0].OutstandingMortgageBalance ?? 0).ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3a_Account2[0]", data.ManualAssetEntries[0].AccountNumber);
                        // pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3a_Credit2[0]", );
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3a_Creditor2[0]", data.ManualAssetEntries[0].Name);
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3a_Monthly_Mortgage2[0]", data.ManualAssetEntries[0].MonthlyMortgagePayment.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3a_Paid_Off2[0]", data.ManualAssetEntries[0].OutstandingMortgageBalance.ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3a_Type2[0]", data.ManualAssetEntries[0].PropertyType);
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3a_Unpaid2[0]", data.ManualAssetEntries[0].OutstandingMortgageBalance.ToString());
                    }

                    if (data.ManualAssetEntries.Count > 1)
                    {
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3b[0].TR1[0]._3b_Account1[0]", data.ManualAssetEntries[1].AccountNumber);
                        //  pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3b[0].TR1[0]._3b_Credit1[0]", );
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3b[0].TR1[0]._3b_Creditor1[0]", data.ManualAssetEntries[1].Name);
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3b[0].TR1[0]._3b_Monthly_Mortgage1[0]", (data.ManualAssetEntries[1].MonthlyMortgagePayment ?? 0).ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3b[0].TR1[0]._3b_Paid_Off1[0]", (data.ManualAssetEntries[1].OutstandingMortgageBalance ?? 0).ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3b[0].TR1[0]._3b_Type1[0]", data.ManualAssetEntries[1].PropertyType);
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3b[0].TR1[0]._3b_Unpaid1[0]", (data.ManualAssetEntries[1].OutstandingMortgageBalance ?? 0).ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3b[0].TR2[0]._3b_Account2[0]", data.ManualAssetEntries[1].AccountNumber);
                        //  pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3b[0].TR2[0]._3b_Credit2[0]", );
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3b[0].TR2[0]._3b_Creditor2[0]", data.ManualAssetEntries[1].Name);
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3b[0].TR2[0]._3b_Monthly_Mortgage2[0]", (data.ManualAssetEntries[1].MonthlyMortgagePayment ?? 0).ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3b[0].TR2[0]._3b_Paid_Off2[0]", (data.ManualAssetEntries[1].OutstandingMortgageBalance ?? 0).ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3b[0].TR2[0]._3b_Type2[0]", data.ManualAssetEntries[1].PropertyType);
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3b[0].TR2[0]._3b_Unpaid2[0]", (data.ManualAssetEntries[1].OutstandingMortgageBalance ?? 0).ToString());
                    }
                    if (data.ManualAssetEntries.Count > 2)
                    {
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3c[0].TR1[0]._3c_Account1[0]", data.ManualAssetEntries[2].AccountNumber);
                        // pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3c[0].TR1[0]._3c_Credit1[0]", data.ManualAssetEntries[3].AccountNumber);
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3c[0].TR1[0]._3c_Creditor1[0]", data.ManualAssetEntries[2].Name);
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3c[0].TR1[0]._3c_Monthly_Mortgage1[0]", (data.ManualAssetEntries[2].MonthlyMortgagePayment ?? 0).ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3c[0].TR1[0]._3c_Paid_Off1[0]", (data.ManualAssetEntries[2].OutstandingMortgageBalance ?? 0).ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3c[0].TR1[0]._3c_Type1[0]", data.ManualAssetEntries[2].PropertyType);
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3c[0].TR1[0]._3c_Unpaid1[0]", (data.ManualAssetEntries[2].OutstandingMortgageBalance ?? 0).ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3c[0].TR2[0]._3c_Account2[0]", data.ManualAssetEntries[2].AccountNumber);
                        //  pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3c[0].TR2[0]._3c_Credit2[0]", );
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3c[0].TR2[0]._3c_Creditor2[0]", data.ManualAssetEntries[2].Name);
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3c[0].TR2[0]._3c_Monthly_Mortgage2[0]", (data.ManualAssetEntries[2].MonthlyMortgagePayment ?? 0).ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3c[0].TR2[0]._3c_Paid_Off2[0]", (data.ManualAssetEntries[2].OutstandingMortgageBalance ?? 0).ToString());
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3c[0].TR2[0]._3c_Type2[0]", data.ManualAssetEntries[2].PropertyType);
                        pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3c[0].TR2[0]._3c_Unpaid2[0]", (data.ManualAssetEntries[2].OutstandingMortgageBalance ?? 0).ToString());
                    }
                }
                else
                {
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3_Do_Not_Own[0]", "1");
                }

                if (data.ManualAssetEntries != null && data.ManualAssetEntries.Count > 0 && !String.IsNullOrEmpty(data.ManualAssetEntries[0].City) && !String.IsNullOrEmpty(data.ManualAssetEntries[0].Address) && !String.IsNullOrEmpty(data.ManualAssetEntries[0].ZipCode))
                {
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Address_City[0]", data.ManualAssetEntries[0].City.ToString());
                    //  pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Address_Country[0]", data.ManualAssetEntries[0].Country.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Address_St[0]", data.ManualAssetEntries[0].Address.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Address_State[0]", data.ManualAssetEntries[0].StateId.ToString());
                    //  pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Address_Unit[0]", data.ManualAssetEntries[0]);
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Address_Zip[0]", data.ManualAssetEntries[0].ZipCode.ToString());
                    //  pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Intended_Occupancy[0]", data.ManualAssetEntries[0].ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Monthly_Expenses[0]", data.Expenses.OtherHousingExpenses.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Monthly_Rent[0]", data.ManualAssetEntries[0].GrossRentalIncome.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Net_Monthly[0]", data.EmploymentIncome.BorrowerMonthlyIncome.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Status[0]", data.ManualAssetEntries[0].PropertyStatus.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Value[0]", data.ManualAssetEntries[0].PresentMarketValue.ToString());
                }
                else
                {
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Mortgage_Does_Not_Apply[0]", "1");
                }

                if (data.ManualAssetEntries != null && data.ManualAssetEntries.Count > 1 && !String.IsNullOrEmpty(data.ManualAssetEntries[1].PropertyStatus) && data.ManualAssetEntries[1].PresentMarketValue != null)
                {
                
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Address_City[0]", data.ManualAssetEntries[1].City.ToString());
                    // pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Address_Country[0]", );
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Address_St[0]", data.ManualAssetEntries[1].Address.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Address_State[0]", data.ManualAssetEntries[1].StateId.ToString());
                    // pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Address_Unit[0]", );
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Address_Zip[0]", data.ManualAssetEntries[1].ZipCode.ToString());
                    // pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Intended_Occupancy[0]", );
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Monthly_Expenses[0]", data.Expenses.OtherHousingExpenses.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Monthly_Rent[0]", data.ManualAssetEntries[1].GrossRentalIncome.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Net_Monthly[0]", data.EmploymentIncome.BorrowerMonthlyIncome.ToString());
                    //  pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_No_Additional[0]", );
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Status[0]", data.ManualAssetEntries[1].PropertyStatus.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Value[0]", data.ManualAssetEntries[1].PresentMarketValue.ToString());
                }
                else
                {
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Mortgage_Does_Not_Apply[0]", "0");
                }


               if(data.ManualAssetEntries != null && data.ManualAssetEntries.Count > 2 && !String.IsNullOrEmpty(data.ManualAssetEntries[2].City) && !String.IsNullOrEmpty(data.ManualAssetEntries[2].Address.ToString()))
                {
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Address_City[0]", data.ManualAssetEntries[2].City.ToString());
               //   pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Address_Country[0]", data.ManualAssetEntries[2].ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Address_St[0]", data.ManualAssetEntries[2].Address.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Address_State[0]", data.ManualAssetEntries[2].StateId.ToString());
               //   pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Address_Unit[0]", data.ManualAssetEntries[2].ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Address_Zip[0]", data.ManualAssetEntries[2].ZipCode.ToString());
               //   pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Intended_Occupancy[0]", );
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Monthly_Expenses[0]", data.Expenses.OtherHousingExpenses.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Monthly_Rent[0]", data.ManualAssetEntries[2].GrossRentalIncome.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Mortgage_Does_Not_Apply[0]", "1");
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Net_Monthly[0]", data.EmploymentIncome.BorrowerMonthlyIncome.ToString());
               //  pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_No_Additional[0]", );
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Status[0]", data.ManualAssetEntries[2].PropertyStatus.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Value[0]", data.ManualAssetEntries[2].PresentMarketValue.ToString());
                }

                // Page 4 ended here ..

                // Page 5 starts here ..
                if (data.LoanDetails != null)
                {
                    //pdfFormFields.SetField("topmostSubform[0].Page5[0].L_4a1[0].no[0]._4a_mixed_no[0]", );
                    //pdfFormFields.SetField("topmostSubform[0].Page5[0].L_4a1[0].yes[0]._4a_mixed_yes[0]", );
                    //pdfFormFields.SetField("topmostSubform[0].Page5[0].L_4a2[0].no[0]._4a_manu_no[0]", );
                    //pdfFormFields.SetField("topmostSubform[0].Page5[0].L_4a2[0].yes[0]._4a_manu_yes[0]", );
                    pdfFormFields.SetField("topmostSubform[0].Page5[0]._4a_Address_City[0]", data.LoanDetails.City.ToString());
                    //    pdfFormFields.SetField("topmostSubform[0].Page5[0]._4a_Address_St[0]", data.LoanDetails..ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page5[0]._4a_Address_State[0]", data.LoanDetails.StateId.ToString());
                    //  pdfFormFields.SetField("topmostSubform[0].Page5[0]._4a_Address_Unit[0]", data.LoanDetails);
                    //   pdfFormFields.SetField("topmostSubform[0].Page5[0]._4a_Address_Zip[0]", data.LoanDetails.);
                    pdfFormFields.SetField("topmostSubform[0].Page5[0]._4a_FHA[0]", "1");
                    pdfFormFields.SetField("topmostSubform[0].Page5[0]._4a_Loan_Amount[0]", data.LoanDetails.CurrentLoanAmount.ToString());
                    //  pdfFormFields.SetField("topmostSubform[0].Page5[0]._4a_Property_County[0]", data.LoanDetails);
                    //   pdfFormFields.SetField("topmostSubform[0].Page5[0]._4a_Units[0]", data.LoanDetails);
                    pdfFormFields.SetField("topmostSubform[0].Page5[0]._4a_Value[0]", data.LoanDetails.EstimatedValue.ToString());
                 }

                if(data.LoanDetails.RequestedLoanAmount != null && data.LoanDetails.SecondMortgageAmount != null)
                {
                    //pdfFormFields.SetField("topmostSubform[0].Page5[0]._4b_Table[0].TR1[0]._4a_LR1[0].first[0]._4a_L1FL[0]", );
                    //pdfFormFields.SetField("topmostSubform[0].Page5[0]._4b_Table[0].TR1[0]._4a_LR1[0].subordinate[0]._4a_L1SL[0]", );
                    pdfFormFields.SetField("topmostSubform[0].Page5[0]._4b_Table[0].TR1[0]._4b_Amount1[0]", data.LoanDetails.RequestedLoanAmount.ToString());
                    //   pdfFormFields.SetField("topmostSubform[0].Page5[0]._4b_Table[0].TR1[0]._4b_Credit1[0]", );
                    //  pdfFormFields.SetField("topmostSubform[0].Page5[0]._4b_Table[0].TR1[0]._4b_Creditor1[0]", data.LoanDetails);
                    pdfFormFields.SetField("topmostSubform[0].Page5[0]._4b_Table[0].TR1[0]._4b_Monthly1[0]", data.LoanDetails.SecondMortgageAmount.ToString());
                    //pdfFormFields.SetField("topmostSubform[0].Page5[0]._4b_Table[0].TR2[0]._4a_LR2[0].first[0]._4a_L2FL[0]", );
                    //pdfFormFields.SetField("topmostSubform[0].Page5[0]._4b_Table[0].TR2[0]._4a_LR2[0].subordinate[0]._4a_L2SL[0]", );
                    pdfFormFields.SetField("topmostSubform[0].Page5[0]._4b_Table[0].TR2[0]._4b_Amount2[0]", data.LoanDetails.SecondMortgageAmount.ToString());
                    // pdfFormFields.SetField("topmostSubform[0].Page5[0]._4b_Table[0].TR2[0]._4b_Credit2[0]", );
                    //   pdfFormFields.SetField("topmostSubform[0].Page5[0]._4b_Table[0].TR2[0]._4b_Creditor2[0]", );
                    //   pdfFormFields.SetField("topmostSubform[0].Page5[0]._4b_Table[0].TR2[0]._4b_Monthly2[0]", data.LoanDetails);
                } else {
                    pdfFormFields.SetField("topmostSubform[0].Page5[0]._4b_Does_Not_Apply[0]", "1");
                }



                if (false) { 
                    //    pdfFormFields.SetField("topmostSubform[0].Page5[0]._4c_Table[0].TR1[0]._4c_Amount1[0]", );
                    //    pdfFormFields.SetField("topmostSubform[0].Page5[0]._4c_Table[0].TR2[0]._4c_Amount2[0]", );
                }
                else
                {
                    pdfFormFields.SetField("topmostSubform[0].Page5[0]._4c_Does_Not_Apply[0]", "1");
                }

                if (data.LoanDetails != null && data.LoanDetails.GiftAmount != 0 && !String.IsNullOrEmpty(data.LoanDetails.GiftExplanation))
                {
                    //   pdfFormFields.SetField("topmostSubform[0].Page5[0]._4d_Table[0].TR1[0]._4dL1[0].deposited[0]._4d_r1Deposited[0]",);
                    //  pdfFormFields.SetField("topmostSubform[0].Page5[0]._4d_Table[0].TR1[0]._4dL1[0].not[0]._4d_r1Not[0]",  );
                    //   pdfFormFields.SetField("topmostSubform[0].Page5[0]._4d_Table[0].TR1[0]._4d_Asset_Type1[0]", );
                    pdfFormFields.SetField("topmostSubform[0].Page5[0]._4d_Table[0].TR1[0]._4d_Cash1[0]", data.LoanDetails.GiftAmount.ToString());
                    pdfFormFields.SetField("topmostSubform[0].Page5[0]._4d_Table[0].TR1[0]._4d_Source1[0]", data.LoanDetails.GiftExplanation.ToString());
                    // pdfFormFields.SetField("topmostSubform[0].Page5[0]._4d_Table[0].TR2[0]._4dL2[0].deposited[0]._4d_r2Deposited[0]", );
                    //  pdfFormFields.SetField("topmostSubform[0].Page5[0]._4d_Table[0].TR2[0]._4dL2[0].not[0]._4d_r2Not[0]", );
                    //pdfFormFields.SetField("topmostSubform[0].Page5[0]._4d_Table[0].TR2[0]._4d_Asset_Type2[0]", );
                    //pdfFormFields.SetField("topmostSubform[0].Page5[0]._4d_Table[0].TR2[0]._4d_Cash2[0]", );
                    //pdfFormFields.SetField("topmostSubform[0].Page5[0]._4d_Table[0].TR2[0]._4d_Source2[0]", );
                }
                else
                {
                    pdfFormFields.SetField("topmostSubform[0].Page5[0]._4d_Does_Not_Apply[0]", "1");
                }

                if (data.LoanDetails.PurposeOfLoan == 1)
                {
                    pdfFormFields.SetField("topmostSubform[0].Page5[0].loan_purpose[0].purchase[0]._4a_Purchase[0]", "1");
                } else if(data.LoanDetails.PurposeOfLoan == 2) {
                    pdfFormFields.SetField("topmostSubform[0].Page5[0].loan_purpose[0].other[0]._4a_Purpose_other_spec[0]", "1");
                } else if(data.LoanDetails.PurposeOfLoan == 3)
                {
                    pdfFormFields.SetField("topmostSubform[0].Page5[0].loan_purpose[0].refinance[0]._4a_Refinance[0]", "1");
                }

            //    pdfFormFields.SetField("topmostSubform[0].Page5[0].loan_purpose[0].other[0]._4a_Other[0]", );
                

                if(data.LoanDetails.PropertyUseId == 1)
                {
                    pdfFormFields.SetField("topmostSubform[0].Page5[0].occupancy[0].primary[0]._4a_Primary[0]", "1");
                }
                else if(data.LoanDetails.PropertyUseId == 2)
                {
                    pdfFormFields.SetField("topmostSubform[0].Page5[0].occupancy[0].secondary[0]._4a_SecondHome[0]", "1");
                }
                else if(data.LoanDetails.PropertyUseId == 3)
                {
                    pdfFormFields.SetField("topmostSubform[0].Page5[0].occupancy[0].invest[0]._4a_Investment[0]", "1");
                }
    
                
               
                // Page 5 ended here ..

                // Page 6 starts here ..
                //if(data.Declaration.BorrowerDeclaration.)
                //pdfFormFields.SetField("topmostSubform[0].Page6[0].L5a3[0]._5a31[0]._5a_About_A3[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page6[0].L5a3[0]._5a32[0]._5a_About_A4[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aA_another[0].no[0]._5aA_another_no[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aA_another[0].yes[0]._5aA_another_yes[0]", );
                if (!data.Declaration.BorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary ?? false) {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aA_primary[0].no[0]._5aA_primary_no[0]", "1");
                }
                else
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aA_primary[0].yes[0]._5aA_primary_yes[0]", "1");
                }

                if(data.Declaration.BorrowerDeclaration.IsOwnershipInterestInPropertyInTheLastThreeYears == true)
                {
                   pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aI[0].yes[0]._5bI_yes[0]","1");
                }
                else
                {
                   pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aI[0].no[0]._5bI_no[0]", "0");
                }
                pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aB[0].yes[0]._5aB_yes[0]", "1");
                pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aB[0].no[0]._5aB_no[0]", "0");


                if(data.Declaration.BorrowerDeclaration.IsAnyPartOfTheDownPayment == true)
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aC[0].yes[0]._5aC_yes[0]", "1");
                }
                else
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aC[0].no[0]._5aC_no[0]", "0");
                }


                if(data.Declaration.BorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure == true)
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aD2[0].yes[0]._5aD2_yes[0]", "1");
                }
                else
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aD2[0].no[0]._5aD2_no[0]", "0");
                }
                if (data.Declaration.BorrowerDeclaration.IsPresentlyDelinquent == true)
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aD1[0].yes[0]._5aD1_yes[0]", "1");
                }
                else
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aD1[0].no[0]._5aD1_no[0]", "0");
                }

                
                pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aE[0].no[0]._5aE_no[0]", "1");
                pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aE[0].yes[0]._5aE_yes[0]", "0");
                if(data.Declaration.BorrowerDeclaration.IsCoMakerOrEndorser == true)
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bF[0].yes[0]._5bF_yes[0]", "1");
                }
                else
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bF[0].no[0]._5bF_no[0]", "0");
                }
                if (data.Declaration.BorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == true) {
                   pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bG[0].yes[0]._5bG_yes[0]", "1");
                } else {
                   pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bG[0].no[0]._5bG_no[0]", "0");
                }

                if(data.Declaration.BorrowerDeclaration.IsPresentlyDelinquent == true)
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bH[0].yes[0]._5bH_yes[0]", "1");
                }
                else
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bH[0].no[0]._5bH_no[0]", "0");
                }
                if(data.Declaration.BorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle == true)
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bJ[0].yes[0]._5bJ_yes[0]", "1");
                }
                else
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bJ[0].no[0]._5bJ_no[0]", "0");
                }

                if(data.Declaration.BorrowerDeclaration.IsPartyToLawsuit == true)
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aI[0].yes[0]._5bI_yes[0]", "1");
                }
                else
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aI[0].no[0]._5bI_no[0]", "0");
                }

                if(data.Declaration.BorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle == true)
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bL[0].yes[0]._5bL_yes[0]", "1");
                }
                else
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bL[0].no[0]._5bL_no[0]", "0");
                }

                //pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bK[0].no[0]._5bK_no[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bK[0].yes[0]._5bK_yes[0]", );

                if(data.Declaration.BorrowerDeclaration.IsDeclaredBankrupt == true)
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bM[0].yes[0]._5bM_yes[0]", "1");
                }
                else
                {
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bM[0].no[0]._5bM_no[0]", "0");
                }
                pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bM_type[0].ch11[0]._5bM_ch11[0]", "0");
                pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bM_type[0].ch12[0]._5bM_ch12[0]", "1");
                pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bM_type[0].ch13[0]._5bM_ch13[0]", "0");
                pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bM_type[0].ch7[0]._5bM_ch7[0]", "0");

                // Page 6 ends here ..

                // Page 7 starts here ..
                //pdfFormFields.SetField("topmostSubform[0].Page7[0]._6a_SigDate1[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page7[0]._6a_SigDate2[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page7[0]._6a_SigDate3[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page7[0]._6a_SigDate4[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page7[0]._6a_SigDate5[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page7[0]._6a_SigDate6[0]", );

                // Page 7 ends here .. 

                // Page 8 starts here ..
                //pdfFormFields.SetField("topmostSubform[0].Page8[0]._7[0].current[0]._7_Active_Duty_Month[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page8[0]._7[0].current[0]._7_Active_Duty_Year[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page8[0]._7[0].current[0]._7_Active_Duty_day[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page8[0]._7[0].current[0]._7_current[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page8[0]._7[0].non_active[0]._7_non_active[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page8[0]._7[0].retired[0]._7_retired[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page8[0]._7[0].surviving[0]._7_surviving[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page8[0]._7service[0].no[0]._7service_no[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page8[0]._7service[0].yes[0]._7service_yes[0]", );


                if(data.Declaration.BorrowerDemographic.Ethnicity != null)
                {
                  foreach (var ethnic in data.Declaration.BorrowerDemographic.Ethnicity)
                    {
                        switch ((Ethnic)ethnic.Id)
                        {
                            case Ethnic.HispanicOrLatino:
                                {
                                   var HispanicOrLatino = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0]._8_hispanic[0]");
                                    pdfFormFields.SetField("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0]._8_hispanic[0]", HispanicOrLatino[0]);
                                }
                                break;
                            case Ethnic.Mexican:
                                {
                                    var Mexican = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0].hispanic[0].mexican[0]._8_ethnicity_Mexican[0]");
                                    pdfFormFields.SetField("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0].hispanic[0].mexican[0]._8_ethnicity_Mexican[0]", Mexican[0]);
                                }
                                break;
                            case Ethnic.PuertoRican:
                                {
                                    var PuertoRican = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0].hispanic[0].puertorican[0]._8_ethnicity_Puerto_Rican[0]");
                                    pdfFormFields.SetField("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0].hispanic[0].puertorican[0]._8_ethnicity_Puerto_Rican[0]", PuertoRican[0]);
                                };
                                break;
                            case Ethnic.Cuban:
                                {
                                    var Cuban = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0].hispanic[0].cuban[0]._8_ethnicity_Cuban[0]");
                                    pdfFormFields.SetField("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0].hispanic[0].cuban[0]._8_ethnicity_Cuban[0]", Cuban[0]);

                                }
                                break;
                            case Ethnic.OtherHispanicOrLatino:
                                {
                                    var OtherHispanicOrLatino  = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0].hispanic[0].other[0]._8_hispanic_other[0]");
                                    pdfFormFields.SetField("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0].hispanic[0].other[0]._8_hispanic_other[0]", OtherHispanicOrLatino[0]);
                                //  pdfFormFields.SetField("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0].hispanic[0].other[0]._8_other_hispanic[0]", data.Declaration.BorrowerDemographic.Ethnicity);
                                }
                                break;
                            case Ethnic.NotHispanicOrLatino:
                                {
                                    var NotHispanicOrLatino  = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].ethnicity[0].not_hispanic[0]._8_not_hispanic[0]");

                                    pdfFormFields.SetField("topmostSubform[0].Page8[0].ethnicity[0].not_hispanic[0]._8_not_hispanic[0]", NotHispanicOrLatino[0]);
                                }
                                break;
                            case Ethnic.CanNotProvideEthnic:
                                {
                                    var CanNotProvideEthnic = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].ethnicity[0].refuse[0]._8_ethnicity_refuse[0]");
                                    pdfFormFields.SetField("topmostSubform[0].Page8[0].ethnicity[0].refuse[0]._8_ethnicity_refuse[0]", CanNotProvideEthnic[0]);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                         
                    
                  //  pdfFormFields.SetField("topmostSubform[0].Page8[0].ethnicity_visual[0].no[0]._8_inst_ethnicity_no[0]", );
                  //  pdfFormFields.SetField("topmostSubform[0].Page8[0].ethnicity_visual[0].yes[0]._8_inst_ethnicity_yes[0]", );


                    pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_infosrc[0].email[0]._8_infosrc_email[0]", "1");
                    pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_infosrc[0].face[0]._8_infosrc_face[0]", "0");
                    pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_infosrc[0].fax[0]._8_infosrc_fax[0]", "0");
                    pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_infosrc[0].phone[0]._8_infosrc_phone[0]", "0");


                foreach (var race in data.Declaration.BorrowerDemographic.Race)
                    switch ((Race)race.Id)
                    {
                        case Race.AmericanIndianOrAlaskaNative:
                            {
                                var AmericanIndianOrAlaskaNative = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].native_american[0]._8_race_native_american[0]");
                                var RaceTribe = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].native_american[0]._8_race_tribe[0]");
                                //var BorrowerAmericanIndianOrAlaskaNative = pdfFormFields.GetAppearanceStates("race 1");
                                //pdfFormFields.SetField("race 1", BorrowerAmericanIndianOrAlaskaNative[0]);
                                pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].native_american[0]._8_race_native_american[0]", AmericanIndianOrAlaskaNative[0]);
                                pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].native_american[0]._8_race_tribe[0]", RaceTribe[0]);
                            }

                            break;
                        case Race.Asian:
                            {
                                var Asian  = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].asian[0]._8_race_asian[0]");
                                pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].asian[0]._8_race_asian[0]", Asian[0]);
                            }
                            break;
                        case Race.AsianIndian:
                            {
                                var AsianIndian = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].indian[0]._8_race_indian[0]");
                                pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].indian[0]._8_race_indian[0]", AsianIndian[0]);
                            }
                            break;
                        case Race.BlackOrAfricanAmerican:
                            {
                                var BlackOrAfricanAmerican = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].black[0]._8_race_black[0]");
                                pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].black[0]._8_race_black[0]", BlackOrAfricanAmerican[0]);

                            }
                            break;
                        case Race.CanNotProvideRace:
                            {
                                var CanNotProvideRace = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].not_provide[0]._8_race_refuse[0]");
                                pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].not_provide[0]._8_race_refuse[0]", CanNotProvideRace[0]);

                            }
                            break;
                        case Race.Chinese:
                            {
                                var Chinese = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].chinese[0]._8_race_chinese[0]");

                                pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].chinese[0]._8_race_chinese[0]", Chinese[0]);

                            }
                            break;
                        case Race.Filipino:
                            {
                                var Filipino = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].filipino[0]._8_race_filipino[0]");
                                pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].filipino[0]._8_race_filipino[0]", Filipino[0]);
                            }
                            break;
                        case Race.GuamanianOrChamorro:
                            {
                                var GuamanianOrChamorro = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].pacific[0].pacific[0].guanamian[0]._8_race_guamanian[0]");

                                pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].pacific[0].pacific[0].guanamian[0]._8_race_guamanian[0]", GuamanianOrChamorro[0]);
                            }
                            break;
                        case Race.Japanese:
                            {
                                var Japanese = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].japanese[0]._8_race_japanese[0]");

                                pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].japanese[0]._8_race_japanese[0]", Japanese[0]);
                            }
                            break;
                        case Race.Korean:
                            {
                                var Korean = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].korean[0]._8_race_korean[0]");
                                pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].korean[0]._8_race_korean[0]", Korean[0]);
                            }
                            break;
                        case Race.NativeHawaiian:
                            {
                                var NativeHawaiian = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].pacific[0].pacific[0].hawaiian[0]._8_race_hawaiian[0]");
                                pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].pacific[0].pacific[0].hawaiian[0]._8_race_hawaiian[0]", NativeHawaiian[0]);
                            }
                            break;
                        case Race.NativeHawaiianOrOtherPacificIslander:
                            {
                                var NativeHawaiianOrOtherPacificIslander = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].pacific[0]._8_race_pacific[0]");

                                pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].pacific[0]._8_race_pacific[0]", NativeHawaiianOrOtherPacificIslander[0]);
                            }
                            break;
                        case Race.OtherAsian:
                            {
                                var OtherAsian  = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].other[0]._8_race_asian_other[0]");
                                pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].other[0]._8_race_asian_other[0]", OtherAsian[0]);
                            }
                            break;
                        case Race.OtherPacificIslander:
                            {
                                var OtherPacificIslander = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].pacific[0].pacific[0].other[0]._8_pacific_race[0]");
                                pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].pacific[0].pacific[0].other[0]._8_pacific_race[0]", OtherPacificIslander[0]);
                               // pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].pacific[0].pacific[0].other[0]._8_race_pacific_other[0]", );
                            }
                            break;
                        case Race.Samoan:
                            {
                                var Samoan = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].pacific[0].pacific[0].samoan[0]._8_race_samoan[0]");
                                pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].pacific[0].pacific[0].samoan[0]._8_race_samoan[0]", Samoan[0]);
                            }
                            break;
                        case Race.Vietnamese:
                            {
                                var Vietnamese = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].vietnamese[0]._8_race_vietnamese[0]");
                                pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].vietnamese[0]._8_race_vietnamese[0]", Vietnamese[0]);
                            }
                            break;
                        case Race.White:
                            {
                                var White = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].white[0]._8_race_white[0]");
                                pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].white[0]._8_race_white[0]", White[0]);
                            }
                            break;
                        default:
                            break;
                    }


                if (data.Declaration.CoBorrowerDemographic != null && data.Declaration.CoBorrowerDemographic.Sex != null) {
                    foreach (var sex in data.Declaration.CoBorrowerDemographic.Sex)
                        switch ((Sex)sex.Id)
                        {
                            case Sex.Female:
                                {
                                    var Female = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].sex[0].female[0]._8_sex_female[0]");

                                    pdfFormFields.SetField("topmostSubform[0].Page8[0].sex[0].female[0]._8_sex_female[0]", Female[0]);
                                }
                                break;
                            case Sex.Male:
                                {
                                    var Male = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].sex[0].male[0]._8_sex_male[0]");

                                    pdfFormFields.SetField("topmostSubform[0].Page8[0].sex[0].male[0]._8_sex_male[0]", Male[0]);
                                }
                                break;
                            case Sex.CanNotProvideSex:
                                {
                                    var CanNotProvideSex  = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].sex[0].refuse[0]._8_sex_refuse[0]");

                                    pdfFormFields.SetField("topmostSubform[0].Page8[0].sex[0].refuse[0]._8_sex_refuse[0]", CanNotProvideSex[0]);
                                }
                                break;
                            default:
                                break;
                        }
                }






                //    pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].other[0]._8_asian_race[0]", );







                //pdfFormFields.SetField("topmostSubform[0].Page8[0].race_visual[0].no[0]._8_inst_race_no[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page8[0].race_visual[0].yes[0]._8_inst_race_yes[0]", );
                
                
                //pdfFormFields.SetField("topmostSubform[0].Page8[0].sex_visual[0].no[0]._8_inst_sex_no[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page8[0].sex_visual[0].yes[0]._8_inst_sex_yes[0]", );
                // Page 8 ends here ..

                // Page 9 starts here ..
                //pdfFormFields.SetField("topmostSubform[0].Page9[0]._8a.Loan_Address[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page9[0]._8a.Loan_Org[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page9[0]._8a.Loan_Orginator[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page9[0]._8a.Loan_Ori_Email[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page9[0]._8a.Loan_Ori_NMLSR_ID_[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page9[0]._8a.Loan_Ori_Org_NMLSR_ID_[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page9[0]._8a.Loan_Ori_Org_State_ID_[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page9[0]._8a.Loan_Ori_State_ID_[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page9[0]._8a.Phone1[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page9[0]._8a.Phone2[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page9[0]._8a.Phone3[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page9[0]._8a_Loan_Ori_Date1[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page9[0]._8a_Loan_Ori_Date2[0]", );
                //pdfFormFields.SetField("topmostSubform[0].Page9[0]._8a_Loan_Ori_Date3[0]", );
                // Page 9 ends here ..

                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
            finally
            {
                pdfStamper.Close();
                pdfReader.Close();
                await fileStream.DisposeAsync();
            }


        }

        [HttpGet]
        public async Task<IActionResult> CreatePdf([FromQuery] long Id)
        {
            var mailMessage = new MailMessage();
         // mailMessage.To.Add(new MailAddress("wmartin@ezonlinemortgage.com"));
            mailMessage.To.Add(new MailAddress("shabir.abdulmajeed786@gmail.com"));
            mailMessage.From = new MailAddress("loanapplicationmail@gmail.com");
            mailMessage.Subject = "Home Buying Funnel Form New Lead";
            var data = await _loanAppService.GetAsync(new Abp.Application.Services.Dto.EntityDto<long?>(Id));
            string pdfTemplate = @"Borrower_v28.pdf";
            var pdfReader = new Pdf.PdfReader(pdfTemplate);
        //  var (fileName, path) = CreateFileName(Id);
            MemoryStream memoryStream = new MemoryStream();
        //  var fileStream = new FileStream(path, FileMode.Create);
            var pdfStamper = new Pdf.PdfStamper(pdfReader, memoryStream);

            // fileStream.Position = 0;
            memoryStream.Position = 0;
          // fileStream.CopyTo(memoryStream);

            var attachment = new Attachment(memoryStream, "test.pdf");
            mailMessage.Attachments.Add(attachment);
            _smtpClient.Send(mailMessage); // _smtpClient will be disposed by container
            try
            {
                var pdfFormFields = pdfStamper.AcroFields;

                pdfFormFields.SetField("Name", $"{data.LoanDetails.City}, {StateData.GetStateById(data.LoanDetails.StateId.Value)}");

                pdfFormFields.SetField("Subject Property Address", $"{data.LoanDetails.City}, {StateData.GetStateById(data.LoanDetails.StateId.Value)}");

                var purposeOfLoan = pdfFormFields.GetAppearanceStates("Purpose of Loan");
                if (data.LoanDetails.PurposeOfLoan == 1)
                {
                    pdfFormFields.SetField("Amount", data.LoanDetails.EstimatedPurchasePrice.ToString());
                    pdfFormFields.SetField("Purpose of Loan", "Purchase");
                }
                else if (data.LoanDetails.PurposeOfLoan == 2 || data.LoanDetails.PurposeOfLoan == 3)
                {
                    pdfFormFields.SetField("Amount", data.LoanDetails.EstimatedValue.ToString());
                    pdfFormFields.SetField("Purpose of Loan", "Refinance");
                    pdfFormFields.SetField("Year Lot Acquired", data.LoanDetails.YearAcquired);
                    pdfFormFields.SetField("Original Cost", data.LoanDetails.OriginalPrice.Value.ToString());
                    pdfFormFields.SetField("Amount Existing Liens", data.LoanDetails.CurrentLoanAmount.Value.ToString());
                }

                var propertyWillBe = pdfFormFields.GetAppearanceStates("Property will be");
                switch (data.LoanDetails.PropertyUseId)
                {
                    case 1:
                        pdfFormFields.SetField("Property will be", "Primary Residence");
                        break;
                    case 2:
                        pdfFormFields.SetField("Property will be", "Secondary Residence");
                        break;
                    case 3:
                        pdfFormFields.SetField("Property will be", "Investment");
                        break;
                    default:
                        break;
                }

                pdfFormFields.SetField("Describe Improvements Text", data.LoanDetails.YearAcquired);

                if (data.Declaration.BorrowerDeclaration != null)
                {
                    var BorrowerJudgementsAgainst = pdfFormFields.GetAppearanceStates("Borrower Judgements against");
                    if (data.Declaration.BorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == true)
                        pdfFormFields.SetField("Borrower Judgements against", "2");
                    else if (data.Declaration.BorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == false)
                        pdfFormFields.SetField("Borrower Judgements against", "5");

                    var BorrowerIsDeclaredBankrupt = pdfFormFields.GetAppearanceStates("Borrower Bankrupt");
                    if (data.Declaration.BorrowerDeclaration.IsDeclaredBankrupt == true)
                        pdfFormFields.SetField("Borrower Bankrupt", "2");
                    else if (data.Declaration.BorrowerDeclaration.IsDeclaredBankrupt == false)
                        pdfFormFields.SetField("Borrower Bankrupt", "5");

                    var BorrowerLawsuit = pdfFormFields.GetAppearanceStates("Borrower Lawsuit");
                    if (data.Declaration.BorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == true)
                        pdfFormFields.SetField("Borrower Lawsuit", "Two");
                    else if (data.Declaration.BorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == false)
                        pdfFormFields.SetField("Borrower Lawsuit", "Five");

                    var BorrowerForclose = pdfFormFields.GetAppearanceStates("Check Box");
                    if (data.Declaration.BorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle == true)
                        pdfFormFields.SetField("Check Box", "2");


                    var BorrowerLiability = pdfFormFields.GetAppearanceStates("Borrower Liability");
                    if (data.Declaration.BorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure == true)
                        pdfFormFields.SetField("Borrower Liability", "2");
                    else if (data.Declaration.BorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure == false)
                        pdfFormFields.SetField("Borrower Liability", "5");

                    var BorrowerIsAnyPartOfTheDownPayment = pdfFormFields.GetAppearanceStates("h borrower");
                    if (data.Declaration.BorrowerDeclaration.IsAnyPartOfTheDownPayment == true)
                        pdfFormFields.SetField("h borrower", "2");
                    else if (data.Declaration.BorrowerDeclaration.IsAnyPartOfTheDownPayment == true)
                        pdfFormFields.SetField("h borrower", "1");

                    var BorrowerIsCoMakerOrEndorser = pdfFormFields.GetAppearanceStates("i borrower");
                    if (data.Declaration.BorrowerDeclaration.IsCoMakerOrEndorser == true)
                        pdfFormFields.SetField("i borrower", "Yes");
                    else if (data.Declaration.BorrowerDeclaration.IsCoMakerOrEndorser == true)
                        pdfFormFields.SetField("i borrower", "2");

                    var BorrowerisPresentlyDelinquent = pdfFormFields.GetAppearanceStates("f borrower");
                    if (data.Declaration.BorrowerDeclaration.IsPresentlyDelinquent == true)
                        pdfFormFields.SetField("f borrower", "1");
                    else if (data.Declaration.BorrowerDeclaration.IsPresentlyDelinquent == true)
                        pdfFormFields.SetField("f borrower", "No");

                    var BorrowerIsObligatedToPayAlimonyChildSupport = pdfFormFields.GetAppearanceStates("g borrower");
                    if (data.Declaration.BorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == true)
                        pdfFormFields.SetField("g borrower", "1");
                    else if (data.Declaration.BorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == false)
                        pdfFormFields.SetField("g borrower", "No");

                    var BorrowerIsUSCitizen = pdfFormFields.GetAppearanceStates("j borrower");
                    if (data.Declaration.BorrowerDeclaration.IsUSCitizen == true)
                        pdfFormFields.SetField("j borrower", "2");
                    else if (data.Declaration.BorrowerDeclaration.IsUSCitizen == false)
                        pdfFormFields.SetField("j borrower", "1");

                    var BorrowerIsPermanentResidentSlien = pdfFormFields.GetAppearanceStates("k borrower");
                    if (data.Declaration.BorrowerDeclaration.IsPermanentResidentSlien == true)
                        pdfFormFields.SetField("k borrower", "Yes");
                    else if (data.Declaration.BorrowerDeclaration.IsPermanentResidentSlien == false)
                        pdfFormFields.SetField("k borrower", "2");

                    var BorrowerIsIntendToOccupyThePropertyAsYourPrimary = pdfFormFields.GetAppearanceStates("l borrower");
                    if (data.Declaration.BorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary == true)
                        pdfFormFields.SetField("l borrower", "yes");
                    else if (data.Declaration.BorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary == false)
                        pdfFormFields.SetField("l borrower", "no");

                    var BorrowerIsOwnershipInterestInPropertyInTheLastThreeYears = pdfFormFields.GetAppearanceStates("m borrower");
                    if (data.Declaration.BorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == true)
                        pdfFormFields.SetField("m borrower", "yes");
                    else if (data.Declaration.BorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == false)
                        pdfFormFields.SetField("m borrower", "No");
                }
                if (data.Declaration.CoBorrowerDeclaration != null)
                {
                    if (data.Declaration.CoBorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle == false)
                        pdfFormFields.SetField("Check Box", "5");
                    var CoBorrowerJudgementsAgainst = pdfFormFields.GetAppearanceStates("Co-Borrower Judgements against");
                    if (data.Declaration.CoBorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == true)
                        pdfFormFields.SetField("Co-Borrower Judgements against", "2");
                    else if (data.Declaration.CoBorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == false)
                        pdfFormFields.SetField("Co-Borrower Judgements against", "5");

                    var CoBorrowerIsDeclaredBankrupt = pdfFormFields.GetAppearanceStates("Co-Borrower Bankrupt y");
                    if (data.Declaration.CoBorrowerDeclaration.IsDeclaredBankrupt == true)
                        pdfFormFields.SetField("Co-Borrower Bankrupt y", "2");
                    else if (data.Declaration.CoBorrowerDeclaration.IsDeclaredBankrupt == false)
                        pdfFormFields.SetField("Co-Borrower Bankrupt y", "5");

                    var CoBorrowerLawsuit = pdfFormFields.GetAppearanceStates("Co-Borrower Lawsuit y");
                    if (data.Declaration.CoBorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == true)
                        pdfFormFields.SetField("Co-Borrower Lawsuit y", "2");
                    else if (data.Declaration.CoBorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == false)
                        pdfFormFields.SetField("Co-Borrower Lawsuit y", "5");

                    var CoBorrowerForclose = pdfFormFields.GetAppearanceStates("Co-Borrower Forclose y");
                    if (data.Declaration.BorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle == true)
                        pdfFormFields.SetField("Co-Borrower Forclose y", "2");
                    else if (data.Declaration.CoBorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle == false)
                        pdfFormFields.SetField("Co-Borrower Forclose y", "5");

                    var CoBorrowerLiability = pdfFormFields.GetAppearanceStates("Co-Borrower Liability y");
                    if (data.Declaration.CoBorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure == true)
                        pdfFormFields.SetField("Co-Borrower Liability y", "2");
                    else if (data.Declaration.CoBorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure == false)
                        pdfFormFields.SetField("Co-Borrower Liability y", "5");

                    var CoBorrowerIsCoMakerOrEndorser = pdfFormFields.GetAppearanceStates("i coborrower");
                    if (data.Declaration.CoBorrowerDeclaration.IsCoMakerOrEndorser == true)
                        pdfFormFields.SetField("i coborrower", "Yes");
                    else if (data.Declaration.CoBorrowerDeclaration.IsCoMakerOrEndorser == true)
                        pdfFormFields.SetField("i coborrower", "2");


                    var CoBorrowerIsAnyPartOfTheDownPayment = pdfFormFields.GetAppearanceStates("h coborrower");
                    if (data.Declaration.CoBorrowerDeclaration.IsAnyPartOfTheDownPayment == true)
                        pdfFormFields.SetField("h coborrower", "Yes");
                    else if (data.Declaration.CoBorrowerDeclaration.IsAnyPartOfTheDownPayment == true)
                        pdfFormFields.SetField("h coborrower", "2");

                    var CoBorrowerisPresentlyDelinquent = pdfFormFields.GetAppearanceStates("f coborrower");
                    if (data.Declaration.CoBorrowerDeclaration.IsPresentlyDelinquent == true)
                        pdfFormFields.SetField("f coborrower", "1");
                    else if (data.Declaration.CoBorrowerDeclaration.IsPresentlyDelinquent == true)
                        pdfFormFields.SetField("f coborrower", "No");

                    var CoBorrowerIsObligatedToPayAlimonyChildSupport = pdfFormFields.GetAppearanceStates("g coborrower");
                    if (data.Declaration.CoBorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == true)
                        pdfFormFields.SetField("g coborrower", "1");
                    else if (data.Declaration.CoBorrowerDeclaration.IsObligatedToPayAlimonyChildSupport == false)
                        pdfFormFields.SetField("g coborrower", "No");

                    var CoBorrowerIsUSCitizen = pdfFormFields.GetAppearanceStates("j coborrower");
                    if (data.Declaration.CoBorrowerDeclaration.IsUSCitizen == true)
                        pdfFormFields.SetField("j borrower", "yes");
                    else if (data.Declaration.CoBorrowerDeclaration.IsUSCitizen == false)
                        pdfFormFields.SetField("j borrower", "2");

                    var CoBorrowerIsPermanentResidentSlien = pdfFormFields.GetAppearanceStates("k coborrower");
                    if (data.Declaration.CoBorrowerDeclaration.IsPermanentResidentSlien == true)
                        pdfFormFields.SetField("k borrower", "yes");
                    else if (data.Declaration.CoBorrowerDeclaration.IsPermanentResidentSlien == false)
                        pdfFormFields.SetField("k borrower", "2");

                    var CoBorrowerIsIntendToOccupyThePropertyAsYourPrimary = pdfFormFields.GetAppearanceStates("l coborrower");
                    if (data.Declaration.CoBorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary == true)
                        pdfFormFields.SetField("l borrower", "2");
                    else if (data.Declaration.CoBorrowerDeclaration.IsIntendToOccupyThePropertyAsYourPrimary == false)
                        pdfFormFields.SetField("l borrower", "No");

                    var CoBorrowerIsOwnershipInterestInPropertyInTheLastThreeYears = pdfFormFields.GetAppearanceStates("m coborrower");
                    if (data.Declaration.CoBorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == true)
                        pdfFormFields.SetField("m borrower", "Yes");
                    else if (data.Declaration.CoBorrowerDeclaration.IsOutstandingJudgmentsAgainstYou == false)
                        pdfFormFields.SetField("m borrower", "2");
                }
                if (data.EmploymentIncome.CoBorrowerEmploymentInfo != null)
                    for (int i = 0; i < data.EmploymentIncome.CoBorrowerEmploymentInfo.Count(); i++)
                    {


                        if (i == 0)
                        {
                            var CoBorrowerSelfEmployed1 = pdfFormFields.GetAppearanceStates("CoBorrower Self Employed 1");
                            //if (data.EmploymentIncome.CoBorrowerEmploymentInfo[i].IsSelfEmployed != null && data.EmploymentIncome.CoBorrowerEmploymentInfo[i].IsSelfEmployed == true)
                            //{
                            //    pdfFormFields.SetField("CoBorrower Self Employed 1", CoBorrowerSelfEmployed1[0]);
                            //}
                        }
                        else if (i == 1)
                        {
                            var CoBorrowerSelfEmployed1 = pdfFormFields.GetAppearanceStates("CoBorrower Self Employed 2");
                            if (data.EmploymentIncome.CoBorrowerEmploymentInfo[i].IsSelfEmployed == true)
                                pdfFormFields.SetField("CoBorrower Self Employed 2", CoBorrowerSelfEmployed1[0]);
                        }
                        else if (i == 2)
                        {
                            var CoBorrowerSelfEmployed1 = pdfFormFields.GetAppearanceStates("CoBorrower Self Employed 3");
                            if (data.EmploymentIncome.CoBorrowerEmploymentInfo[i].IsSelfEmployed == true)
                                pdfFormFields.SetField("CoBorrower Self Employed 3", CoBorrowerSelfEmployed1[0]);
                        }

                    }

                //Demographic Information
                if (data.Declaration.BorrowerDemographic.Ethnicity != null)
                    foreach (var ethnic in data.Declaration.BorrowerDemographic.Ethnicity)
                        switch ((Ethnic)ethnic.Id)
                        {
                            case Ethnic.HispanicOrLatino:
                                {
                                    var BorrowerHispanicOrLatino = pdfFormFields.GetAppearanceStates("Ethnicity 1");
                                    pdfFormFields.SetField("Ethnicity 1", "2");
                                }

                                break;
                            case Ethnic.NotHispanicOrLatino:
                                {
                                    var BorrowerNotHispanicOrLatino = pdfFormFields.GetAppearanceStates("Ethnicity 1");
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
                                var BorrowerAmericanIndianOrAlaskaNative = pdfFormFields.GetAppearanceStates("race 1");
                                pdfFormFields.SetField("race 1", BorrowerAmericanIndianOrAlaskaNative[0]);
                            }

                            break;
                        case Race.Asian:
                            {
                                //var BorrowerAsian = pdfFormFields.GetAppearanceStates("race 2");
                                //pdfFormFields.SetField("race 2", BorrowerAsian[0]);
                            }
                            break;
                        case Race.BlackOrAfricanAmerican:
                            {
                                var BorrowerBlackOrAfricanAmerican = pdfFormFields.GetAppearanceStates("race 3");
                                pdfFormFields.SetField("race 3", BorrowerBlackOrAfricanAmerican[0]);
                            }
                            break;
                        case Race.NativeHawaiianOrOtherPacificIslander:
                            {
                                //var BorrowerNativeHawaiianOrOtherPacificIslander = pdfFormFields.GetAppearanceStates("race 4");
                                //pdfFormFields.SetField("race 4", BorrowerNativeHawaiianOrOtherPacificIslander[0]);
                            }
                            break;
                        case Race.White:
                            {
                                var BorrowerWhite = pdfFormFields.GetAppearanceStates("race 5");
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
                                var BorrowerFemale = pdfFormFields.GetAppearanceStates("Ethnicity 1");
                                pdfFormFields.SetField("Ethnicity 1", "2");
                            }

                            break;
                        case Sex.Male:
                            {
                                var BorrowerMale = pdfFormFields.GetAppearanceStates(" Sex borrower");
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
                                    var CoBorrowerHispanicOrLatino = pdfFormFields.GetAppearanceStates("Ethnicity 2");
                                    pdfFormFields.SetField("Ethnicity 2", "2");
                                }

                                break;
                            case Ethnic.NotHispanicOrLatino:
                                {
                                    var CoBorrowerNotHispanicOrLatino = pdfFormFields.GetAppearanceStates("Ethnicity 2");
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
                                    var CoBorrowerAmericanIndianOrAlaskaNative = pdfFormFields.GetAppearanceStates("race c1");
                                    pdfFormFields.SetField("race c1", CoBorrowerAmericanIndianOrAlaskaNative[0]);
                                }

                                break;
                            case Race.Asian:
                                {
                                    var CoBorrowerAsian = pdfFormFields.GetAppearanceStates("race c4");
                                    pdfFormFields.SetField("race c4", CoBorrowerAsian[0]);
                                }
                                break;
                            case Race.BlackOrAfricanAmerican:
                                {
                                    var CoBorrowerBlackOrAfricanAmerican = pdfFormFields.GetAppearanceStates("race c6");
                                    pdfFormFields.SetField("race c6", CoBorrowerBlackOrAfricanAmerican[0]);
                                }
                                break;
                            case Race.NativeHawaiianOrOtherPacificIslander:
                                {
                                    var CoBorrowerNativeHawaiianOrOtherPacificIslander = pdfFormFields.GetAppearanceStates("race c2");
                                    pdfFormFields.SetField("race c2", CoBorrowerNativeHawaiianOrOtherPacificIslander[0]);
                                }
                                break;
                            case Race.White:
                                {
                                    var CoBorrowerWhite = pdfFormFields.GetAppearanceStates("race c5");
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
                                    var CoBorrowerFemale = pdfFormFields.GetAppearanceStates("Ethnicity 1");
                                    pdfFormFields.SetField("Ethnicity 1", "2");
                                }

                                break;
                            case Sex.Male:
                                {
                                    var CoBorrowerMale = pdfFormFields.GetAppearanceStates(" Sex borrower");
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

                if (data.PersonalInformation.Borrower != null)
                {
                    pdfFormFields.SetField("Borrower Name", data.PersonalInformation.Borrower.FirstName + " " + data.PersonalInformation.Borrower.LastName);
                    pdfFormFields.SetField("Borrower SSN", data.PersonalInformation.Borrower.SocialSecurityNumber);
                    pdfFormFields.SetField("Borrower Home Phone", data.PersonalInformation.Borrower.HomePhone);
                    pdfFormFields.SetField("Borrower DOB", data.PersonalInformation.Borrower.DateOfBirth);
                    pdfFormFields.SetField("Dependents not listed by Co-Borrower no", data.PersonalInformation.Borrower.NumberOfDependents.HasValue ? data.PersonalInformation.Borrower.NumberOfDependents.Value.ToString() : "");
                }
                if (data.PersonalInformation.ResidentialAddress != null)
                {
                    pdfFormFields.SetField("Borrower Present Address", data.PersonalInformation.ResidentialAddress.AddressLine1 + " "
                      + data.PersonalInformation.ResidentialAddress.City + " "
                         + (data.PersonalInformation.ResidentialAddress.StateId.HasValue ? StateData.GetStateById(data.PersonalInformation.ResidentialAddress.StateId.Value) : "") + " "
                       + (data.PersonalInformation.ResidentialAddress.ZipCode.HasValue ? data.PersonalInformation.ResidentialAddress.ZipCode.Value.ToString() : ""));
                }
                if (data.PersonalInformation.IsMailingAddressSameAsResidential == false && data.PersonalInformation.MailingAddress != null)
                {
                    pdfFormFields.SetField("Borrower Mailing Address if different from Present", data.PersonalInformation.MailingAddress.AddressLine1 + " "
                  + data.PersonalInformation.MailingAddress.City + " "
                     + (data.PersonalInformation.MailingAddress.StateId.HasValue ? StateData.GetStateById(data.PersonalInformation.MailingAddress.StateId.Value) : "") + " "
                   + (data.PersonalInformation.MailingAddress.ZipCode.HasValue ? data.PersonalInformation.MailingAddress.ZipCode.Value.ToString() : ""));
                }

                if (data.PersonalInformation.PreviousAddresses != null && data.PersonalInformation.PreviousAddresses.Count() != 0)
                {
                    pdfFormFields.SetField("Borrower Former Address if different from Present", data.PersonalInformation.PreviousAddresses[0].AddressLine1 + " "
                  + data.PersonalInformation.PreviousAddresses[0].City + " "
                     + (data.PersonalInformation.PreviousAddresses[0].StateId.HasValue ? StateData.GetStateById(data.PersonalInformation.PreviousAddresses[0].StateId.Value) : "") + " "
                   + (data.PersonalInformation.PreviousAddresses[0].ZipCode.HasValue ? data.PersonalInformation.PreviousAddresses[0].ZipCode.Value.ToString() : ""));

                }

                if (data.PersonalInformation.ResidentialAddress != null)
                    pdfFormFields.SetField("Borrower No of Years", data.PersonalInformation.ResidentialAddress.Years.HasValue ? data.PersonalInformation.ResidentialAddress.Years.Value.ToString() : "");
                if (data.PersonalInformation.MailingAddress != null)
                    pdfFormFields.SetField("Borrower No of Years Former Address", data.PersonalInformation.IsMailingAddressSameAsResidential == false ?
                        data.PersonalInformation.MailingAddress.AddressLine1 + " " +
                        data.PersonalInformation.MailingAddress.City + " " +
                        (data.PersonalInformation.MailingAddress.StateId.HasValue ? data.PersonalInformation.MailingAddress.StateId.Value.ToString() : "") + " " +
                        (data.PersonalInformation.MailingAddress.ZipCode.HasValue ? data.PersonalInformation.MailingAddress.ZipCode.Value.ToString() : "") : "");

                for (var index = 0; index < data.EmploymentIncome.BorrowerEmploymentInfo.Count; index++)
                {
                    var borrowerEmploymentInfo = data.EmploymentIncome.BorrowerEmploymentInfo[index];
                    switch (index)
                    {
                        case 0:
                            DateTime now = DateTime.Today;
                            int Years = now.Year - borrowerEmploymentInfo.StartDate.Value.Year;
                            if (borrowerEmploymentInfo.StartDate.Value > now.AddYears(-Years)) Years--;
                            pdfFormFields.SetField("Borrower Years on the job", Years.ToString());
                            pdfFormFields.SetField("Borrower Position/Title/Type of Business", borrowerEmploymentInfo.Position);

                            var BorrowerSelfEmployed1 = pdfFormFields.GetAppearanceStates("Borrower Self Employed 1");
                            //if (borrowerEmploymentInfo.IsSelfEmployed == true)
                            //    pdfFormFields.SetField("Borrower Self Employed 1", BorrowerSelfEmployed1[0]);
                            break;
                        case 1:
                            //pdfFormFields.SetField("Borrower Employment info Cont position title", borrowerEmploymentInfo.Position);
                            //pdfFormFields.SetField("Borrower Employment info Cont Dates of Employ", $"{borrowerEmploymentInfo.StartDate.Value} {borrowerEmploymentInfo.EndDate.Value}");
                            //pdfFormFields.SetField("Borrower Employment info Cont Name and adress of Employ", borrowerEmploymentInfo.EmployerName + " " +
                            //        data.EmploymentIncome.BorrowerEmploymentInfo[1].Address1 + " "
                            //        + data.EmploymentIncome.BorrowerEmploymentInfo[1].City + " "
                            //       + (data.EmploymentIncome.BorrowerEmploymentInfo[1].StateId.HasValue ? StateData.GetStateById(data.EmploymentIncome.BorrowerEmploymentInfo[1].StateId.Value) : "") + " "
                            //        + (data.EmploymentIncome.BorrowerEmploymentInfo[1].ZipCode.HasValue ? data.EmploymentIncome.BorrowerEmploymentInfo[1].ZipCode.Value.ToString() : "")
                            //        );
                            //pdfFormFields.SetField("Borrower Employment info Cont position title2", borrowerEmploymentInfo.Position);
                            //var BorrowerSelfEmployed2 = pdfFormFields.GetAppearanceStates("Borrower Self Employed 2");
                            //if (borrowerEmploymentInfo.IsSelfEmployed == true)
                            //    pdfFormFields.SetField("Borrower Self Employed 2", BorrowerSelfEmployed2[0]);
                            break;
                        case 2:
                            var BorrowerSelfEmployed3 = pdfFormFields.GetAppearanceStates("Borrower Self Employed 3");
                            if (borrowerEmploymentInfo.IsSelfEmployed == true)
                                pdfFormFields.SetField("Borrower Self Employed 3", BorrowerSelfEmployed3[0]);
                            break;
                        case 3:
                            break;
                        default:
                            break;
                    }
                }

                if (data.PersonalInformation.ResidentialAddress != null)
                    pdfFormFields.SetField("Borrower Name and Address of Employer", data.PersonalInformation.ResidentialAddress.AddressLine1 + " "
                        + data.PersonalInformation.ResidentialAddress.City + " "
                           + (data.PersonalInformation.ResidentialAddress.StateId.HasValue ? StateData.GetStateById(data.PersonalInformation.ResidentialAddress.StateId.Value) : "") + " "
                         + (data.PersonalInformation.ResidentialAddress.ZipCode.HasValue ? data.PersonalInformation.ResidentialAddress.ZipCode.Value.ToString() : ""));
                if (data.PersonalInformation.Borrower != null)
                    pdfFormFields.SetField("Borrower Business phone", data.PersonalInformation.Borrower.CellPhone);

                if (data.PersonalInformation.CoBorrower != null)
                {
                    pdfFormFields.SetField("Co-Borrower SSN", data.PersonalInformation.CoBorrower.SocialSecurityNumber);
                    pdfFormFields.SetField("Co-Borrower Name", data.PersonalInformation.CoBorrower.FirstName + " " + data.PersonalInformation.CoBorrower.LastName);
                    pdfFormFields.SetField("Co-Borrower Home Phone", data.PersonalInformation.CoBorrower.HomePhone);
                    pdfFormFields.SetField("Co-Borrower DOB", data.PersonalInformation.CoBorrower.DateOfBirth);
                    pdfFormFields.SetField("Dependents not listed by Borrower no", data.PersonalInformation.CoBorrower.NumberOfDependents.HasValue ? data.PersonalInformation.CoBorrower.NumberOfDependents.Value.ToString() : "");

                    if (data.PersonalInformation.CoBorrowerResidentialAddress != null)
                        pdfFormFields.SetField("Co-Borrower Present Address", data.PersonalInformation.CoBorrowerResidentialAddress.AddressLine1 + " "
                                + data.PersonalInformation.CoBorrowerResidentialAddress.City + " "
                                   + (data.PersonalInformation.CoBorrowerResidentialAddress.StateId.HasValue ? StateData.GetStateById(data.PersonalInformation.CoBorrowerResidentialAddress.StateId.Value) : "") + " "
                                + (data.PersonalInformation.CoBorrowerResidentialAddress.ZipCode.HasValue ? data.PersonalInformation.CoBorrowerResidentialAddress.ZipCode.Value.ToString() : ""));

                    if (data.PersonalInformation.CoBorrowerResidentialAddress != null)
                        pdfFormFields.SetField("Co-Borrower No of Years", data.PersonalInformation.CoBorrowerResidentialAddress.Years.ToString());
                    if (data.PersonalInformation.MailingAddress != null)
                    {
                        pdfFormFields.SetField("Co-Borrower Mailing Address if different from Present", data.PersonalInformation.CoBorrowerMailingAddress.AddressLine1 + " "
                        + data.PersonalInformation.CoBorrowerMailingAddress.City + " "
                           + (data.PersonalInformation.CoBorrowerMailingAddress.StateId.HasValue ? StateData.GetStateById(data.PersonalInformation.CoBorrowerMailingAddress.StateId.Value) : "") + " "
                         + (data.PersonalInformation.CoBorrowerMailingAddress.ZipCode.HasValue ? data.PersonalInformation.CoBorrowerMailingAddress.ZipCode.Value.ToString() : ""));
                    }

                    if (data.PersonalInformation.CoBorrowerPreviousAddresses != null && data.PersonalInformation.CoBorrowerPreviousAddresses.Count() != 0)
                    {
                        pdfFormFields.SetField("Co-Borrower Former Address if different from Present", data.PersonalInformation.CoBorrowerPreviousAddresses[0].AddressLine1 + " "
                        + data.PersonalInformation.CoBorrowerPreviousAddresses[0].City + " "
                           + (data.PersonalInformation.CoBorrowerPreviousAddresses[0].StateId.HasValue ? StateData.GetStateById(data.PersonalInformation.CoBorrowerPreviousAddresses[0].StateId.Value) : "") + " "
                         + (data.PersonalInformation.CoBorrowerPreviousAddresses[0].ZipCode.HasValue ? data.PersonalInformation.CoBorrowerPreviousAddresses[0].ZipCode.Value.ToString() : ""));
                    }
                }

                if (data.EmploymentIncome.CoBorrowerEmploymentInfo.Count() >= 1 && data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StartDate.HasValue)
                {
                    DateTime now = DateTime.Today;
                    int Years = now.Year - data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StartDate.Value.Year;
                    if (data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StartDate.Value > now.AddYears(-Years)) Years--;
                    pdfFormFields.SetField("Co-Borrower Years on the job", Years.ToString());

                    //pdfFormFields.SetField("Co-Borrower Name and Address of Employer", data.EmploymentIncome.CoBorrowerEmploymentInfo[0].EmployerName + " " +
                    //     data.EmploymentIncome.CoBorrowerEmploymentInfo[0].Address1 + " " +
                    //    data.EmploymentIncome.CoBorrowerEmploymentInfo[0].City + " "
                    //        + (data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StateId.HasValue ? StateData.GetStateById(data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StateId.Value) : "") + " "
                    //      + (data.EmploymentIncome.CoBorrowerEmploymentInfo[0].ZipCode.HasValue ? data.EmploymentIncome.CoBorrowerEmploymentInfo[0].ZipCode.Value.ToString() : "")
                    //      );
                }

                if (data.EmploymentIncome.BorrowerEmploymentInfo.Count >= 3)
                {
                    pdfFormFields.SetField("Borrower Employment info Cont position title2", data.EmploymentIncome.BorrowerEmploymentInfo[2].Position
                       );
                    if (data.EmploymentIncome.BorrowerEmploymentInfo[2].EndDate.HasValue)
                        pdfFormFields.SetField("Borrower Employment info Cont Dates of Employ 2", data.EmploymentIncome.BorrowerEmploymentInfo[2].StartDate.Value.ToString() + " " +
                                data.EmploymentIncome.BorrowerEmploymentInfo[2].EndDate.Value.ToString()
                                );
                    pdfFormFields.SetField("Borrower Employment info Cont Name and adress of Employ 2", data.EmploymentIncome.BorrowerEmploymentInfo[2].EmployerName + " " +
                   data.EmploymentIncome.BorrowerEmploymentInfo[2].Address1 + " "
                   + data.EmploymentIncome.BorrowerEmploymentInfo[2].City + " "
                  + (data.EmploymentIncome.BorrowerEmploymentInfo[2].StateId.HasValue ? StateData.GetStateById(data.EmploymentIncome.BorrowerEmploymentInfo[2].StateId.Value) : "") + " "
                   + (data.EmploymentIncome.BorrowerEmploymentInfo[2].ZipCode.HasValue ? data.EmploymentIncome.BorrowerEmploymentInfo[2].ZipCode.Value.ToString() : "")
                   );

                }
                if (data.EmploymentIncome.BorrowerMonthlyIncome != null)
                {
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
                }
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

                if (data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).Count() >= 1)
                {
                    if (data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[0].StateId.HasValue)
                    {
                        pdfFormFields.SetField("Assets Name and Adress of Bank, S&L, Or Credit Union 3", data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[0].Address + " " +
                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[0].City + " " +
                        StateData.GetStateById(data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[0].StateId.Value)
                        );

                    }
                    pdfFormFields.SetField("Assets Acct no 3",
                                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[0].AccountNumber
                                        );

                    pdfFormFields.SetField("Assets Acct no 3 Balance 4",
                                        data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[0].CashValue.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[0].CashValue.Value.ToString() : ""
                    );
                }

                if (data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).Count() >= 2)
                {
                    if (data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[1].StateId.HasValue)
                    {
                        pdfFormFields.SetField("Assets Name and Adress of Bank, S&L, Or Credit Union 4",
                     data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[1].Address + " " +
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[1].City + " " +
                    StateData.GetStateById(data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[1].StateId.Value)
                    );
                    }
                    pdfFormFields.SetField("Assets Acct no 4",
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[1].AccountNumber
                    );

                    pdfFormFields.SetField("Assets Acct no 4 Balance 5",
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[1].CashValue.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[0].CashValue.Value.ToString() : ""
                    );
                }

                if (data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).Count() >= 2)
                {
                    if (data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[1].StateId.HasValue)
                    {
                        pdfFormFields.SetField("Assets Name and Adress of Bank, S&L, Or Credit Union 2", data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[1].Address + " " +
                       data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[1].City + " " +
                       StateData.GetStateById(data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[1].StateId.Value)
                       );
                    }
                    pdfFormFields.SetField("Assets Acct no 2",
                                       data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[1].AccountNumber
                                       );

                    pdfFormFields.SetField("Assets Acct no 1 Balance b",
                                       data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[1].CashValue.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[0].CashValue.Value.ToString() : ""
                                       );
                }

                if (data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).Count() >= 1)
                {
                    if (data.ManualAssetEntries.Where(i => i.AssetTypeId == 3).ToList()[0].StateId.HasValue)
                    {
                        pdfFormFields.SetField("Assets Name and Adress of Bank, S&L, Or Credit Union",
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[0].Address + " " +
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[0].City + " " +
                    StateData.GetStateById(data.ManualAssetEntries.Where(i => i.AssetTypeId == 11).ToList()[0].StateId.Value)
                    );
                    }

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

                #region Credco

                var credCoData = await _credcoApi.GetCreditDataAsync(data.PersonalInformation);
                if (credCoData != null)
                {
                    var liabilities = credCoData.RESPONSE.RESPONSE_DATA.CREDIT_RESPONSE.CREDIT_LIABILITY;

                    for (int i = 0; i < liabilities.Count; i++)
                    {
                        var liability = liabilities[i];
                        switch (i)
                        {
                            case 0:
                                pdfFormFields.SetField("Liabilities Name and Adress 1", liability._OriginalCreditorName);
                                pdfFormFields.SetField("Monthly Payment & Months to Pay 1", liability._MonthlyPaymentAmount);
                                pdfFormFields.SetField("Unpaid Balance 1", liability._UnpaidBalanceAmount);
                                pdfFormFields.SetField("Liabilities Acct no 1a", liability._AccountIdentifier);
                                break;

                            case 1:
                                pdfFormFields.SetField("Liabilities Name and Adress 2", liability._OriginalCreditorName);
                                pdfFormFields.SetField("Monthly Payment & Months to Pay 2", liability._MonthlyPaymentAmount);
                                pdfFormFields.SetField("Unpaid Balance 2", liability._UnpaidBalanceAmount);
                                pdfFormFields.SetField("Liabilities Acct no 2a", liability._AccountIdentifier);
                                break;

                            case 2:
                                pdfFormFields.SetField("Liabilities Name and Adress 3", liability._OriginalCreditorName);
                                pdfFormFields.SetField("Monthly Payment & Months to Pay 3", liability._MonthlyPaymentAmount);
                                pdfFormFields.SetField("Unpaid Balance 3a", liability._UnpaidBalanceAmount);
                                pdfFormFields.SetField("Liabilities Acct no 3a", liability._AccountIdentifier);
                                break;

                            case 3:
                                pdfFormFields.SetField("Liabilities Name and Adress 4", liability._OriginalCreditorName);
                                pdfFormFields.SetField("Monthly Payment & Months to Pay 4", liability._MonthlyPaymentAmount);
                                pdfFormFields.SetField("Unpaid Balance 3", liability._UnpaidBalanceAmount);
                                pdfFormFields.SetField("Liabilities Acct no 4 a", liability._AccountIdentifier);
                                break;

                            case 4:
                                pdfFormFields.SetField("Asset/Liabilities Stocks and Bonds Name and Address", liability._OriginalCreditorName);
                                pdfFormFields.SetField("Asset/Liabilities Stocks and Bonds Monthly Payments", liability._MonthlyPaymentAmount);
                                pdfFormFields.SetField("Text33", liability._UnpaidBalanceAmount);
                                pdfFormFields.SetField("Asset/Liabilities Stocks and Bonds Acct no", liability._AccountIdentifier);
                                break;

                            case 5:
                                pdfFormFields.SetField("Life insurance Name and Address", liability._OriginalCreditorName);
                                pdfFormFields.SetField("Life Insurance Monthly Payments", liability._MonthlyPaymentAmount);
                                pdfFormFields.SetField("Life Insurance Monthly Payments Totals", liability._UnpaidBalanceAmount);
                                pdfFormFields.SetField("Text42", liability._AccountIdentifier);
                                break;

                            //     case 6:
                            //      //Not Found
                            //    pdfFormFields.SetField("Monthly Child Support Payments", liability._MonthlyPaymentAmount);
                            //     pdfFormFields.SetField("Auto Payments", liability._MonthlyPaymentAmount);


                            //     break;
                            //     //Not Found
                            //      case 7:
                            //      pdfFormFields.SetField("Job Related Expenses", liability._MonthlyPaymentAmount);
                            //     pdfFormFields.SetField("Other Payments", liability._MonthlyPaymentAmount);

                            //     break;
                            //      case 8:
                            //      pdfFormFields.SetField("Total Monthly Payments 2", liability._MonthlyPaymentAmount);

                            //     break;

                            //      case 9:
                            //      pdfFormFields.SetField("net_worth_aminusb", liability._HighBalanceAmount);
                            //      pdfFormFields.SetField("liab_total", liability._HighBalanceAmount);


                            //     break;
                            default:
                                break;
                        }
                    }
                }

                #endregion
              // fileStream.Position = 0;
                memoryStream.Position = 0;
             // fileStream.CopyTo(memoryStream);

               // var attachment = new Attachment(memoryStream, "test.pdf");
               // mailMessage.Attachments.Add(attachment);
              //  _smtpClient.Send(mailMessage); // _smtpClient will be disposed by container

                return Ok();

            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
            finally
            {
                pdfStamper.Close();
               // await fileStream.DisposeAsync();
            }
        }

        [HttpGet]
        public async Task<IActionResult> DownloadPdf([FromQuery] long id)
        {
            var (fileName, path) = CreateFileName(id);
            //var stream = new MemoryStream(await System.IO.File.ReadAllBytesAsync(path));
            //var response = File(stream, "application/pdf", $"{fileName}");
            //Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName}");
            var mailMessage = new MailMessage();
            mailMessage.To.Add(new MailAddress("wmartin@ezonlinemortgage.com"));
            mailMessage.To.Add(new MailAddress("shabir.abdulmajeed786@gmail.com"));
            mailMessage.From = new MailAddress("loanapplicationmail@gmail.com");
            mailMessage.Subject = "Home Buying Funnel Form New Lead";
            var stream = new MemoryStream(await System.IO.File.ReadAllBytesAsync(path));
            var attachment = new Attachment(stream, "test.pdf");
            mailMessage.Attachments.Add(attachment);
            _smtpClient.Send(mailMessage);

            return Ok();
        }

        private (string fileName, string filePath) CreateFileName(long id)
        {
            string fileName = "LoanDetails" + id + ".pdf";

            var globalDirectory = Path.Combine(_hostingEnvironment.ContentRootPath, "Files");
            if (!Directory.Exists(globalDirectory))
                Directory.CreateDirectory(globalDirectory);
            var path = Path.Combine(globalDirectory, fileName);

            return (fileName, path);
        }



        [HttpPost]
        public async Task<IActionResult> TestCredco([FromBody] PersonalInformationDto personalInformationDto)
        {
            try
            {
                var credCoData = await _credcoApi.GetCreditDataAsync(personalInformationDto);
                return Json(credCoData);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}
