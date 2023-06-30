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
        public string SourceType { get; set; }
        public decimal MonthlyIncome { get; set; }
        public int? IncomeSourceId { get; set; }
        //public virtual MortgageApplicationIncomeSourceDto IncomeSource { get; set; }
    }
}
