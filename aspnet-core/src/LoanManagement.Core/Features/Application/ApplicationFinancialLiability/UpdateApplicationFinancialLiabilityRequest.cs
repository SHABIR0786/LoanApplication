﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.ApplicationFinancialLiability
{
    public class UpdateApplicationFinancialLiabilityRequest: AddApplicationFinancialLiabilityRequest
    {
        public int Id { get; set; }
    }
}
