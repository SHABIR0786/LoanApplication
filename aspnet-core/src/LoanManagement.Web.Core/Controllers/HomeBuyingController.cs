using System;
using System.Collections.Generic;
using System.Text;
using Abp.Runtime.Validation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LoanManagement.Models;
using System.Net.Mail;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using iTextSharp.text;
using iTextSharp.text.pdf;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.ViewModels;

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
                //mailMessage.To.Add(new MailAddress("wmartin@ezonlinemortgage.com"));
                mailMessage.To.Add(new MailAddress("shabir.abdulmajeed786@gmail.com"));
                mailMessage.From = new MailAddress("shabir.abdulmajeed786@gmail.com");
                mailMessage.Subject = "Loan Management Application New Lead";

                var doc = new Document();
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);

                doc.Open();
                doc.Add(new Paragraph("What type of property are you purchasing? Answer: "+input.propertyType));
                doc.Add(new Paragraph("How will your property be used? Answer: "+input.propertyUse));
                doc.Add(new Paragraph("Is this your first time buying a home? Answer: "+input.FirstTimeHomeBuying));
                doc.Add(new Paragraph("When do you plan to purchase? Answer: " + input.planToPurchase));
                doc.Add(new Paragraph("Perporty Located? Answer: " + input.propertyLocated));
                doc.Add(new Paragraph("What is the estimated purchase price? Answer: " + input.purchasePrice));
                doc.Add(new Paragraph("How much is your down payment? Answer: " + input.downPayment));
                doc.Add(new Paragraph("Are you currently employed? Answer: " + input.currentlyEmployed));
                doc.Add(new Paragraph("What is your gross annual household income? Answer: " + input.houseHoldIncome));
                doc.Add(new Paragraph("Can you show proof of income? Answer: " + input.proofOfincome));
                doc.Add(new Paragraph("Active or previous U.S military sevice? Answer: " + input.militarySevice));
                doc.Add(new Paragraph("Any bankruptcy in the past 3 years? Answer: " + input.bankruptcyPastThreeYears));
                doc.Add(new Paragraph("Any foreclosure in the past 2 years? Answer: " + input.foreclosurePastTwoYears));
                doc.Add(new Paragraph("Number of late mortgage payments in the last 12 months? Answer: " + input.LateMortgagePayments));
                doc.Add(new Paragraph("How would you rate your credit? Answer: " + input.rateCredit));
                doc.Add(new Paragraph("First Name? Answer: " + input.firstName));
                doc.Add(new Paragraph("Last Name? Answer: " + input.lastName));
                doc.Add(new Paragraph("Email Address? Answer: " + input.emailAddress));
                doc.Add(new Paragraph("Mobile Phone Number? Answer: " + input.phoneNumber));
                doc.Add(new Paragraph("Reffered By? Answer: " + input.refferedBy));
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
