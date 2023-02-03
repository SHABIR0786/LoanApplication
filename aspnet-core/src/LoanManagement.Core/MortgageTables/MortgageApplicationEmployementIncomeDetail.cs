﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationEmployementIncomeDetail:FullAuditedEntity<int>
    {
        public decimal baseIncome { get; set; }
        public decimal overtime { get; set; }
        public decimal bonus { get; set; }
        public decimal commission { get; set; }
        public decimal militaryEntitlements { get; set; }
        public decimal other { get; set; }
        public decimal total { get; set; }
        public int EmploymentDetailId { get; set; }
        public virtual MortgageApplicationEmployementDetail EmploymentDetail { get; set; }
    }
}
