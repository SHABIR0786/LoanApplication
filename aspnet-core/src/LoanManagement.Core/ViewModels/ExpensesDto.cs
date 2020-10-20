using Abp.Application.Services.Dto;

namespace LoanManagement.ViewModels
{
    public class ExpensesDto : EntityDto<long?>
    {
        public bool? IsLiveWithFamilySelectRent { get; set; }
        public decimal? Rent { get; set; }
        public decimal? OtherHousingExpenses { get; set; }
        public decimal? FirstMortgage { get; set; }
        public decimal? SecondMortgage { get; set; }
        public decimal? HazardInsurance { get; set; }
        public decimal? RealEstateTaxes { get; set; }
        public decimal? MortgageInsurance { get; set; }
        public decimal? HomeOwnersAssociation { get; set; }
    }
}