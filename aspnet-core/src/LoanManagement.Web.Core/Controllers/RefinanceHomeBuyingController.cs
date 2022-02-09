using System;
using Abp.Runtime.Validation;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.ViewModels;

namespace LoanManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RefinanceHomeBuyingController : LoanManagementControllerBase
    {
        private readonly SmtpClient _smtpClient;
        private readonly IRefinanceHomeBuyingService _refinanceHomeBuyingService;
        public RefinanceHomeBuyingController(SmtpClient smtpClient, IRefinanceHomeBuyingService refinanceHomeBuyingService)
        {
            _smtpClient = smtpClient;
            _refinanceHomeBuyingService = refinanceHomeBuyingService;
        }

        [DisableValidation]
        [HttpPost]
        public async Task<IActionResult> AddRefinance([FromBody] RefinanceHomeBuyingDto input)
        {
            try
            {
                if (input == null || !ModelState.IsValid)
                    return BadRequest(ModelState);

                //if (!input.Id.HasValue || input.Id.Value == default)
                //{
                    input = await _refinanceHomeBuyingService.CreateAsync(input);
                //}

                //await _loanAppService.UpdateAsync(input);

                var mailMessage = new MailMessage();
                // mailMessage.To.Add(new MailAddress("wmartin@ezonlinemortgage.com"));
                mailMessage.To.Add(new MailAddress("shabir.abdulmajeed786@gmail.com"));
                mailMessage.From = new MailAddress("loanapplicationmail@gmail.com");
                mailMessage.Subject = "Refinance Home Buying Funnel Form New Lead";

                var doc = new Document();
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
                var FontRed = FontFactory.GetFont("Arial", 13, BaseColor.Red);
                var FontBlack = FontFactory.GetFont("Arial", 13, BaseColor.Black);
                var Answer = new Chunk("Answer: ", FontBlack);

                var Heading = FontFactory.GetFont("Arial", 20, BaseColor.Black);
                doc.Open();
                Paragraph preface = new Paragraph("Refinance Home Buying Funnel Form", Heading);
                preface.Alignment = Element.ALIGN_CENTER;
                doc.Add(preface);
                doc.Add(new Paragraph("Question: What state is the property located in?"));
                var phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.propertyLocated, FontRed));
                doc.Add(phrase);


                doc.Add(new Paragraph("Question: What type of home are you refinancing?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.propertyType, FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: How will your property be used?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.PropertyUse, FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: Why do you want to refinance?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.WantRefinance, FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: What's your home's value?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.HomePrice.ToString(), FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: How much do you owe?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.Owe.ToString(), FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: How much cash do you want to borrow?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.CashBorrow.ToString(), FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: Do you currently have an FHA loan?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.FHALoan, FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: Active or previous U.S military sevice?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.militarySevice?"Yes":"No", FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: Any foreclosure in the past 2 years?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.foreclosurePastTwoYears?"Yes":"No", FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: Any bankruptcy in the past 3 years?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.bankruptcyPastThreeYears?"Yes":"No", FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: Number of late mortgage payments in the last 12 months?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.LateMortgagePayments, FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: Are you currently employed?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.currentEmployed, FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: What is your gross annual household income?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.houseHoldIncome, FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: Can you show proof of income?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.proofOfincome?"Yes":"No", FontRed));
                doc.Add(phrase);

                doc.Add(new Paragraph("Question: How would you rate your credit?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.rateCredit, FontRed));
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

                doc.Add(new Paragraph("Question: Reffered By?"));
                phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.refferedBy, FontRed));
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
