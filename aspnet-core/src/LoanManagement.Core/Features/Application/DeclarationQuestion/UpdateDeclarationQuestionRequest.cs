﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.DeclarationQuestion
{
    public class UpdateDeclarationQuestionRequest : AddDeclarationQuestionRequest
    {
        public int Id { get; set; }
    }
}
