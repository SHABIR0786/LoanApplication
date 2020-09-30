using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace LoanManagement.Models
{
    public class LoanApplication : FullAuditedEntity<long>, IMayHaveTenant
    {
        public long? LoanDetailId { get; set; }
        public LoanDetail LoanDetail { get; set; }

        public long? AssetAndLiablityId { get; set; }
        public AssetAndLiability AssetAndLiablity { get; set; }

        public long? DetailsOfTransactionId { get; set; }
        public DetailsOfTransaction DetailsOfTransaction { get; set; }


        public long? MortgageTypeId { get; set; }
        public virtual MortgageType MortgageType { get; set; }

        public long? PropertyInfoId { get; set; }
        public virtual PropertyInformation PropertyInfo { get; set; }

        public long? BorrowerInfoId { get; set; }
        public virtual BorrowerInformation BorrowerInfo { get; set; }

        public long? CoBorrowerInfoId { get; set; }
        public virtual BorrowerInformation CoBorrowerInfo { get; set; }

        public long? BorrowerEmploymentInfoId1 { get; set; }
        public virtual BorrowerEmploymentInformation BorrowerEmploymentInfo1 { get; set; }

        public long? BorrowerEmploymentInfoId2 { get; set; }
        public virtual BorrowerEmploymentInformation BorrowerEmploymentInfo2 { get; set; }

        public long? BorrowerEmploymentInfoId3 { get; set; }
        public virtual BorrowerEmploymentInformation BorrowerEmploymentInfo3 { get; set; }

        public long? CoBorrowerEmploymentInfoId1 { get; set; }
        public virtual BorrowerEmploymentInformation CoBorrowerEmploymentInfo1 { get; set; }

        public long? CoBorrowerEmploymentInfoId2 { get; set; }
        public virtual BorrowerEmploymentInformation CoBorrowerEmploymentInfo2 { get; set; }

        public long? CoBorrowerEmploymentInfoId3 { get; set; }
        public virtual BorrowerEmploymentInformation CoBorrowerEmploymentInfo3 { get; set; }

        public int MonthlyIncomeAndCombinedHousingExpenseId { get; set; }
        public int? TenantId { get; set; }

        public List<GrossMonthlyIncome> GrossMonthlyIncomes { get; set; }
        public List<CombinedMonthlyHousingExpense> CombinedMonthlyHousingExpenses { get; set; }
        public List<OtherIncome> OtherIncomes { get; set; }
    }
}