using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.ViewModels
{
    public class StockAndBondViewModel : EntityDto<long?>
    {
        public string CompanyName { get; set; }
        public string AccountNumber { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Value { get; set; }
        public long ManualAssetEntryId { get; set; }
    }
}
