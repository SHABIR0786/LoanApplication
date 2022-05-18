using System;
using System.Collections.Generic;

namespace  LoanManagement.Features.AdminUser
{
    public partial class AddAdminUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ulong? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
