using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace LoanManagement.ViewModels
{
    public class DemographicDto : EntityDto<long?>
    {
        public List<DemographicTypeDto> Ethnicity { get; set; }
        public List<DemographicTypeDto> Race { get; set; }
        public List<DemographicTypeDto> Sex { get; set; }
    }
}
