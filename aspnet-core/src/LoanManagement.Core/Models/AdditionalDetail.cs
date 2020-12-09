using Abp.Domain.Entities;

namespace LoanManagement.Models
{
    public class AdditionalDetail : Entity<long>
    {
        public string NameOfIndividualsOnTitle { get; set; }
        public string NameOfIndividualsCoBorrowerOnTitle { get; set; }
    }
}