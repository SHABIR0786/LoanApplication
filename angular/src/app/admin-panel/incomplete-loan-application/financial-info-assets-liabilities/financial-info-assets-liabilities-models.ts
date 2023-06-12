export class FinancialInfoAssetsLiabilitiesModels {
    mortgageFinancialAssets:MortgageFinancialAssets[]=[new MortgageFinancialAssets()];
    mortgageFinancialOtherAssets:MortgageFinancialOtherAssets[]=[new MortgageFinancialOtherAssets()];
    mortgageFinancialLiabilities:MortgageFinancialLiabilities[]=[new MortgageFinancialLiabilities()];
    mortgageFinancialOtherLaibilities:MortgageFinancialOtherLaibilities[]=[new MortgageFinancialOtherLaibilities()];
}
export class MortgageFinancialAssets{
    id: number
    creationTime: string
    creatorUserId: number
    lastModificationTime: string
    lastModifierUserId: number
    isDeleted: boolean
    deleterUserId: number
    deletionTime: string
    accountTypeId:number;
    financialInstitution:string;
    accountNumber:string;
    cashMarketValue:number;
    personalInformationId:number=3;
}
export class MortgageFinancialOtherAssets{
    id: number
    creationTime: string
    creatorUserId: number
    lastModificationTime: string
    lastModifierUserId: number
    isDeleted: boolean
    deleterUserId: number
    deletionTime: string
    financialAssetsTypeId:number;
    cashMarketValue:number;
    personalInformationId:number=3;
}
export class MortgageFinancialLiabilities{
    id: number
    creationTime: string
    creatorUserId: number
    lastModificationTime: string
    lastModifierUserId: number
    isDeleted: boolean
    deleterUserId: number
    deletionTime: string
    financialLaibilitiesTypeId:number;
    companyName:string;
    accountNumber:string;
    unpaidBalance:number;
    isPaidBeforeClosing:boolean=true;
    monthlyPayment:number;
    PersonalInformationId:number=3;
}
export class MortgageFinancialOtherLaibilities{
    id: number
    creationTime: string
    creatorUserId: number
    lastModificationTime: string
    lastModifierUserId: number
    isDeleted: boolean
    deleterUserId: number
    deletionTime: string
    financialLaibilitiesTypeId:number;
    monthlyPayment:number;
    personalInformationId:number=3;
}
