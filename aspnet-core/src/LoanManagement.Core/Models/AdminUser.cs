using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class AdminUser
    {
        public AdminUser()
        {
            AdminLoanapplicationdocuments = new HashSet<AdminLoanapplicationdocument>();
            AdminLoandetails = new HashSet<AdminLoandetail>();
            AdminUserenableddevices = new HashSet<AdminUserenableddevice>();
            AdminUsernotifications = new HashSet<AdminUsernotification>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ulong? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<AdminLoanapplicationdocument> AdminLoanapplicationdocuments { get; set; }
        public virtual ICollection<AdminLoandetail> AdminLoandetails { get; set; }
        public virtual ICollection<AdminUserenableddevice> AdminUserenableddevices { get; set; }
        public virtual ICollection<AdminUsernotification> AdminUsernotifications { get; set; }
    }
}
