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
using System.Drawing;

namespace LoanManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HomeBuyingController : LoanManagementControllerBase
    {
        private readonly SmtpClient _smtpClient;
        private readonly IHomeBuyingService _homeBuyingService;
        public HomeBuyingController(SmtpClient smtpClient,IHomeBuyingService homeBuyingService)
        {
            _smtpClient = smtpClient;
            _homeBuyingService = homeBuyingService;
        }

        [DisableValidation]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BuyingHomeDto input)
        {
            try
            {
                if (input == null || !ModelState.IsValid)
                    return BadRequest(ModelState);

               // if (!input.Id.HasValue || input.Id.Value == default)
               // {
                    await _homeBuyingService.CreateAsync(input);
               // }

                var mailMessage = new MailMessage();
                mailMessage.To.Add(new MailAddress("wmartin@ezonlinemortgage.com"));
                mailMessage.From = new MailAddress("shabir.abdulmajeed786@gmail.com");
                mailMessage.Subject = "Home Buying Funnel Form New Lead";

                var doc = new Document();
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
                var FontRed = FontFactory.GetFont("Arial", 13, BaseColor.Red);
                doc.Open();
                var Heading = FontFactory.GetFont("Arial", 20, BaseColor.Black);
                Paragraph preface = new Paragraph("Home Buying Funnel Form", Heading);
                preface.Alignment = Element.ALIGN_CENTER;
                doc.Add(preface);
                doc.Add(new Paragraph("Question: What type of property are you purchasing?"));
                doc.Add(new Paragraph("Answer: " + input.propertyType,FontRed));
                doc.Add(new Paragraph("Question: How will your property be used?"));
                doc.Add(new Paragraph("Answer: " + input.propertyUse,FontRed));

                doc.Add(new Paragraph("Question: Is this your first time buying a home?"));
                doc.Add(new Paragraph("Answer: " + input.FirstTimeHomeBuying,FontRed));

                doc.Add(new Paragraph("Question: When do you plan to purchase?"));
                doc.Add(new Paragraph("Answer: " + input.planToPurchase,FontRed));

                doc.Add(new Paragraph("Question: Perporty Located?"));
                doc.Add(new Paragraph("Answer: " + input.propertyLocated, FontRed));
                doc.Add(new Paragraph("Question: How much is your down payment?"));
                doc.Add(new Paragraph("Answer: " + input.downPayment, FontRed));

                doc.Add(new Paragraph("Question: Are you currently employed?"));
                doc.Add(new Paragraph("Answer: " + input.currentlyEmployed, FontRed));

                doc.Add(new Paragraph("Question: What is your gross annual household income?"));
                doc.Add(new Paragraph("Answer: " + input.houseHoldIncome, FontRed));

                doc.Add(new Paragraph("Question: Can you show proof of income?"));
                doc.Add(new Paragraph("Answer: " + input.proofOfincome, FontRed));

                doc.Add(new Paragraph("Question: Active or previous U.S military sevice?"));
                doc.Add(new Paragraph("Answer: " + input.militarySevice, FontRed));

                doc.Add(new Paragraph("Question: Any bankruptcy in the past 3 years?"));
                doc.Add(new Paragraph("Answer: " + input.bankruptcyPastThreeYears, FontRed));

                doc.Add(new Paragraph("Question: Any foreclosure in the past 2 years?"));
                doc.Add(new Paragraph("Answer: " + input.foreclosurePastTwoYears, FontRed));

                doc.Add(new Paragraph("Question: Number of late mortgage payments in the last 12 months?"));
                doc.Add(new Paragraph("Answer: " + input.LateMortgagePayments, FontRed));

                doc.Add(new Paragraph("Question: How would you rate your credit?"));
                doc.Add(new Paragraph("Answer: " + input.rateCredit, FontRed));

                doc.Add(new Paragraph("Question: First Name?"));
                doc.Add(new Paragraph("Answer: " + input.firstName, FontRed));

                doc.Add(new Paragraph("Question: Last Name?"));
                doc.Add(new Paragraph("Answer: " + input.lastName, FontRed));

                doc.Add(new Paragraph("Question: Email Address?"));
                doc.Add(new Paragraph("Answer: " + input.emailAddress, FontRed));

                doc.Add(new Paragraph("Question: Mobile Phone Number?"));
                doc.Add(new Paragraph("Answer: " + input.phoneNumber, FontRed));

                doc.Add(new Paragraph("Question: Reffered By?"));
                doc.Add(new Paragraph("Answer: " + input.refferedBy, FontRed));

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
