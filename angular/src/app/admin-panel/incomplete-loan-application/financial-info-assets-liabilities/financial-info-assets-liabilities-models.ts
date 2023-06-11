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
    personalInformationId:number=3;
}
export class MortgageFinancialOtherAssets{
    financialAssetsTypeId:number;
    cashMarketValue:number;
    personalInformationId:number=3;
}
export class MortgageFinancialLiabilities{
    financialLaibilitiesTypeId:number;
    companyName:string;
    accountNumber:string;
    unpaidBalance:number;
    isPaidBeforeClosing:boolean=true;
    monthlyPayment:number;
    PersonalInformationId:number=3;
}
export class MortgageFinancialOtherLaibilities{
    financialLaibilitiesTypeId:number;
    monthlyPayment:number;
    personalInformationId:number=3;
}
