using Abp.Application.Services.Dto;

namespace LoanManagement.ViewModels
{
    public class OtherIncomeDto : IEntityDto<long>
    {
        public long Id { get; set; }
        public int? BorrowerTypeId { get; set; }
        public string Type { get; set; }
        public decimal? MonthlyAmount { get; set; }
        public long? LoanApplicationId { get; set; }
    }
}
