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
                mailMessage.To.Add(new MailAddress("wmartin@ezonlinemortgage.com"));
                mailMessage.From = new MailAddress("shabir.abdulmajeed786@gmail.com");
                mailMessage.Subject = "Home Buying Loan Options New Lead";

                var doc = new Document();
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
                var FontRed = FontFactory.GetFont("Arial", 13, BaseColor.Red);
                var Heading = FontFactory.GetFont("Arial", 20, BaseColor.Black);
                doc.Open();
                Paragraph preface = new Paragraph("Home Buying Loan Options", Heading);
                preface.Alignment = Element.ALIGN_CENTER;
                doc.Add(preface);
                doc.Add(new Paragraph("Question: Tell us how you’re using this property?"));
                doc.Add(new Paragraph("Answer: " + input.PropertyUse,FontRed));

                doc.Add(new Paragraph("Question: Now, what type of property is it? "));
                doc.Add(new Paragraph("Answer: " + input.propertyType, FontRed));

                doc.Add(new Paragraph("Question: what’s the zip code?"));
                doc.Add(new Paragraph("Answer: " + input.zipCode, FontRed));

                doc.Add(new Paragraph("Question: Now, approximately how long do you plan to own the property ?"));
                doc.Add(new Paragraph("Answer: " + input.howLongPlan, FontRed));

                doc.Add(new Paragraph("Question: we’ll need an estimated purchase and down payment?"));
                doc.Add(new Paragraph("Answer: " + input.estimatePrice, FontRed));

                doc.Add(new Paragraph("Question: we’ll need a down payment?"));
                doc.Add(new Paragraph("Answer: " + input.downPayment, FontRed));

                doc.Add(new Paragraph("Question: What's the percentage of down payment?"));
                doc.Add(new Paragraph("Answer: " + input.downPaymentPercent, FontRed));

                doc.Add(new Paragraph("Question: First time homebuyer?"));
                doc.Add(new Paragraph("Answer: " + input.FirstTimeHomeBuying, FontRed));

                doc.Add(new Paragraph("Question: Have you or your spouse ever served in the military?"));
                doc.Add(new Paragraph("Answer: " + input.militarySevice, FontRed));

                doc.Add(new Paragraph("Question: To the best of your knowledge, what’s most important to you?"));
                doc.Add(new Paragraph("Question: Answer: " + input.important_to_you, FontRed));

                doc.Add(new Paragraph("Question: Now what’s your credit score? An estimate is fine.?"));
                doc.Add(new Paragraph("Answer: " + input.rateCredit, FontRed));

                doc.Add(new Paragraph("Question: Currently working with a loan officer?"));
                doc.Add(new Paragraph("Answer: " + input.workingWithLoanOfficer, FontRed));

                doc.Add(new Paragraph("Question: OK here are your personalized GRaffordability results page 11 ?"));
                doc.Add(new Paragraph("Answer: " + input.plan_page11, FontRed));

                doc.Add(new Paragraph("Question: OK here are your personalized GRaffordability results page12 ?"));
                doc.Add(new Paragraph("Answer: " + input.plan_page12, FontRed));

                doc.Add(new Paragraph("Question: First Name?"));
                doc.Add(new Paragraph("Answer: " + input.firstName, FontRed));

                doc.Add(new Paragraph("Question: Last Name?"));
                doc.Add(new Paragraph("Answer: " + input.lastName, FontRed));

                doc.Add(new Paragraph("Question: Email Address?"));
                doc.Add(new Paragraph("Answer: " + input.emailAddress, FontRed));

                doc.Add(new Paragraph("Question: Mobile Phone Number?"));
                doc.Add(new Paragraph("Answer: " + input.phoneNumber, FontRed));

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
