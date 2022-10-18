﻿using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class DeclarationQuestion:Entity<int>
    {
        public DeclarationQuestion()
        {
            ApplicationDeclarationQuestions = new HashSet<ApplicationDeclarationQuestion>();
        }

        public int Id { get; set; }
        public int? DeclarationCategoryId { get; set; }
        public int? ParentQuestionId { get; set; }
        public string Question { get; set; }
        public ulong? IsActive { get; set; }

        public virtual DeclarationCategory DeclarationCategory { get; set; }
        public virtual ICollection<ApplicationDeclarationQuestion> ApplicationDeclarationQuestions { get; set; }
    }
}
