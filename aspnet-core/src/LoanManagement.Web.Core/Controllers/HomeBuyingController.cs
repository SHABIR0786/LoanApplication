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
               // mailMessage.To.Add(new MailAddress("wmartin@ezonlinemortgage.com"));
                mailMessage.To.Add(new MailAddress("shabir.abdulmajeed786@gmail.com"));
                mailMessage.From = new MailAddress("loanapplicationmail@gmail.com");
                mailMessage.Subject = "Home Buying Funnel Form New Lead";

                var doc = new Document();
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
                var FontRed = FontFactory.GetFont("Arial", 13, BaseColor.Red);
                var FontBlack = FontFactory.GetFont("Arial", 13, BaseColor.Black);
                var Answer = new Chunk("Answer: ", FontBlack);

                doc.Open();
                var Heading = FontFactory.GetFont("Arial", 20, BaseColor.Black);
                Paragraph preface = new Paragraph("Home Buying Funnel Form", Heading);
                preface.Alignment = Element.ALIGN_CENTER;
                doc.Add(preface);
                doc.Add(new Paragraph("Question: What type of property are you purchasing?"));
                var phrase = new Phrase(Answer);
                phrase.Add(new Chunk(input.propertyType, FontRed));
                doc.Add(phrase);
                doc.Add(new Paragraph("Question: How will your property be used?"));
                var phrase2 = new Phrase(Answer);
                phrase2.Add(new Chunk(input.propertyUse, FontRed));
                doc.Add(phrase2);
                doc.Add(new Paragraph("Question: Is this your first time buying a home?"));
                var phrase3 = new Phrase(Answer);
                phrase3.Add(new Chunk(input.FirstTimeHomeBuying?"Yes":"No", FontRed));
                doc.Add(phrase3);

                doc.Add(new Paragraph("Question: When do you plan to purchase?"));
                var phrase4 = new Phrase(Answer);
                phrase4.Add(new Chunk(input.planToPurchase, FontRed));
                doc.Add(phrase4);

                doc.Add(new Paragraph("Question: Perporty Located?"));
                var phrase5 = new Phrase(Answer);
                phrase5.Add(new Chunk(input.propertyLocated, FontRed));
                doc.Add(phrase5);

                doc.Add(new Paragraph("Question: How much is your down payment?"));
                var phrase6 = new Phrase(Answer);
                phrase6.Add(new Chunk(input.downPayment.ToString(), FontRed));
                doc.Add(phrase6);


                doc.Add(new Paragraph("Question: Are you currently employed?"));
                var phrase7 = new Phrase(Answer);
                phrase7.Add(new Chunk(input.currentEmployed, FontRed));
                doc.Add(phrase7);

                doc.Add(new Paragraph("Question: What is your gross annual household income?"));
                var phrase8 = new Phrase(Answer);
                phrase8.Add(new Chunk(input.houseHoldIncome, FontRed));
                doc.Add(phrase8);

                doc.Add(new Paragraph("Question: Can you show proof of income?"));
                var ProfeOfIncomephrase = new Phrase(Answer);
                ProfeOfIncomephrase.Add(new Chunk(input.proofOfincome?"Yes":"No", FontRed));
                doc.Add(ProfeOfIncomephrase);

                doc.Add(new Paragraph("Question: Active or previous U.S military sevice?"));
                var MilitrayServicephrase = new Phrase(Answer);
                MilitrayServicephrase.Add(new Chunk(input.militarySevice?"Yes":"No", FontRed));
                doc.Add(MilitrayServicephrase);

                doc.Add(new Paragraph("Question: Any bankruptcy in the past 3 years?"));
                var bankphrase = new Phrase(Answer);
                bankphrase.Add(new Chunk(input.bankruptcyPastThreeYears?"Yes":"No", FontRed));
                doc.Add(bankphrase);

                doc.Add(new Paragraph("Question: Any foreclosure in the past 2 years?"));
                var past2yearsphrase = new Phrase(Answer);
                past2yearsphrase.Add(new Chunk(input.foreclosurePastTwoYears?"Yes":"No", FontRed));
                doc.Add(past2yearsphrase);

                doc.Add(new Paragraph("Question: Number of late mortgage payments in the last 12 months?"));
                var last12monthsphrase = new Phrase(Answer);
                last12monthsphrase.Add(new Chunk(input.LateMortgagePayments, FontRed));
                doc.Add(last12monthsphrase);

                doc.Add(new Paragraph("Question: How would you rate your credit?"));
                var rateCreditphrase = new Phrase(Answer);
                rateCreditphrase.Add(new Chunk(input.rateCredit, FontRed));
                doc.Add(rateCreditphrase);

                doc.Add(new Paragraph("Question: First Name?"));
                var firstNamephrase = new Phrase(Answer);
                firstNamephrase.Add(new Chunk(input.firstName, FontRed));
                doc.Add(firstNamephrase);

                doc.Add(new Paragraph("Question: Last Name?"));
                var lastNamephrase = new Phrase(Answer);
                lastNamephrase.Add(new Chunk(input.lastName, FontRed));
                doc.Add(lastNamephrase);

                doc.Add(new Paragraph("Question: Email Address?"));
                var emailAddressphrase = new Phrase(Answer);
                emailAddressphrase.Add(new Chunk(input.emailAddress, FontRed));
                doc.Add(emailAddressphrase);

                doc.Add(new Paragraph("Question: Mobile Phone Number?"));
                var phoneNumberphrase = new Phrase(Answer);
                phoneNumberphrase.Add(new Chunk(input.phoneNumber, FontRed));
                doc.Add(phoneNumberphrase);

                doc.Add(new Paragraph("Question: Reffered By?"));
                var refferedByphrase = new Phrase(Answer);
                refferedByphrase.Add(new Chunk(input.refferedBy, FontRed));
                doc.Add(refferedByphrase);

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
