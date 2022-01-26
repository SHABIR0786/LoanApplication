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
                mailMessage.To.Add(new MailAddress("wmartin@ezonlinemortgage.com"));
                mailMessage.From = new MailAddress("shabir.abdulmajeed786@gmail.com");
                mailMessage.Subject = "Refinance Home Buying Funnel Form New Lead";

                var doc = new Document();
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
                var FontRed = FontFactory.GetFont("Arial", 13, BaseColor.Red);
                var Heading = FontFactory.GetFont("Arial", 20, BaseColor.Black);
                doc.Open();
                Paragraph preface = new Paragraph("Refinance Home Buying Funnel Form", Heading);
                preface.Alignment = Element.ALIGN_CENTER;
                doc.Add(preface);
                doc.Add(new Paragraph("Question: What state is the property located in?"));
                doc.Add(new Paragraph("Answer: " + input.propertyLocated,FontRed));
                doc.Add(new Paragraph("Question: What type of home are you refinancing?"));
                doc.Add(new Paragraph("Answer: " + input.propertyType, FontRed));

                doc.Add(new Paragraph("Question: How will your property be used?"));
                doc.Add(new Paragraph("Answer: " + input.PropertyUse, FontRed));

                doc.Add(new Paragraph("Question: Why do you want to refinance?"));
                doc.Add(new Paragraph("Answer: " + input.WantRefinance, FontRed));

                doc.Add(new Paragraph("Question: What's your home's value?"));
                doc.Add(new Paragraph("Answer: " + input.HomePrice, FontRed));

                doc.Add(new Paragraph("Question: How much do you owe?"));
                doc.Add(new Paragraph("Answer: " + input.Owe, FontRed));

                doc.Add(new Paragraph("Question: How much cash do you want to borrow?"));
                doc.Add(new Paragraph("Answer: " + input.CashBorrow, FontRed));

                doc.Add(new Paragraph("Question: Do you currently have an FHA loan?"));
                doc.Add(new Paragraph("Answer: " + input.FHALoan, FontRed));

                doc.Add(new Paragraph("Question: Active or previous U.S military sevice?"));
                doc.Add(new Paragraph("Answer: " + input.militarySevice, FontRed));

                doc.Add(new Paragraph("Question: Any foreclosure in the past 2 years?"));
                doc.Add(new Paragraph("Answer: " + input.foreclosurePastTwoYears, FontRed));

                doc.Add(new Paragraph("Question: Any bankruptcy in the past 3 years?"));
                doc.Add(new Paragraph("Answer: " + input.bankruptcyPastThreeYears, FontRed));

                doc.Add(new Paragraph("Question: Number of late mortgage payments in the last 12 months?"));
                doc.Add(new Paragraph("Answer: " + input.LateMortgagePayments, FontRed));

                doc.Add(new Paragraph("Question: Are you currently employed?"));
                doc.Add(new Paragraph("Answer: " + input.currentEmployed, FontRed));

                doc.Add(new Paragraph("Question: What is your gross annual household income?"));
                doc.Add(new Paragraph("Answer: " + input.houseHoldIncome, FontRed));

                doc.Add(new Paragraph("Question: Can you show proof of income?"));
                doc.Add(new Paragraph("Answer: " + input.proofOfincome, FontRed));

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
