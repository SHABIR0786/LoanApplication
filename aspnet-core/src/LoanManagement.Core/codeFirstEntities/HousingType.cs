﻿using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class HousingType
    {
        public HousingType()
        {
            //ApplicationPersonalInformationCurrentHousingTypeId1a141Navigations = new HashSet<ApplicationPersonalInformation>();
            //ApplicationPersonalInformationFormerHousingTypeId1a161Navigations = new HashSet<ApplicationPersonalInformation>();
        }

        public int Id { get; set; }
        public string HousingType1 { get; set; }

        //public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformationCurrentHousingTypeId1a141Navigations { get; set; }
        //public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformationFormerHousingTypeId1a161Navigations { get; set; }
    }
}
