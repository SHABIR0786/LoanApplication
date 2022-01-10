﻿using System;
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
                mailMessage.Subject = "Loan Management Application New Lead";

                var doc = new Document();
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);

                doc.Open();
                Paragraph preface = new Paragraph("Refinance Home Buying Funnel Form");
                preface.Alignment = Element.ALIGN_CENTER;
                doc.Add(preface);
                doc.Add(new Paragraph("What state is the property located in? Answer: " + input.propertyLocated));
                doc.Add(new Paragraph("What type of home are you refinancing? Answer: " + input.propertyType));
                doc.Add(new Paragraph("How will your property be used? Answer: " + input.PropertyUse));
                doc.Add(new Paragraph("Why do you want to refinance? Answer: " + input.WantRefinance));
                doc.Add(new Paragraph("What's your home's value? Answer: " + input.HomePrice));
                doc.Add(new Paragraph("How much do you owe? Answer: " + input.Owe));
                doc.Add(new Paragraph("How much cash do you want to borrow? Answer: " + input.CashBorrow));
                doc.Add(new Paragraph("Do you currently have an FHA loan? Answer: " + input.FHALoan));
                doc.Add(new Paragraph("Active or previous U.S military sevice? Answer: " + input.militarySevice));
                doc.Add(new Paragraph("Any foreclosure in the past 2 years? Answer: " + input.foreclosurePastTwoYears));
                doc.Add(new Paragraph("Any bankruptcy in the past 3 years? Answer: " + input.bankruptcyPastThreeYears));
                doc.Add(new Paragraph("Number of late mortgage payments in the last 12 months? Answer: " + input.LateMortgagePayments));
                doc.Add(new Paragraph("Are you currently employed? Answer: " + input.currentEmployed));
                doc.Add(new Paragraph("What is your gross annual household income? Answer: " + input.houseHoldIncome));
                doc.Add(new Paragraph("Can you show proof of income? Answer: " + input.proofOfincome));
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
