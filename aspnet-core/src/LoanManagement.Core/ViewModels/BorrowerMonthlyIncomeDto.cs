using Abp.Application.Services.Dto;

namespace LoanManagement.Models
{
    public class BorrowerMonthlyIncomeDto : EntityDto<long>
    {

        public int? Base { get; set; }
        public int? Overtime { get; set; }
        public int? Bonuses { get; set; }
        public int? Commissions { get; set; }
        public int? Dividends { get; set; }
        public int? BorrowerTypeId { get; set; }
        public long? LoanApplicationId { get; set; }
    }
}