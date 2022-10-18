using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Declaration : FullAuditedEntity<long>
    {
        public bool? IsOutstandingJudgmentsAgainstYou { get; set; }
        public bool? IsDeclaredBankrupt { get; set; }
        public bool? IsPropertyForeClosedUponOrGivenTitle { get; set; }
        public bool? IsPartyToLawsuit { get; set; }
        public bool? IsObligatedOnAnyLoanWhichResultedForeclosure { get; set; }
        public bool? IsPresentlyDelinquent { get; set; }
        public bool? IsObligatedToPayAlimonyChildSupport { get; set; }
        public bool? IsAnyPartOfTheDownPayment { get; set; }
        public bool? IsCoMakerOrEndorser { get; set; }
        public bool? IsUscitizen { get; set; }
        public bool? IsPermanentResidentSlien { get; set; }
        public bool? IsIntendToOccupyThePropertyAsYourPrimary { get; set; }
        public bool? IsOwnershipInterestInPropertyInTheLastThreeYears { get; set; }
        public string DeclarationsSection { get; set; }
        public long LoanApplicationId { get; set; }
        public int BorrowerTypeId { get; set; }

        public virtual Borrowertype BorrowerType { get; set; }
        public virtual Loanapplication LoanApplication { get; set; }
    }
}
