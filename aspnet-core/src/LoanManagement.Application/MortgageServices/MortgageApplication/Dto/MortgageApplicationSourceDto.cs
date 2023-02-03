using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using LoanManagement.MortgageTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageServices.MortgageApplication.Dto
{
    [AutoMapFrom(typeof(MortgageApplicationSource))]
    public class MortgageApplicationSourceDto:FullAuditedEntity<int>
    {
        public string sourceType { get; set; }
        public decimal monthlyIncome { get; set; }
        public int? IncomeSourceId { get; set; }
        //public virtual MortgageApplicationIncomeSourceDto IncomeSource { get; set; }
    }
}
