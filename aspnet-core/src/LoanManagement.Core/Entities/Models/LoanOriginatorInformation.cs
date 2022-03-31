using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class LoanOriginatorInformation
    {
        public int Id { get; set; }
        public int? ApplicationPersonalInformationId { get; set; }
        public string OrganizationName91 { get; set; }
        public string Address92 { get; set; }
        public string OrganizationNmlsrId93 { get; set; }
        public string OrganizationStateLicence94 { get; set; }
        public string OriginatorName95 { get; set; }
        public string OriginatorNmlsrId96 { get; set; }
        public string OriginatorStateLicense97 { get; set; }
        public string Email98 { get; set; }
        public string Phone99 { get; set; }
        public DateTime? Date910 { get; set; }

        public virtual ApplicationPersonalInformation? ApplicationPersonalInformation { get; set; }
    }
}
