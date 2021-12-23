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
    public class LoanOptionHomeBuyingController : LoanManagementControllerBase
    {
        private readonly SmtpClient _smtpClient;
        public LoanOptionHomeBuyingController(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        [DisableValidation]
        [HttpPost]
        public async Task<IActionResult> AddLoanOption([FromBody] LoanOptionHomeBuying input)
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
                mailMessage.To.Add(new MailAddress("aqeel.abdulmajeed786@gmail.com"));
                mailMessage.From = new MailAddress("shabir.abdulmajeed786@gmail.com");
                mailMessage.Subject = "Loan Management Application New Lead";

                var doc = new Document();
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);

                doc.Open();
                doc.Add(new Paragraph("Tell us how you’re using this property.? Answer: " + input.PropertyUse));
                doc.Add(new Paragraph("Now, what type of property is it? Answer: " + input.propertyType));
                doc.Add(new Paragraph("what’s the zip? Answer: " + input.zipCode));
                doc.Add(new Paragraph("Now, approximately how long do you plan to own the property ? Answer: " + input.howLongPlan));
                doc.Add(new Paragraph("we’ll need an estimated purchase and down payment? Answer: " + input.estimatePrice));
                doc.Add(new Paragraph("we’ll need a down payment? Answer: " + input.downPayment));
                doc.Add(new Paragraph("What's the percentage of down payment? Answer: " + input.downPaymentPercent + '%'));
                doc.Add(new Paragraph("First time homebuyer? Answer: " + input.FirstTimeHomeBuying));
                doc.Add(new Paragraph("Have you or your spouse ever served in the military? Answer: " + input.militarySevice));
                doc.Add(new Paragraph("To the best of your knowledge, what’s most important to you? Answer: " + input.important_to_you));
                doc.Add(new Paragraph("Now what’s your credit score? An estimate is fine.? Answer: " + input.rateCredit));
                doc.Add(new Paragraph("Currently working with a loan officer? Answer: " + input.workingWithLoanOfficer));
                doc.Add(new Paragraph("OK here are your personalized GRaffordability results page 11 ? Answer: " + input.plan_page11));
                doc.Add(new Paragraph("OK here are your personalized GRaffordability results page12 ? Answer: " + input.plan_page12));
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
