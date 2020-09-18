using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace LoanManagement.Models
{
    public class LoanApplication : FullAuditedEntity<long>, IMayHaveTenant
    {
        public long? AssetAndLiablityId { get; set; }
        public AssetAndLiablity AssetAndLiablity { get; set; }

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

        public long? BorrowerEmploymentInfoId { get; set; }
        public virtual BorrowerEmploymentInformation BorrowerEmploymentInfo { get; set; }

        public long? CoBorrowerEmploymentInfoId { get; set; }
        public virtual BorrowerEmploymentInformation CoBorrowerEmploymentInfo { get; set; }


        public int? TenantId { get; set; }
    }
}