﻿using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.Models
{
    public class InformationForGovermentMonitoringPurpose : Entity<long>
    {
        public string InterviewHeldedThrough { get; set; }
        public string LoanOriginatorsSignature { get; set; }
        public DateTime? Date { get; set; }
        public string LoanOriginatorsName { get; set; }
        public string LoanOriginatorIdentifier { get; set; }
        public string LoanOriginatorsPhoneNumber { get; set; }
        public string LoanOriginationCompanysName { get; set; }
        public string LoanOriginationCompanyIdentifier { get; set; }
        public string LoanOriginationCompanysAddress { get; set; }

        public int? AgencyCaseNumber { get; set; }
        public int? LenderCaseNumber { get; set; }

        public List<InformationForGovermentMonitoringPurposeBorrowerAndCo>
            InformationForGovermentMonitoringPurposeBorrowerAndCo
        { get; set; }
    }
}
