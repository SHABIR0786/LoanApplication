using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using LoanManagement.MortgageServices.MortgageFinancialInformation.Dto;
using LoanManagement.MortgageTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageServices.MortgageFinancialInformation
{
    public class MortgagePropertyFinancialInformationService : AsyncCrudAppService<MortgagePropertyFinancialInformation, MortgagePropertyFinancialInformationDto, int>
    {
        private readonly IRepository<MortgagePropertyFinancialInformation> _mortgagePropertyFinancialInformation;
        private readonly IRepository<MortgageLoanOnProperyFinancialInformation> _mortgageLoanOnProperyFinancialInformation;
        private readonly IRepository<MortgagePropertyAdditionalFinancialInformation> _mortgagePropertyAdditionalFinancialInformation;
        private readonly IRepository<MortgageLoanOnAdditionalPropertyFinancialInformation> _mortgageLoanOnAdditionalPropertyFinancialInformation;

        public MortgagePropertyFinancialInformationService(IRepository<MortgagePropertyFinancialInformation> mortgagePropertyFinancialInformation, IRepository<MortgageLoanOnProperyFinancialInformation> mortgageLoanOnProperyFinancialInformation, IRepository<MortgagePropertyAdditionalFinancialInformation> mortgagePropertyAdditionalFinancialInformation, IRepository<MortgageLoanOnAdditionalPropertyFinancialInformation> mortgageLoanOnAdditionalPropertyFinancialInformation) : base(mortgagePropertyFinancialInformation)
        {
            this._mortgagePropertyFinancialInformation = mortgagePropertyFinancialInformation;
            this._mortgageLoanOnProperyFinancialInformation = mortgageLoanOnProperyFinancialInformation;
            this._mortgagePropertyAdditionalFinancialInformation = mortgagePropertyAdditionalFinancialInformation;
            this._mortgageLoanOnAdditionalPropertyFinancialInformation = mortgageLoanOnAdditionalPropertyFinancialInformation;
        }

        public async Task CreateMortgagePropertyFinancialInformationAsync(CreateMortgagePropertyFinancialInformationDto createMortgagePropertyFinancialInformationDto)
        {
            try
            {
                var entity = ObjectMapper.Map<MortgagePropertyFinancialInformation>(createMortgagePropertyFinancialInformationDto.MortgagePropertyFinancialInformation);
                var id = await _mortgagePropertyFinancialInformation.InsertAndGetIdAsync(entity);
                foreach (var item in createMortgagePropertyFinancialInformationDto.MortgageLoanOnProperyFinancialInformation)
                {
                    var mortgagePropertyLoan = new MortgageLoanOnProperyFinancialInformation()
                    {
                        CreditorName = item.CreditorName,
                        AccountNumber = item.AccountNumber,
                        MonthlyMortagagePayment = item.MonthlyMortagagePayment,
                        UnpaidBalance = item.UnpaidBalance,
                        Type = item.Type,
                        CreditLimit = item.CreditLimit,
                        MortgagePropertyFinancialInformationId = id,
                    };
                    await _mortgageLoanOnProperyFinancialInformation.InsertAsync(mortgagePropertyLoan);
                } 
                var mortageAdditionaldetail = ObjectMapper.Map<MortgagePropertyAdditionalFinancialInformation>(createMortgagePropertyFinancialInformationDto.MortgagePropertyAdditionalFinancialInformation);
                var data = await _mortgagePropertyAdditionalFinancialInformation.InsertAndGetIdAsync(mortageAdditionaldetail);
                foreach (var item in createMortgagePropertyFinancialInformationDto.MortgageLoanOnAdditionalPropertyFinancialInformation)
                {
                    var additionalMortgagePropertyLoan = new MortgageLoanOnAdditionalPropertyFinancialInformation()
                    {
                        CreditorName = item.CreditorName,
                        AccountNumber = item.AccountNumber,
                        MonthlyMortagagePayment = item.MonthlyMortagagePayment,
                        UnpaidBalance = item.UnpaidBalance,
                        Type = item.Type,
                        MortgagePropertyFinancialInformationId = data,
                    };
                    await _mortgageLoanOnAdditionalPropertyFinancialInformation.InsertAsync(additionalMortgagePropertyLoan);
                }
            }
            catch (Exception error)
            {

                throw;
            }

        }
    }
}
