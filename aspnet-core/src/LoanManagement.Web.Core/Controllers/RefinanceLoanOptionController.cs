using System;
using System.Collections.Generic;
using System.Text;
using Abp.Runtime.Validation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LoanManagement.Models;
using System.Net.Mail;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace LoanManagement.Controllers
{

    [Route("api/[controller]/[action]")]
    public class RefinanceLoanOptionController : LoanManagementControllerBase
    {
        private readonly SmtpClient _smtpClient;
        public RefinanceLoanOptionController(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        [DisableValidation]
        [HttpPost]
        public async Task<IActionResult> AddRefinanceLoanOption([FromBody] RefinanceLoanOption input)
        {
            try
            {
                if (input == null || !ModelState.IsValid)
                    return BadRequest(ModelState);

                //if (!input.Id.HasValue || input.Id.Value == default)
                //{
                //    input = await _loanAppService.CreateAsync(input);
                //}

                //await _loanAppService.UpdateAsync(input);

                var mailMessage = new MailMessage();
                mailMessage.To.Add(new MailAddress("wmartin@ezonlinemortgage.com"));
                mailMessage.From = new MailAddress("shabir.abdulmajeed786@gmail.com");
                mailMessage.Subject = "Loan Management Application New Lead";

                var doc = new Document();
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);

                doc.Open();
                Paragraph preface = new Paragraph("Refinance Home Buying Loan Options");
                preface.Alignment = Element.ALIGN_CENTER;
                doc.Add(preface);
                doc.Add(new Paragraph("To the best of your knowledge, what’s most important to you? Answer: " + input.important_to_you));
                doc.Add(new Paragraph("Great! Tell us how you’re using this property? Answer: " + input.PropertyUse));
                doc.Add(new Paragraph("Now, what type of property is it? Answer: " + input.propertyType));
                doc.Add(new Paragraph("what’s the zip code? Answer: " + input.zipCode));
                doc.Add(new Paragraph("so what’s the estimated property value?? Answer: " + input.estimatePrice));
                doc.Add(new Paragraph("Now what’s the remaining balance of your mortgage? Answer: " + input.remainingBalalnce));
                doc.Add(new Paragraph("Now, do you have any other loans for this property? Answer: " + input.haveAnyOtherLoanForThisProperty));
                doc.Add(new Paragraph("OK, so is the loan a home equity line of credit? Answer: " + input.loanHomeEquity));
                doc.Add(new Paragraph("Are you looking to pay that off? Answer: " + input.payThatOff));
                doc.Add(new Paragraph("What is the balance of your Home Equity Line of Credit? Answer: " + input.balanceOfHomeEquity));
                doc.Add(new Paragraph("Great.Now, was your home equity line of credit used when you purchased the home? Answer: " + input.homeEquityPurchase));
                doc.Add(new Paragraph("Would you like to borrow additional cash? Answer: " + input.borrowAdditionalCash));
                doc.Add(new Paragraph("Now, approximately how long do you plan to own the property ? Answer: " + input.howLongPlan));
                doc.Add(new Paragraph("Have you or your spouse ever served in the military? Answer: " + input.militarySevice));
                doc.Add(new Paragraph("Now what’s your credit score? An estimate is fine.? Answer: " + input.rateCredit));
                doc.Add(new Paragraph("Currently working with a loan officer? Answer: " + input.workingWithLoanOfficer));
                doc.Add(new Paragraph("Tell us her or his name.? Answer: " + input.officerName));
                doc.Add(new Paragraph("First Name? Answer: " + input.firstName));
                doc.Add(new Paragraph("Last Name? Answer: " + input.lastName));
                doc.Add(new Paragraph("Email Address? Answer: " + input.emailAddress));
                doc.Add(new Paragraph("Mobile Phone Number? Answer: " + input.phoneNumber));
                writer.CloseStream = false;
                doc.Close();
                memoryStream.Position = 0;

                var attachment = new Attachment(memoryStream, input.firstName + ".pdf");
                mailMessage.Attachments.Add(attachment);
                _smtpClient.Send(mailMessage); // _smtpClient will be disposed by container

                return new OkResult();
                //  return Json(input);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
