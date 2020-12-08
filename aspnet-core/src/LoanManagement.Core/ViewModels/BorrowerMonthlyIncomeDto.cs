using Abp.Application.Services.Dto;

namespace LoanManagement.Models
{
    public class BorrowerMonthlyIncomeDto : EntityDto<long?>
    {
        public decimal? Base { get; set; }
        public decimal? Overtime { get; set; }
        public decimal? Bonuses { get; set; }
        public decimal? Commissions { get; set; }
        public decimal? Dividends { get; set; }
        public int BorrowerTypeId { get; set; }
        public long? LoanApplicationId { get; set; }

        public bool IsNull()
        {
            return !Base.HasValue && !Overtime.HasValue &&
                   !Bonuses.HasValue && !Commissions.HasValue &&
                   !Dividends.HasValue;
        }
    }
}