using Abp.Application.Services.Dto;

namespace LoanManagement.ViewModels
{
    public class AdditionalIncomeDto : EntityDto<long?>
    {
        public decimal? Amount { get; set; }
        public int? IncomeSourceId { get; set; }
        public int? BorrowerTypeId { get; set; }
        public long LoanApplicationId { get; set; }

        public bool IsNull()
        {
            return !Amount.HasValue && !IncomeSourceId.HasValue;
        }
    }
}
