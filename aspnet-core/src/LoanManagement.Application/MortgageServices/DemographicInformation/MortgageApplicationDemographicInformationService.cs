using Abp.Application.Services;
using Abp.Domain.Repositories;
using LoanManagement.MortgageServices.DemographicInformation.Dto;
using LoanManagement.MortgageTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageServices.DemographicInformation
{
    public class MortgageApplicationDemographicInformationService : AsyncCrudAppService<MortgageApplicationDemographicInformation, MortgageApplicationDemographicInformationDto, int>
    {
        private readonly IRepository<MortgageApplicationDemographicInformation> _demographicInfoRepository;
        private readonly IRepository<MortgageApplicaitonDempgraphicInfoByFinancialInstitution> _demographicInfoByFinancialInstitutionRepository;
        public MortgageApplicationDemographicInformationService(IRepository<MortgageApplicationDemographicInformation> demographicInforepository,
            IRepository<MortgageApplicaitonDempgraphicInfoByFinancialInstitution> demographicInfoByFinancialInstitutionRepository
            ) : base(demographicInforepository)
        {
            this._demographicInfoRepository = demographicInforepository;
            this._demographicInfoByFinancialInstitutionRepository = demographicInfoByFinancialInstitutionRepository;
        }
        public async Task CreateDemographicInformation(MortgageApplicationDemographicInformationDto demographicInformationDto)
        {
            if (demographicInformationDto != null)
            {
                var demographicInfo = ObjectMapper.Map<MortgageApplicationDemographicInformation>(demographicInformationDto);
                await _demographicInfoRepository.InsertAsync(demographicInfo);
            }
            if (demographicInformationDto.DemographicInfoByFinancialInstitution != null)
            {
                var infoByFinancialInstitution = ObjectMapper.Map<MortgageApplicaitonDempgraphicInfoByFinancialInstitution>(demographicInformationDto.DemographicInfoByFinancialInstitution);
                await _demographicInfoByFinancialInstitutionRepository.InsertAsync(infoByFinancialInstitution);
            }
        }
    }
}
