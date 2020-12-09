using Abp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.Models
{
    public class AcknowledgementAndAgreement : Entity<long>
    {
        public string Signature { get; set; }
        public DateTime Date { get; set; }
        public int BorrowerTypeId { get; set; }

        [ForeignKey("BorrowerTypeId")]
        public BorrowerType BorrowerType { get; set; }
    }
}
