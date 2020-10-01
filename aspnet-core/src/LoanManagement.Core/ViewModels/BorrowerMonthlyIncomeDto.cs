using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.Models
{
    public class BorrowerMonthlyIncomeDto : FullAuditedEntity<long>
    {

        public int? Base { get; set; }
        public int? Overtime { get; set; }
        public int? Bonuses { get; set; }
        public int? Commissions { get; set; }
        public int? Dividends { get; set; }
        public int BorrowerTypeId { get; set; }
    }
}