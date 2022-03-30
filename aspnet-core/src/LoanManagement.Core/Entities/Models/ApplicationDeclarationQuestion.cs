using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class ApplicationDeclarationQuestion
    {
        public int Id { get; set; }
        public int? ApplicationPersonalInformationId { get; set; }
        public int? DeclarationQuestionId { get; set; }
        public ulong? YesNo { get; set; }
        public string Description5a { get; set; }

        public virtual ApplicationPersonalInformation? ApplicationPersonalInformation { get; set; }
        public virtual DeclarationQuestion? DeclarationQuestion { get; set; }
    }
}
