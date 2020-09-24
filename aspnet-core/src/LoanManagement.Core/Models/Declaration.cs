using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.Models
{
    public class Declaration : FullAuditedEntity<long>, IMayHaveTenant
    {
        public string IsOutstandingJudgmentsAgainstYou { get; set; }
        public string IsDeclaredBankruptWithin7Years { get; set; }
        public string IsPropertyForeClosedWithin7Years { get; set; }
        public string IsPartyLawsuit { get; set; }
        public string IsObligatedOnAnyLoan { get; set; }

        //next section
        public string IsPresentlyDelinquentOrInDefaultFederal { get; set; }
        public string IsObligatedToPayOrChildSupport { get; set; }
        public string IsAnyPartPaymentBorrowed { get; set; }
        public string IsCoMakerOrEndorserOnANote { get; set; }
        public string IsUsCitizen { get; set; }
        public string IsPermenentResidentAlien { get; set; }
        public string IsIntendToOccuppyTheProperty { get; set; }
        public string IsOwnedPropertyLastThreeYears { get; set; }

        //end
        public string WhatTypeOfPropertyYouOwned { get; set; }
        public string HowYouHoldTitleHome { get; set; }
        public int BorrowerTypeId { get; set; }

        [ForeignKey("BorrowerTypeId")]
        public BorrowerType BorrowerType { get; set; }
        public int? TenantId { get; set; }
    }
}
