using Abp.Application.Services.Dto;
using LoanManagement.CoreLogicModels.IndividualRequest;

namespace LoanManagement.ViewModels
{
    public class BorrowerJsonDto : EntityDto<long?>
    {

        public Residence _RESIDENCE { get; set; }

        public string BorrowerID { get; set; }

        public string _FirstName { get; set; }

        public string _MiddleName { get; set; }

        public string _LastName { get; set; }

        public string _NameSuffix { get; set; }

        public string _PrintPositionType { get; set; }

        public string _SSN { get; set; }
    }

}
