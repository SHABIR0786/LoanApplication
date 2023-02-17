using Abp.Domain.Entities.Auditing;
using LoanManagement.codeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationQuestions:FullAuditedEntity<int>
    {
        public int? DeclarationQuestionId { get; set; }
        public virtual DeclarationQuestion DeclarationQuestion { get; set; }
        public string Answer { get; set; }
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
