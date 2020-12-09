using Abp.Domain.Entities;

namespace LoanManagement.Models
{
    public class CreditAuthAgreement : Entity<long>
    {
        public bool? AgreeCreditAuthAgreement { get; set; }
    }
}
