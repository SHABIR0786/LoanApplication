using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.LoanApplications.Dto;
using LoanManagement.Property_Information;
using LoanManagement.Roles.Dto;
using System;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class PropertyInformationService : AbpServiceBase, IPropertyInformationService
    {
        private readonly IRepository<PropertyInformation, long> _repository;

        public PropertyInformationService(IRepository<PropertyInformation, long> repository)
        {
            _repository = repository;
        }

        public async Task<PropertyInformationDto> CreateAsync(PropertyInformationDto input)
        {
            var propertyInformation = new PropertyInformation
            {
                Address = input.Address,
                AmountExistingLiens = input.AmountExistingLiens,
                AmountExistingLiensRefinance = input.AmountExistingLiensRefinance,
                CostOfImprovements = input.CostOfImprovements,
                EstateHeldIn = input.EstateHeldIn,
                ImprovementCostRefinance = input.ImprovementCostRefinance,
                ImprovementsRefinance = input.ImprovementsRefinance,
                LegalDescription = input.LegalDescription,
                NumberOfUnits = input.NumberOfUnits,
                OriginalCost = input.OriginalCost,
                OriginalCostRefinance = input.OriginalCostRefinance,
                PresentValueOfLot = input.PresentValueOfLot,
                PropertyWillBe = input.PropertyWillBe,
                PurposeOfLoan = input.PurposeOfLoan,
                PurposeOfLoanExplain = input.PurposeOfLoanExplain,
                PurposeOfRefinance = input.PurposeOfRefinance,
                SourceOfPayment = input.SourceOfPayment,
                TitleHeldManner = input.TitleHeldManner,
                TitleHeldNames = input.TitleHeldNames,
                YearAcquiredRefinance = input.YearAcquiredRefinance,
                YearBuilt = input.YearBuilt,
                YearLotAcquired = input.YearLotAcquired,
            };
            await _repository.InsertAsync(propertyInformation);

            await UnitOfWorkManager.Current.SaveChangesAsync();

            input.Id = propertyInformation.Id;
            return input;
        }

        public async Task DeleteAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<PropertyInformationDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<PropertyInformationDto> GetAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public async Task<PropertyInformationDto> UpdateAsync(PropertyInformationDto input)
        {
            await _repository.UpdateAsync(input.Id, propertyInformation =>
            {
                propertyInformation.Address = input.Address;
                propertyInformation.AmountExistingLiens = input.AmountExistingLiens;
                propertyInformation.AmountExistingLiensRefinance = input.AmountExistingLiensRefinance;
                propertyInformation.CostOfImprovements = input.CostOfImprovements;
                propertyInformation.EstateHeldIn = input.EstateHeldIn;
                propertyInformation.ImprovementCostRefinance = input.ImprovementCostRefinance;
                propertyInformation.ImprovementsRefinance = input.ImprovementsRefinance;
                propertyInformation.LegalDescription = input.LegalDescription;
                propertyInformation.NumberOfUnits = input.NumberOfUnits;
                propertyInformation.OriginalCost = input.OriginalCost;
                propertyInformation.OriginalCostRefinance = input.OriginalCostRefinance;
                propertyInformation.PresentValueOfLot = input.PresentValueOfLot;
                propertyInformation.PropertyWillBe = input.PropertyWillBe;
                propertyInformation.PurposeOfLoan = input.PurposeOfLoan;
                propertyInformation.PurposeOfLoanExplain = input.PurposeOfLoanExplain;
                propertyInformation.PurposeOfRefinance = input.PurposeOfRefinance;
                propertyInformation.SourceOfPayment = input.SourceOfPayment;
                propertyInformation.TitleHeldManner = input.TitleHeldManner;
                propertyInformation.TitleHeldNames = input.TitleHeldNames;
                propertyInformation.YearAcquiredRefinance = input.YearAcquiredRefinance;
                propertyInformation.YearBuilt = input.YearBuilt;
                propertyInformation.YearLotAcquired = input.YearLotAcquired;

                return Task.CompletedTask;
            });

            await UnitOfWorkManager.Current.SaveChangesAsync();

            return input;
        }
    }
}
