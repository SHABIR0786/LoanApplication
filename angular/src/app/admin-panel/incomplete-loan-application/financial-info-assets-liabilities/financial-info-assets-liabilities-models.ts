export class FinancialInfoAssetsLiabilitiesModels {
    mortgageFinancialAssets:MortgageFinancialAssets[]=[new MortgageFinancialAssets()];
    mortgageFinancialOtherAssets:MortgageFinancialOtherAssets[]=[new MortgageFinancialOtherAssets()];
    mortgageFinancialLiabilities:MortgageFinancialLiabilities[]=[new MortgageFinancialLiabilities()];
    mortgageFinancialOtherLaibilities:MortgageFinancialOtherLaibilities[]=[new MortgageFinancialOtherLaibilities()];
}
export class MortgageFinancialAssets{
    accountTypeId:number;
    financialInstitution:string;
    accountNumber:string;
    cashMarketValue:number;
    personalInformationId:number;
}
export class MortgageFinancialOtherAssets{
    financialAssetsTypeId:number;
    cashMarketValue:number;
    personalInformationId:number;
}
export class MortgageFinancialLiabilities{
    financialLaibilitiesTypeId:number;
    companyName:string;
    accountNumber:string;
    unpaidBalance:number;
    isPaidBeforeClosing:number;
    monthlyPayment:number;
    PersonalInformationId:number;
}
export class MortgageFinancialOtherLaibilities{
    financialLaibilitiesTypeId:number;
    monthlyPayment:number;
    personalInformationId:number;
}
