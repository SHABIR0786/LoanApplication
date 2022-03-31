using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class LoanPropertyGiftType
    {
        public LoanPropertyGiftType()
        {
            LoanAndPropertyInformationGifts = new HashSet<LoanAndPropertyInformationGift>();
        }

        public int Id { get; set; }
        public string LoanPropertyGiftType1 { get; set; } = null!;

        public virtual ICollection<LoanAndPropertyInformationGift> LoanAndPropertyInformationGifts { get; set; }
    }
}
