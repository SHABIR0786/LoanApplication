using Abp.Runtime.Validation;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.PdfServices;
using LoanManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.AcroForms;
using PdfSharpCore.Pdf.IO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UniformResidentialLoanController : LoanManagementControllerBase
    {
        private readonly ILoanAppService _loanAppService;

        public IPersonalDetailService _personalDetailService { get; }

        public UniformResidentialLoanController(
            ILoanAppService loanAppService,
            IPersonalDetailService personalDetailService
        )
        {
            _loanAppService = loanAppService;
            _personalDetailService = personalDetailService;
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

        public void FillData(LoanApplicationDto data)
        {
            string templateDocPath = "1003irev-unlocked.pdf";
            var myTemplate = PdfReader.Open(templateDocPath, PdfDocumentOpenMode.Modify);
            var form = myTemplate.AcroForm;

            //var names = new List<string>();
            //foreach (var (key, element) in form.Elements)
            //{
            //    Console.WriteLine($"Key: {key}\t Element: {element}");
            //}
            //for (int i = 0; i < form.Elements.Count(); i++)
            //{
            //    names.Add(form.Elements[i].Name);
            //}

            var a = form.Fields["Total a\u002Bb"];
            PdfCheckBoxField mortgageAppliedFor = (PdfCheckBoxField)(form.Fields["Purpose of Loan"]);
            mortgageAppliedFor.Value = new PdfString(data.LoanDetails.PurposeOfLoan.HasValue ? data.LoanDetails.PurposeOfLoan.Value.ToString() : "");
            PdfTextField Amount = (PdfTextField)(form.Fields["Amount"]);
            Amount.Value = new PdfString(data.LoanDetails.CurrentLoanAmount.HasValue ? data.LoanDetails.CurrentLoanAmount.Value.ToString() : "");
            //PdfTextField NumberOfMonths = (PdfTextField)(form.Fields["No"]);
            //NumberOfMonths.Value = new PdfString(data.LoanDetails..ToString());
            // PdfTextField PersonalAddress = (PdfTextField)(form.Fields["Subject Property Address"]);
            // PersonalAddress.Value = new PdfString(data.PersonalInformation.ResidentialAddress.ToString());
            // PdfTextField SubjectPropertyDescription = (PdfTextField)(form.Fields["Subject Property Description"]);
            // SubjectPropertyDescription.Value = new PdfString(data.LoanDetails.CurrentLoanAmount.ToString());
            // PdfTextField YearBuilt = (PdfTextField)(form.Fields["Year Built"]);
            // YearBuilt.Value = new PdfString(data.LoanDetails.CurrentLoanAmount.ToString());
            //PdfCheckBoxField[] testField = (PdfCheckBoxField)(form.Fields.Where(((PdfCheckBoxField)i) => i.));
            //testField.Checked = new PdfString(data.LoanDetails.CurrentLoanAmount.ToString());

            //Borrower
            PdfTextField BorrowerName = (PdfTextField)(form.Fields["Borrower Name"]);
            BorrowerName.Value = new PdfString(data.PersonalInformation.Borrower.FirstName + " " + data.PersonalInformation.Borrower.LastName);
            PdfTextField BorrowerSSN = (PdfTextField)(form.Fields["Borrower SSN"]);
            BorrowerSSN.Value = new PdfString(data.PersonalInformation.Borrower.SocialSecurityNumber);
            PdfTextField BorrowerHomePhone = (PdfTextField)(form.Fields["Borrower Home Phone"]);
            BorrowerHomePhone.Value = new PdfString(data.PersonalInformation.Borrower.HomePhone);
            PdfTextField BorrowerDOB = (PdfTextField)(form.Fields["Borrower DOB"]);
            BorrowerDOB.Value = new PdfString(data.PersonalInformation.Borrower.DateOfBirth);
            //PdfTextField BorrowerMaritalStatus = (PdfTextField)(form.Fields["Borrower Marital Status"]);
            //BorrowerMaritalStatus.Value = new PdfString(data.PersonalInformation.Borrower.MaritalStatusId);
            PdfTextField BorrowerNumberOfDependents = (PdfTextField)(form.Fields["Dependents not listed by Co-Borrower no"]);
            BorrowerNumberOfDependents.Value = new PdfString(data.PersonalInformation.Borrower.NumberOfDependents.HasValue ? data.PersonalInformation.Borrower.NumberOfDependents.Value.ToString() : "");
            PdfTextField BorrowerPresentAddress = (PdfTextField)(form.Fields["Borrower Present Address"]);
            BorrowerPresentAddress.Value = new PdfString(
                data.PersonalInformation.ResidentialAddress.AddressLine1 + " "
                + data.PersonalInformation.ResidentialAddress.City + " "
                   + (data.PersonalInformation.ResidentialAddress.StateId.HasValue ? _personalDetailService.GetStateId(data.PersonalInformation.ResidentialAddress.StateId.Value) : "") + " "
                 + (data.PersonalInformation.ResidentialAddress.ZipCode.HasValue ? data.PersonalInformation.ResidentialAddress.ZipCode.Value.ToString() : ""));
            // PdfTextField BorrowerOwnOrRent = (PdfTextField)(form.Fields["Borrower Own or Rent"]);
            // BorrowerOwnOrRent.Value = new PdfString((data.Expenses.IsLiveWithFamilySelectRent == true).ToString());
            PdfTextField BorrowerNoOfYears = (PdfTextField)(form.Fields["Borrower No of Years"]);
            BorrowerNoOfYears.Value = new PdfString(data.PersonalInformation.ResidentialAddress.Years.HasValue ? data.PersonalInformation.ResidentialAddress.Years.Value.ToString() : "");

            PdfTextField BorrowerNoOfYearsFormerAddress = (PdfTextField)(form.Fields["Borrower No of Years Former Address"]);
            BorrowerNoOfYearsFormerAddress.Value = new PdfString(
                data.PersonalInformation.IsMailingAddressSameAsResidential == false ?
                data.PersonalInformation.MailingAddress.AddressLine1 + " " +
                data.PersonalInformation.MailingAddress.City + " " +
                (data.PersonalInformation.MailingAddress.StateId.HasValue ? data.PersonalInformation.MailingAddress.StateId.Value.ToString() : "") + " " +
                (data.PersonalInformation.MailingAddress.ZipCode.HasValue ? data.PersonalInformation.MailingAddress.ZipCode.Value.ToString() : "") : "");

            // PdfTextField BorrowerSelfEmployed = (PdfTextField)(form.Fields["Borrower Self Employed"]);
            // BorrowerSelfEmployed.Value = new PdfString(data.EmploymentIncome.BorrowerEmploymentInfo[0].IsSelfEmployed.ToString());
            if (data.EmploymentIncome.BorrowerEmploymentInfo.Count() >= 1 && data.EmploymentIncome.BorrowerEmploymentInfo[0].StartDate.HasValue)
            {
                DateTime now = DateTime.Today;
                int Years = now.Year - data.EmploymentIncome.BorrowerEmploymentInfo[0].StartDate.Value.Year;
                if (data.EmploymentIncome.BorrowerEmploymentInfo[0].StartDate.Value > now.AddYears(-Years)) Years--;
                PdfTextField BorrowerYearsOnTheJob = (PdfTextField)(form.Fields["Borrower Years on the job"]);
                BorrowerYearsOnTheJob.Value = new PdfString(Years.ToString());

            }
            PdfTextField BorrowerNameAndAddressOfEmployer = (PdfTextField)(form.Fields["Borrower Name and Address of Employer"]);
            BorrowerNameAndAddressOfEmployer.Value = new PdfString(

                data.PersonalInformation.ResidentialAddress.AddressLine1 + " "
                + data.PersonalInformation.ResidentialAddress.City + " "
                   + (data.PersonalInformation.ResidentialAddress.StateId.HasValue ? _personalDetailService.GetStateId(data.PersonalInformation.ResidentialAddress.StateId.Value) : "") + " "
                 + (data.PersonalInformation.ResidentialAddress.ZipCode.HasValue ? data.PersonalInformation.ResidentialAddress.ZipCode.Value.ToString() : ""));
            //PdfTextField BorrowerBusinessPhone = (PdfTextField)(form.Fields["Borrower Business phone"]);
            //BorrowerBusinessPhone.Value = new PdfString(data.PersonalInformation.Borrower.CellPhone.ToString());


            //"Borrower Position/Title/Type of Business",


            //"Dependents not listed by Co-Borrower ages"
            //"Borrower Mailing Address if different from Present",
            //"Borrower Former Own or Rent",
            //"Borrower No of Years Former Address",
            //"Borrower Former Address if different from Present",

            //Co-Borrower
            if (data.PersonalInformation.CoBorrower != null)
            {
                PdfTextField CoBorrowerSSN = (PdfTextField)(form.Fields["Co-Borrower SSN"]);
                CoBorrowerSSN.Value = new PdfString(data.PersonalInformation.CoBorrower.SocialSecurityNumber);
                PdfTextField CoBorrowerName = (PdfTextField)(form.Fields["Co-Borrower Name"]);
                CoBorrowerName.Value = new PdfString(data.PersonalInformation.CoBorrower.FirstName + " " + data.PersonalInformation.CoBorrower.LastName);
                PdfTextField CoBorrowerHomePhone = (PdfTextField)(form.Fields["Co-Borrower Home Phone"]);
                CoBorrowerHomePhone.Value = new PdfString(data.PersonalInformation.CoBorrower.HomePhone);
                PdfTextField CoBorrowerDOB = (PdfTextField)(form.Fields["Co-Borrower DOB"]);
                CoBorrowerDOB.Value = new PdfString(data.PersonalInformation.CoBorrower.DateOfBirth);
                //PdfTextField CoBorrowerMaritalStatus = (PdfTextField)(form.Fields["Co-Borrower Marital Status"]);
                //CoBorrowerMaritalStatus.Value = new PdfString(data.PersonalInformation.CoBorrower.MaritalStatusId);
                PdfTextField CoBorrowerNumberOfDependents = (PdfTextField)(form.Fields["Dependents not listed by Borrower no"]);
                CoBorrowerNumberOfDependents.Value = new PdfString(data.PersonalInformation.CoBorrower.NumberOfDependents.HasValue ? data.PersonalInformation.CoBorrower.NumberOfDependents.Value.ToString() : "");

                PdfTextField CoBorrowerPresentAddress = (PdfTextField)(form.Fields["Co-Borrower Present Address"]);
                CoBorrowerPresentAddress.Value = new PdfString(
                    data.PersonalInformation.CoBorrowerResidentialAddress.AddressLine1 + " "
                    + data.PersonalInformation.CoBorrowerResidentialAddress.City + " "
                       + (data.PersonalInformation.CoBorrowerResidentialAddress.StateId.HasValue ? _personalDetailService.GetStateId(data.PersonalInformation.CoBorrowerResidentialAddress.StateId.Value) : "") + " "
                    + (data.PersonalInformation.CoBorrowerResidentialAddress.ZipCode.HasValue ? data.PersonalInformation.CoBorrowerResidentialAddress.ZipCode.Value.ToString() : ""));

                //PdfTextField CoBorrowerOwnOrRent = (PdfTextField)(form.Fields["Co-Borrower Own or Rent"]);
                //CoBorrowerOwnOrRent.Value = new PdfString(data.Expenses.IsLiveWithFamilySelectRent.ToString());
                PdfTextField CoBorrowerNoOfYears = (PdfTextField)(form.Fields["Co-Borrower No of Years"]);
                CoBorrowerNoOfYears.Value = new PdfString(data.PersonalInformation.CoBorrowerResidentialAddress.Years.ToString());
                if (data.PersonalInformation.CoBorrowerMailingAddress != null)
                {
                    PdfTextField CoBorrowerNoOfYearsFormerAddress = (PdfTextField)(form.Fields["Co-Borrower No of Years Former Address"]);
                    CoBorrowerNoOfYearsFormerAddress.Value = new PdfString(
                        data.PersonalInformation.CoBorrowerIsMailingAddressSameAsResidential == false ?
                        data.PersonalInformation.CoBorrowerMailingAddress.AddressLine1 + " " +
                        data.PersonalInformation.CoBorrowerMailingAddress.City + " " +
                           (data.PersonalInformation.CoBorrowerMailingAddress.StateId.HasValue ? _personalDetailService.GetStateId(data.PersonalInformation.CoBorrowerMailingAddress.StateId.Value) : "") + " " +
                        (data.PersonalInformation.CoBorrowerMailingAddress.ZipCode.HasValue ?
                        data.PersonalInformation.CoBorrowerMailingAddress.ZipCode.Value.ToString() : "") : "");
                }
            }
            // PdfTextField CoBorrowerSelfEmployed = (PdfTextField)(form.Fields["Co-Borrower Self Employed"]);
            // CoBorrowerSelfEmployed.Value = new PdfString(data.EmploymentIncome.CoBorrowerEmploymentInfo[0].IsSelfEmployed.ToString());
            if (data.EmploymentIncome.CoBorrowerEmploymentInfo.Count() >= 1 && data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StartDate.HasValue)
            {
                DateTime now = DateTime.Today;
                int Years = now.Year - data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StartDate.Value.Year;
                if (data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StartDate.Value > now.AddYears(-Years)) Years--;

                PdfTextField CoBorrowerYearsOnTheJob = (PdfTextField)(form.Fields["Co-Borrower Years on the job"]);
                CoBorrowerYearsOnTheJob.Value = new PdfString(Years.ToString());

                PdfTextField CoBorrowerNameAndAddressOfEmployer = (PdfTextField)(form.Fields["Co-Borrower Name and Address of Employer"]);
                CoBorrowerNameAndAddressOfEmployer.Value = new PdfString(
                    data.EmploymentIncome.CoBorrowerEmploymentInfo[0].EmployerName + " " +
                    data.EmploymentIncome.CoBorrowerEmploymentInfo[0].Address1 + " " +
                   data.EmploymentIncome.CoBorrowerEmploymentInfo[0].City + " "
                       + (data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StateId.HasValue ? _personalDetailService.GetStateId(data.EmploymentIncome.CoBorrowerEmploymentInfo[0].StateId.Value) : "") + " "
                     + (data.EmploymentIncome.CoBorrowerEmploymentInfo[0].ZipCode.HasValue ? data.EmploymentIncome.CoBorrowerEmploymentInfo[0].ZipCode.Value.ToString() : "")
                     );
            }
            //PdfTextField BorrowerBusinessPhone = (PdfTextField)(form.Fields["Borrower Business phone"]);
            //BorrowerBusinessPhone.Value = new PdfString(data.PersonalInformation.Borrower.CellPhone.ToString());
            //"Borrower Mailing Address if different from Present",
            //"Borrower Former Own or Rent",
            //"Borrower No of Years Former Address",
            //"Borrower Former Address if different from Present",
            if (data.EmploymentIncome.BorrowerEmploymentInfo.Count >= 2)
            {
                // PdfTextField BorrowerEmploymentInfoContMonthlyIncome = (PdfTextField)(form.Fields["Borrower Employment info Cont monthly income of Employ"]);
                // BorrowerEmploymentInfoContMonthlyIncome.Value = new PdfString(data.EmploymentIncome.BorrowerEmploymentInfo[1].incom.ToString());

                PdfTextField BorrowerPostion1 = (PdfTextField)(form.Fields["Borrower Employment info Cont Dates of Employ"]);
                BorrowerPostion1.Value = new PdfString(
                    data.EmploymentIncome.BorrowerEmploymentInfo[1].Position
                    );
                PdfTextField BorrowerEmploymentDates = (PdfTextField)(form.Fields["Borrower Employment info Cont Dates of Employ"]);
                BorrowerEmploymentDates.Value = new PdfString(
                    data.EmploymentIncome.BorrowerEmploymentInfo[1].StartDate.Value.ToString() + " " +
                    data.EmploymentIncome.BorrowerEmploymentInfo[1].EndDate.Value.ToString()
                    );
                PdfTextField BorrowerEmploymentEmployerNameAndAddress = (PdfTextField)(form.Fields["Borrower Employment info Cont Name and adress of Employ"]);
                BorrowerEmploymentDates.Value = new PdfString(
                    data.EmploymentIncome.BorrowerEmploymentInfo[1].EmployerName + " " +
                    data.EmploymentIncome.BorrowerEmploymentInfo[1].Address1 + " "
                    + data.EmploymentIncome.BorrowerEmploymentInfo[1].City + " "
                   + (data.EmploymentIncome.BorrowerEmploymentInfo[1].StateId.HasValue ? _personalDetailService.GetStateId(data.EmploymentIncome.BorrowerEmploymentInfo[1].StateId.Value) : "") + " "
                    + (data.EmploymentIncome.BorrowerEmploymentInfo[1].ZipCode.HasValue ? data.EmploymentIncome.BorrowerEmploymentInfo[1].ZipCode.Value.ToString() : "")
                    );
            }
            if (data.EmploymentIncome.BorrowerEmploymentInfo.Count >= 3)
            {
                // PdfTextField BorrowerEmploymentInfoContMonthlyIncome = (PdfTextField)(form.Fields["Borrower Employment info Cont monthly income of Employ 2"]);
                // BorrowerEmploymentInfoContMonthlyIncome.Value = new PdfString(data.EmploymentIncome.BorrowerMonthlyIncome.ToString());

                PdfTextField BorrowerPostion1 = (PdfTextField)(form.Fields["Borrower Employment info Cont position title2"]);
                BorrowerPostion1.Value = new PdfString(
                    data.EmploymentIncome.BorrowerEmploymentInfo[2].Position
                    );
                PdfTextField BorrowerEmploymentDates1 = (PdfTextField)(form.Fields["Borrower Employment info Cont Dates of Employ 2"]);
                BorrowerEmploymentDates1.Value = new PdfString(
                    data.EmploymentIncome.BorrowerEmploymentInfo[2].StartDate.Value.ToString() + " " +
                    data.EmploymentIncome.BorrowerEmploymentInfo[2].EndDate.Value.ToString()
                    );
                PdfTextField BorrowerEmploymentEmployerNameAndAddress1 = (PdfTextField)(form.Fields["Borrower Employment info Cont Name and adress of Employ 2"]);
                BorrowerEmploymentEmployerNameAndAddress1.Value = new PdfString(
                    data.EmploymentIncome.BorrowerEmploymentInfo[2].EmployerName + " " +
                    data.EmploymentIncome.BorrowerEmploymentInfo[2].Address1 + " "
                    + data.EmploymentIncome.BorrowerEmploymentInfo[2].City + " "
                   + (data.EmploymentIncome.BorrowerEmploymentInfo[2].StateId.HasValue ? _personalDetailService.GetStateId(data.EmploymentIncome.BorrowerEmploymentInfo[2].StateId.Value) : "") + " "
                    + (data.EmploymentIncome.BorrowerEmploymentInfo[2].ZipCode.HasValue ? data.EmploymentIncome.BorrowerEmploymentInfo[2].ZipCode.Value.ToString() : "")
                    );
                // PdfTextField BorrowerEmploymentInfoContMonthlyIncome1 = (PdfTextField)(form.Fields["Borrower Employment info Cont monthly income of Employ 2"]);
                // BorrowerEmploymentInfoContMonthlyIncome1.Value = new PdfString(data.EmploymentIncome.BorrowerMonthlyIncome.ToString());
            }

            PdfTextField BorrowerMonthlyIncomeBonuses = (PdfTextField)(form.Fields["Monthly income Borrower Bonuses a1"]);
            BorrowerMonthlyIncomeBonuses.Value = new PdfString(data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.Value.ToString() : "");
            PdfTextField BorrowerMonthlyIncome = (PdfTextField)(form.Fields["Monthly income Borrower Base a"]);
            BorrowerMonthlyIncome.Value = new PdfString(data.EmploymentIncome.BorrowerMonthlyIncome.Base.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Base.Value.ToString() : "");
            PdfTextField BorrowerMonthlyCommissions = (PdfTextField)(form.Fields["Monthly income Borrower Commissions a5"]);
            BorrowerMonthlyIncome.Value = new PdfString(data.EmploymentIncome.BorrowerMonthlyIncome.Commissions.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Commissions.Value.ToString() : "");
            PdfTextField BorrowerMonthlyDividends = (PdfTextField)(form.Fields["Monthly income Borrower Dividends a10"]);
            BorrowerMonthlyDividends.Value = new PdfString(data.EmploymentIncome.BorrowerMonthlyIncome.Dividends.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Dividends.Value.ToString() : "");
            PdfTextField BorrowerMonthlyOvertime = (PdfTextField)(form.Fields["Monthly income Borrower Overtime 1"]);
            BorrowerMonthlyDividends.Value = new PdfString(data.EmploymentIncome.BorrowerMonthlyIncome.Overtime.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Overtime.Value.ToString() : "");
            //PdfTextField BorrowerMonthlyOtherIncome = (PdfTextField)(form.Fields["Monthly income Borrower Other a21"]);
            //BorrowerMonthlyOtherIncome.Value = new PdfString(data.EmploymentIncome.BorrowerMonthlyIncome.other.ToString());
            //PdfTextField BorrowerMonthlyRental = (PdfTextField)(form.Fields["Monthly income Borrower Net Rental income 16"]);
            //BorrowerMonthlyDividends.Value = new PdfString(data.EmploymentIncome.BorrowerMonthlyIncome.Overtime.ToString());
            PdfTextField BorrowerTotalMonthlyIncome = (PdfTextField)(form.Fields["Monthly income Borrower Total a29"]);
            BorrowerTotalMonthlyIncome.Value = new PdfString((
                (data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.Value : 0) +
                (data.EmploymentIncome.BorrowerMonthlyIncome.Base.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Base.Value : 0) +
                (data.EmploymentIncome.BorrowerMonthlyIncome.Commissions.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Commissions.Value : 0) +
                (data.EmploymentIncome.BorrowerMonthlyIncome.Dividends.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Dividends.Value : 0) +
                (data.EmploymentIncome.BorrowerMonthlyIncome.Overtime.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Overtime.Value : 0)).ToString()
                );
            if (data.EmploymentIncome.CoBorrowerMonthlyIncome != null)
            {
                PdfTextField CoBorrowerMonthlyIncomeBonuses = (PdfTextField)(form.Fields["Monthly income Co-Borrower Bonuses a2"]);
                CoBorrowerMonthlyIncomeBonuses.Value = new PdfString((data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Bonuses.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Bonuses.Value.ToString() : ""));
                PdfTextField CoBorrowerMonthlyIncome = (PdfTextField)(form.Fields["Monthly income Co-Borrower Base c"]);
                CoBorrowerMonthlyIncome.Value = new PdfString((data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Base.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Base.Value.ToString() : ""));
                PdfTextField CoBorrowerMonthlyCommissions = (PdfTextField)(form.Fields["Monthly income Co-Borrower Commissions a6"]);
                CoBorrowerMonthlyCommissions.Value = new PdfString((data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Commissions.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Commissions.Value.ToString() : ""));
                PdfTextField CoBorrowerMonthlyDividends = (PdfTextField)(form.Fields["Monthly income Co-Borrower Dividends/Interest a11"]);
                CoBorrowerMonthlyDividends.Value = new PdfString((data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Dividends.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Dividends.Value.ToString() : ""));
                PdfTextField CoBorrowerMonthlyOvertime = (PdfTextField)(form.Fields["Monthly income Co-Borrower Overtime 2"]);
                CoBorrowerMonthlyOvertime.Value = new PdfString((data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Overtime.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Overtime.Value.ToString() : ""));
                //PdfTextField BorrowerMonthlyOtherIncome = (PdfTextField)(form.Fields["Monthly income Borrower Other a21"]);
                //BorrowerMonthlyOtherIncome.Value = new PdfString(data.EmploymentIncome.CoBorrowerEmploymentInfo.other.ToString());
                //PdfTextField BorrowerMonthlyRental = (PdfTextField)(form.Fields["Monthly income Borrower Net Rental income 16"]);
                //BorrowerMonthlyDividends.Value = new PdfString(data.EmploymentIncome.CoBorrowerEmploymentInfo.Overtime.ToString());
                PdfTextField CoBorrowerTotalMonthlyIncome = (PdfTextField)(form.Fields["Monthly income Co-Borrower Total a30"]);
                CoBorrowerTotalMonthlyIncome.Value = new PdfString((
                    (data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Bonuses.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Bonuses.Value : 0) +
                    (data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Base.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Base.Value : 0) +
                    (data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Commissions.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Commissions.Value : 0) +
                    (data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Dividends.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Dividends.Value : 0) +
                    (data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Overtime.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Overtime.Value : 0)).ToString()
                    );

            }
            PdfTextField CoBorrowerMonthlyIncomeBonusesTotal = (PdfTextField)(form.Fields["Monthly income Borrower Bonuses Total a3"]);
            CoBorrowerMonthlyIncomeBonusesTotal.Value = new PdfString(
                (((data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Bonuses.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Bonuses.Value : 0)
                +
                (data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.Value : 0))).ToString());
            PdfTextField CoBorrowerMonthlyIncomeTotal = (PdfTextField)(form.Fields["Monthly income Borrower Total c"]);
            CoBorrowerMonthlyIncomeTotal.Value = new PdfString(
                 (((data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Bonuses.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Bonuses.Value : 0)
                +
                (data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.Value : 0))).ToString());

            PdfTextField CoBorrowerMonthlyCommissionsTotal = (PdfTextField)(form.Fields["Monthly income Borrower Commissions Total a7"]);
            CoBorrowerMonthlyCommissionsTotal.Value = new PdfString(
                ((data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Commissions.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Commissions.Value : 0)
                +
                data.EmploymentIncome.BorrowerMonthlyIncome.Commissions).ToString());
            PdfTextField CoBorrowerMonthlyDividendsTotal = (PdfTextField)(form.Fields["Monthly income Borrower Dividens/Interest Total a13"]);
            CoBorrowerMonthlyDividendsTotal.Value = new PdfString((
                ((data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Bonuses.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Bonuses.Value : 0)
                +
                (data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.Value : 0))).ToString());
            PdfTextField CoBorrowerMonthlyOvertimeTotal = (PdfTextField)(form.Fields["Monthly income Borrower Overtime Total 1"]);
            CoBorrowerMonthlyOvertimeTotal.Value = new PdfString(
                (((data.EmploymentIncome.CoBorrowerMonthlyIncome != null && data.EmploymentIncome.CoBorrowerMonthlyIncome.Bonuses.HasValue ? data.EmploymentIncome.CoBorrowerMonthlyIncome.Bonuses.Value : 0)
                +
                (data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.Value : 0))).ToString());
            //PdfTextField BorrowerMonthlyOtherIncome = (PdfTextField)(form.Fields["Monthly income Borrower Other Total a24"]);
            //BorrowerMonthlyOtherIncome.Value = new PdfString(data.EmploymentIncome.CoBorrowerEmploymentInfo.other.ToString());
            //PdfTextField BorrowerMonthlyRental = (PdfTextField)(form.Fields["Monthly income Borrower Net Rental Income Total a18"]);
            //BorrowerMonthlyDividends.Value = new PdfString(data.EmploymentIncome.CoBorrowerEmploymentInfo.Overtime.ToString());

            PdfTextField BorrowerTotalIncomeTotal = (PdfTextField)(form.Fields["Monthly income Borrower Total Total a31"]);
            BorrowerTotalIncomeTotal.Value = new PdfString((
                (
                (data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.Value : 0) +
                (data.EmploymentIncome.BorrowerMonthlyIncome.Base.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Base.Value : 0) +
                (data.EmploymentIncome.BorrowerMonthlyIncome.Commissions.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Commissions.Value : 0) +
                (data.EmploymentIncome.BorrowerMonthlyIncome.Dividends.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Dividends.Value : 0) +
                (data.EmploymentIncome.BorrowerMonthlyIncome.Overtime.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Overtime.Value : 0)) +
                (
                (data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Bonuses.Value : 0) +
                (data.EmploymentIncome.BorrowerMonthlyIncome.Base.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Base.Value : 0) +
                (data.EmploymentIncome.BorrowerMonthlyIncome.Commissions.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Commissions.Value : 0) +
                (data.EmploymentIncome.BorrowerMonthlyIncome.Dividends.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Dividends.Value : 0) +
                (data.EmploymentIncome.BorrowerMonthlyIncome.Overtime.HasValue ? data.EmploymentIncome.BorrowerMonthlyIncome.Overtime.Value : 0))
                ).ToString());

            PdfTextField rent = (PdfTextField)(form.Fields["Combined Monthly Housing Expense Rent Present a"]);
            rent.Value = new PdfString(data.Expenses.Rent.HasValue ? data.Expenses.Rent.Value.ToString() : "");

            PdfTextField monthlyExpense = (PdfTextField)(form.Fields["Combined Monthly Housing Expense First M 1"]);
            monthlyExpense.Value = new PdfString(data.Expenses.OtherHousingExpenses.HasValue ? data.Expenses.OtherHousingExpenses.Value.ToString() : "");


            PdfTextField FirstMortgage = (PdfTextField)(form.Fields["Combined Monthly Housing Expense First M Proposed 2"]);
            FirstMortgage.Value = new PdfString(data.Expenses.FirstMortgage.HasValue ? data.Expenses.FirstMortgage.Value.ToString() : "".ToString());

            //PdfTextField Other = (PdfTextField)(form.Fields["Combined Monthly Housing Expense there Financing Proposed a4"]);
            //Other.Value = new PdfString(data.Expenses.OtherHousingExpenses.ToString());

            PdfTextField HazardInsurance = (PdfTextField)(form.Fields["Combined Monthly Housing Expense there Financing Proposed a9"]);
            HazardInsurance.Value = new PdfString(data.Expenses.HazardInsurance.HasValue ? data.Expenses.HazardInsurance.Value.ToString() : "".ToString());

            PdfTextField RealEstateTaxes = (PdfTextField)(form.Fields["Combined Monthly Housing Expense Real Estate Taxes Proposed a15"]);
            RealEstateTaxes.Value = new PdfString(data.Expenses.RealEstateTaxes.HasValue ? data.Expenses.RealEstateTaxes.Value.ToString() : "".ToString());

            PdfTextField MortgageInsurance = (PdfTextField)(form.Fields["Combined Monthly Housing Expense Mortgage Insurance Proposed a20"]);
            MortgageInsurance.Value = new PdfString(data.Expenses.MortgageInsurance.HasValue ? data.Expenses.MortgageInsurance.Value.ToString() : "".ToString());

            PdfTextField HomeOwnersAssociation = (PdfTextField)(form.Fields["Combined Monthly Housing Expense Other Proposed a28"]);
            HomeOwnersAssociation.Value = new PdfString(data.Expenses.HomeOwnersAssociation.HasValue ? data.Expenses.HomeOwnersAssociation.Value.ToString() : "".ToString());

            PdfTextField TotalExpense = (PdfTextField)(form.Fields["Combined Monthly Housing Expense Total Proposed a33"]);
            TotalExpense.Value = new PdfString((
                (data.Expenses.FirstMortgage.HasValue ? data.Expenses.FirstMortgage.Value : 0) +
                 (data.Expenses.OtherHousingExpenses.HasValue ? data.Expenses.OtherHousingExpenses.Value : 0) +
                 (data.Expenses.HazardInsurance.HasValue ? data.Expenses.HazardInsurance.Value : 0) +
                  (data.Expenses.OtherHousingExpenses.HasValue ? data.Expenses.OtherHousingExpenses.Value : 0) +
                   (data.Expenses.MortgageInsurance.HasValue ? data.Expenses.OtherHousingExpenses.Value : 0) +
                   (data.Expenses.RealEstateTaxes.HasValue ? data.Expenses.RealEstateTaxes.Value : 0).ToString()));

            if (data.EmploymentIncome.AdditionalIncomes != null && data.EmploymentIncome.AdditionalIncomes.Count >= 1)
            {
                PdfTextField AddtionalIcomenumber1 = (PdfTextField)(form.Fields["Text3"]);
                AddtionalIcomenumber1.Value = new PdfString("1");
                //PdfTextField AddtionalIncome1Source = (PdfTextField)(form.Fields["Describe other income 1"]);
                //AddtionalIncome1Source.Value = new PdfString(data.EmploymentIncome.AdditionalIncomes[0].IncomeSourceId);
                PdfTextField AddtionalIcomenumber1income = (PdfTextField)(form.Fields["Describe other income 1 Monthy Amount"]);
                AddtionalIcomenumber1income.Value = new PdfString(
                    data.EmploymentIncome.AdditionalIncomes[0].Amount.HasValue ? data.EmploymentIncome.AdditionalIncomes[0].Amount.Value.ToString() : "");
            }
            if (data.EmploymentIncome.AdditionalIncomes != null && data.EmploymentIncome.AdditionalIncomes.Count >= 2)
            {
                PdfTextField AddtionalIcomenumber1 = (PdfTextField)(form.Fields["Text8"]);
                AddtionalIcomenumber1.Value = new PdfString("1");
                //PdfTextField AddtionalIncome1Source = (PdfTextField)(form.Fields["Describe other income 2"]);
                //AddtionalIncome1Source.Value = new PdfString(data.EmploymentIncome.AdditionalIncomes[0].IncomeSourceId);
                PdfTextField AddtionalIcomenumber1income = (PdfTextField)(form.Fields["Describe other income 2 Monthy Amount"]);
                AddtionalIcomenumber1income.Value = new PdfString(
                    data.EmploymentIncome.AdditionalIncomes[1].Amount.HasValue ? data.EmploymentIncome.AdditionalIncomes[1].Amount.Value.ToString() : "");
            }
            if (data.EmploymentIncome.AdditionalIncomes != null && data.EmploymentIncome.AdditionalIncomes.Count >= 3)
            {
                PdfTextField AddtionalIcomenumber1 = (PdfTextField)(form.Fields["Text9"]);
                AddtionalIcomenumber1.Value = new PdfString("2");
                //PdfTextField AddtionalIncome1Source = (PdfTextField)(form.Fields["Describe other income 3"]);
                //AddtionalIncome1Source.Value = new PdfString(data.EmploymentIncome.AdditionalIncomes[1].IncomeSourceId);
                PdfTextField AddtionalIcomenumber1income = (PdfTextField)(form.Fields["Monthly Amount Total"]);
                AddtionalIcomenumber1income.Value = new PdfString(
                    data.EmploymentIncome.AdditionalIncomes[2].Amount.HasValue ? data.EmploymentIncome.AdditionalIncomes[2].Amount.Value.ToString() : "");
            }

            //assets
            data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).Count();
            if (data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).Count() >= 1)
            {
                PdfTextField AddtionalIcomenumber1 = (PdfTextField)(form.Fields["S,PS or Ra"]);
                AddtionalIcomenumber1.Value = new PdfString(
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].Address + " " +
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].City + " " +
                    _personalDetailService.GetStateId(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].StateId)
                    );
                PdfTextField TypeOfProperty1 = (PdfTextField)(form.Fields["Type of Propertya"]);
                TypeOfProperty1.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].PropertyType);

                PdfTextField PresentMarketValue1 = (PdfTextField)(form.Fields["Owned Real Estate Address 1 Market Value"]);
                PresentMarketValue1.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].PresentMarketValue.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].PresentMarketValue.Value.ToString() : "");
                PdfTextField OutstandingMortgageBalance1 = (PdfTextField)(form.Fields["Owned Real Estate Address 1 Amount of Mortgages Liens"]);
                OutstandingMortgageBalance1.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].OutstandingMortgageBalance.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].OutstandingMortgageBalance.Value.ToString() : "");
                PdfTextField GrossRentalIncome1 = (PdfTextField)(form.Fields["Owned Real Estate Address 1 Gross Rental Income"]);
                GrossRentalIncome1.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].GrossRentalIncome.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].GrossRentalIncome.Value.ToString() : "");
                PdfTextField MonthlyMortgagePayment1 = (PdfTextField)(form.Fields["Owned Real Estate Address 1 Mortage Payments"]);
                MonthlyMortgagePayment1.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].MonthlyMortgagePayment.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].MonthlyMortgagePayment.Value.ToString() : "");
                PdfTextField TaxesInsuranceAndOther1 = (PdfTextField)(form.Fields["Owned Real Estate Address 1 Insurance Maintenance Taxes"]);
                TaxesInsuranceAndOther1.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].TaxesInsuranceAndOther.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].TaxesInsuranceAndOther.Value.ToString() : "");
                //PdfTextField GrossRentalIncome1 = (PdfTextField)(form.Fields["Owned Real Estate Address 1 Net Rental Income a"]);
                //GrossRentalIncome1.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0]..ToString());
            }
            if (data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).Count() >= 2)
            {
                PdfTextField AddtionalIcomenumber = (PdfTextField)(form.Fields["Owned Real Estate Address 1a"]);
                AddtionalIcomenumber.Value = new PdfString(
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[1].Address + " " +
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[1].City + " " +
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[1].StateId
                    );
                PdfTextField TypeOfProperty2 = (PdfTextField)(form.Fields["Type of Property 2"]);
                TypeOfProperty2.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[1].PropertyType);
                PdfTextField TypeOfProperty1 = (PdfTextField)(form.Fields["Type of Propertya"]);
                TypeOfProperty1.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[1].PropertyType);

                PdfTextField PresentMarketValue2 = (PdfTextField)(form.Fields["Owned Real Estate Address 2  Market Value"]);
                PresentMarketValue2.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[1].PresentMarketValue.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[1].PresentMarketValue.Value.ToString() : "");
                PdfTextField OutstandingMortgageBalance2 = (PdfTextField)(form.Fields["Owned Real Estate Address 2  Amount of Mortgages Liens"]);
                OutstandingMortgageBalance2.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[1].OutstandingMortgageBalance.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[1].OutstandingMortgageBalance.Value.ToString() : "");
                PdfTextField GrossRentalIncome2 = (PdfTextField)(form.Fields["Owned Real Estate Address 2 Gross Rental Income"]);
                GrossRentalIncome2.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].GrossRentalIncome.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].GrossRentalIncome.Value.ToString() : "");
                PdfTextField MonthlyMortgagePayment2 = (PdfTextField)(form.Fields["Owned Real Estate Address 2 Mortage Payments"]);
                MonthlyMortgagePayment2.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].MonthlyMortgagePayment.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].MonthlyMortgagePayment.Value.ToString() : "");
                PdfTextField TaxesInsuranceAndOther2 = (PdfTextField)(form.Fields["Owned Real Estate Address 2 Insurance Maintenance Taxes"]);
                TaxesInsuranceAndOther2.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].TaxesInsuranceAndOther.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0].TaxesInsuranceAndOther.Value.ToString() : "");
                //PdfTextField GrossRentalIncome1 = (PdfTextField)(form.Fields["Owned Real Estate Address 1 Net Rental Income a"]);
                //GrossRentalIncome1.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0]..ToString());
            }
            if (data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).Count() >= 3)
            {
                PdfTextField AddtionalIcomenumber1 = (PdfTextField)(form.Fields["Owned Real Estate Address 3a"]);
                AddtionalIcomenumber1.Value = new PdfString(
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].Address + " " +
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].City + " " +
                    data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].StateId
                    );
                PdfTextField TypeOfProperty1 = (PdfTextField)(form.Fields["Type of Propertya"]);
                TypeOfProperty1.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].PresentMarketValue.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].PresentMarketValue.Value.ToString() : "");

                PdfTextField PresentMarketValue3 = (PdfTextField)(form.Fields["Owned Real Estate Address 3 Market Value"]);
                PresentMarketValue3.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].PresentMarketValue.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].PresentMarketValue.Value.ToString() : "");
                PdfTextField OutstandingMortgageBalance3 = (PdfTextField)(form.Fields["Owned Real Estate Address 3 Amount of Mortgages Liens"]);
                OutstandingMortgageBalance3.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].OutstandingMortgageBalance.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].OutstandingMortgageBalance.Value.ToString() : "");
                PdfTextField GrossRentalIncome3 = (PdfTextField)(form.Fields["Owned Real Estate Address 3 Gross Rental Income"]);
                GrossRentalIncome3.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].GrossRentalIncome.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].GrossRentalIncome.Value.ToString() : "");
                PdfTextField MonthlyMortgagePayment3 = (PdfTextField)(form.Fields["Owned Real Estate Address 3 Mortage Payments"]);
                MonthlyMortgagePayment3.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].MonthlyMortgagePayment.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].MonthlyMortgagePayment.Value.ToString() : "");
                PdfTextField TaxesInsuranceAndOther3 = (PdfTextField)(form.Fields["Owned Real Estate Address 3 Insurance Maintenance Taxes"]);
                TaxesInsuranceAndOther3.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].TaxesInsuranceAndOther.HasValue ? data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[2].TaxesInsuranceAndOther.Value.ToString() : "");
                //PdfTextField GrossRentalIncome1 = (PdfTextField)(form.Fields["Owned Real Estate Address 1 Net Rental Income a"]);
                //GrossRentalIncome1.Value = new PdfString(data.ManualAssetEntries.Where(i => i.AssetTypeId == 9).ToList()[0]..ToString());
            }


            //PdfTextField BorrowerJudgementsAgainst = (PdfTextField)(form.Fields["Borrower Judgements against"]);
            //BorrowerJudgementsAgainst.Value = new PdfString(data.Declaration.BorrowerDeclaration.IsOutstandingJudgmentsAgainstYou);
            //PdfTextField CoBorrowerJudgementsAgainst = (PdfTextField)(form.Fields["Co-Borrower Judgements against"]);
            //CoBorrowerJudgementsAgainst.Value = new PdfString(data.Declaration.CoBorrowerDeclaration.IsOutstandingJudgmentsAgainstYou);
            //PdfTextField BorrowerBankrupt = (PdfTextField)(form.Fields["Borrower Bankrupt"]);
            //BorrowerBankrupt.Value = new PdfString(data.Declaration.BorrowerDeclaration.IsDeclaredBankrupt);
            //PdfTextField CoBorrowerBankrupt = (PdfTextField)(form.Fields["Co-Borrower Bankrupt y"]);
            //CoBorrowerBankrupt.Value = new PdfString(data.Declaration.CoBorrowerDeclaration.IsDeclaredBankrupt);
            //PdfTextField BorrowerIsPropertyForeClosedUponOrGivenTitle = (PdfTextField)(form.Fields["Check Box"]);
            //BorrowerIsPropertyForeClosedUponOrGivenTitle.Value = new PdfString(data.Declaration.BorrowerDeclaration.BorrowerIsPropertyForeClosedUponOrGivenTitle);
            //PdfTextField CoBorrowerIsPropertyForeClosedUponOrGivenTitle = (PdfTextField)(form.Fields["Co-Borrower Forclose y"]);
            //CoBorrowerIsPropertyForeClosedUponOrGivenTitle.Value = new PdfString(data.Declaration.CoBorrowerDeclaration.IsPropertyForeClosedUponOrGivenTitle);
            //PdfTextField BorrowerIsPartyToLawsuit = (PdfTextField)(form.Fields["Borrower Lawsuit"]);
            //BorrowerIsPartyToLawsuit.Value = new PdfString(data.Declaration.BorrowerDeclaration.IsPartyToLawsuit);
            //PdfTextField CoBorrowerIsPartyToLawsuit = (PdfTextField)(form.Fields["Co-Borrower Lawsuit y"]);
            //CoBorrowerIsPartyToLawsuit.Value = new PdfString(data.Declaration.CoBorrowerDeclaration.IsPartyToLawsuit);
            //PdfTextField BorrowerIsPartyToLawsuit = (PdfTextField)(form.Fields["Borrower Liability"]);
            //BorrowerIsPartyToLawsuit.Value = new PdfString(data.Declaration.BorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure);
            //PdfTextField CoBorrowerIsObligatedOnAnyLoanWhichResultedForeclosure = (PdfTextField)(form.Fields["Co-Borrower Liability y"]);
            //CoBorrowerIsObligatedOnAnyLoanWhichResultedForeclosure.Value = new PdfString(data.Declaration.CoBorrowerDeclaration.IsObligatedOnAnyLoanWhichResultedForeclosure);





            myTemplate.Save("1003irev-unlocked-2.pdf");
            //Console.WriteLine("Hello World!");
            //System.IO.File.WriteAllText(@"names.json", JsonSerializer.Serialize(names));
            myTemplate.Close();
        }


    }
}
