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
                mailMessage.To.Add(new MailAddress("shabir.abdulmajeed786@gmail.com"));
                mailMessage.From = new MailAddress("loanapplicationmail@gmail.com");
                mailMessage.Subject = "Home Buying Loan Options New Lead";

                var doc = new Document();
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
                var FontRed = FontFactory.GetFont("Arial", 13, BaseColor.Red);
                var FontBlack = FontFactory.GetFont("Arial", 13, BaseColor.Black);
                var Answer = new Chunk("Answer: ", FontBlack);

                var Heading = FontFactory.GetFont("Arial", 20, BaseColor.Black);
                doc.Open();
                Paragraph preface = new Paragraph("Home Buying Loan Options", Heading);
                preface.Alignment = Element.ALIGN_CENTER;
                doc.Add(preface);
                doc.Add(new Paragraph("Question: Tell us how you’re using this property?"));
                var phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.PropertyUse, FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: Now, what type of property is it? "));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.propertyType, FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: what’s the zip code?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.zipCode, FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: Now, approximately how long do you plan to own the property ?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.howLongPlan, FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: we’ll need an estimated purchase and down payment?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.estimatePrice.ToString(), FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: we’ll need a down payment?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.downPayment.ToString(), FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: What's the percentage of down payment?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.downPaymentPercent.ToString(), FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: First time homebuyer?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.FirstTimeHomeBuying?"Yes":"No", FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: Have you or your spouse ever served in the military?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.militarySevice?"Yes":"No", FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: To the best of your knowledge, what’s most important to you?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.important_to_you, FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: Now what’s your credit score? An estimate is fine.?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.rateCredit, FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: Currently working with a loan officer?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.workingWithLoanOfficer?"Yes":"No", FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: OK here are your personalized GRaffordability results page 11 ?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.plan_page11, FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: OK here are your personalized GRaffordability results page12 ?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.plan_page12, FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: First Name?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.firstName, FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: Last Name?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.lastName, FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: Email Address?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.emailAddress, FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: Mobile Phone Number?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.phoneNumber, FontRed));
                doc.Add(phrase);

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
