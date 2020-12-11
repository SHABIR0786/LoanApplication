using Abp.Application.Services.Dto;

namespace LoanManagement.ViewModels
{
    public class AddressDto : EntityDto<long?>
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        public int? ZipCode { get; set; }
        public int? Years { get; set; }
        public int? Months { get; set; }

        public bool IsNull()
        {
            return string.IsNullOrWhiteSpace(AddressLine1) && string.IsNullOrWhiteSpace(AddressLine2) &&
                   string.IsNullOrWhiteSpace(City) && !StateId.HasValue && !ZipCode.HasValue &&
                   !Years.HasValue && !Months.HasValue;
        }
    }
}