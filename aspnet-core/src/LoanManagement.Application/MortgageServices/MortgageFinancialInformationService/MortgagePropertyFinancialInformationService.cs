using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using LoanManagement.MortgageServices.MortgageFinancialInformationService.Dto;
using LoanManagement.MortgageTables;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageServices.MortgageFinancialInformationService
{
    public class MortgagePropertyFinancialInformationService:AsyncCrudAppService<MortgagePropertyFinancialInformation,MortgagePropertyFinancialInformationDto,int>
    {
        private readonly IRepository<MortgagePropertyFinancialInformation> _mortgagePropertyFinancialInformation;
        private readonly IRepository<MortgageLoanOnProperyFinancialInformation> _mortgageLoanOnProperyFinancialInformation;
        private readonly IRepository<MortgagePropertyAdditionalFinancialInformation> _mortgagePropertyAdditionalFinancialInformation;
        private readonly IRepository<MortgageLoanOnAdditionalPropertyFinancialInformation> _mortgageLoanOnAdditionalPropertyFinancialInformation;

        public MortgagePropertyFinancialInformationService(IRepository<MortgagePropertyFinancialInformation> mortgagePropertyFinancialInformation, IRepository<MortgageLoanOnProperyFinancialInformation> mortgageLoanOnProperyFinancialInformation, IRepository<MortgagePropertyAdditionalFinancialInformation> mortgagePropertyAdditionalFinancialInformation, IRepository<MortgageLoanOnAdditionalPropertyFinancialInformation> mortgageLoanOnAdditionalPropertyFinancialInformation):base(mortgagePropertyFinancialInformation)
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
                        creditorName = item.creditorName,
                        accountNumber = item.accountNumber,
                        monthlyMortagagePayment = item.monthlyMortagagePayment,
                        unpaidBalance = item.unpaidBalance,
                        type = item.type,
                        creditLimit = item.creditLimit,
                        MortgagePropertyFinancialInformationId = item.MortgagePropertyFinancialInformationId,
                    };
                    await _mortgageLoanOnProperyFinancialInformation.InsertAsync(mortgagePropertyLoan);
                }
                var mortageAdditionaldetail = ObjectMapper.Map<MortgagePropertyAdditionalFinancialInformation>(createMortgagePropertyFinancialInformationDto.MortgagePropertyAdditionalFinancialInformation);
                var data = await _mortgagePropertyAdditionalFinancialInformation.InsertAndGetIdAsync(mortageAdditionaldetail);
                foreach (var item in createMortgagePropertyFinancialInformationDto.MortgageLoanOnAdditionalPropertyFinancialInformation)
                {
                    var additionalMortgagePropertyLoan = new MortgageLoanOnAdditionalPropertyFinancialInformation()
                    {
                        creditorName = item.creditorName,
                        accountNumber = item.accountNumber,
                        monthlyMortagagePayment = item.monthlyMortagagePayment,
                        unpaidBalance = item.unpaidBalance,
                        type = item.type,
                        MortgagePropertyFinancialInformationId = item.MortgagePropertyFinancialInformationId,
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
