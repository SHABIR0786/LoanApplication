using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LoanManagement.codeFirstEntities;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class SiteSettingServices : AbpServiceBase, ISiteSettingServices
    {
        private readonly IRepository<Sitesetting, int> _repository;
        private readonly IMapper _mapper;

        public SiteSettingServices(IRepository<Sitesetting, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<SiteSettingDto> CreateAsync(SiteSettingDto input)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(EntityDto<int> input)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PagedResultDto<SiteSettingDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            var query = _repository.GetAll();
            var siteSettings = await query.Skip(input.SkipCount).Take(input.MaxResultCount)
                .ProjectTo<SiteSettingDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            var count = await _repository.CountAsync();

            return new PagedResultDto<SiteSettingDto>(count, siteSettings);
        }

        public async Task<SiteSettingDto> GetAsync(EntityDto<int> input)
        {
            var model = await _repository.GetAsync(input.Id);
            return new SiteSettingDto
            {
                Id = model.Id,
                PageIdentifier = model.PageIdentifier,
                PageName = model.PageName,
                PageSetting = model.PageSetting
            };
        }

        public async Task<SiteSettingDto> UpdateAsync(SiteSettingDto input)
        {
            var siteSetting = new Sitesetting
            {
                Id = input.Id
            };

            await _repository.UpdateAsync(input.Id, siteSetting =>
            {
                siteSetting.PageSetting = input.PageSetting;

                return Task.CompletedTask;
            });
            await UnitOfWorkManager.Current.SaveChangesAsync();

            return input;
        }
    }
}
