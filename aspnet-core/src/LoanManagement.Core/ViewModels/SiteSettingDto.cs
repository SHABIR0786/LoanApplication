using Abp.Application.Services.Dto;

namespace LoanManagement.ViewModels
{
    public class SiteSettingDto : EntityDto<int>
    {
        public string PageIdentifier { get; set; }
        public string PageName { get; set; }
        public string PageSetting { get; set; }
    }
}
